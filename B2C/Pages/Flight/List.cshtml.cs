using Azure;
using B2C.ApiHelper;
using B2C.ApiHelper.Model;
using B2C.Services;
using B2C.Data;
using B2C.Model;
using B2C.Pages.Authen;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Globalization;

using Org.BouncyCastle.Asn1.Pkcs;
using Microsoft.AspNetCore.Components.RenderTree;
#nullable disable

namespace B2C.Pages.Flight
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ListModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IViewRenderService _viewRenderService;
        private readonly IMailService _mailService;
        //injecting the IMailService into the constructor

        [BindProperty]
        public List<FlightModel> flights { get; set; }
        public List<FlightWithPrice> flightsWithPrice { get; set; }
        public List<Airport> Airports { get; set; }
        public IdentityUser UserLogin { get; set; }
        public int paxCount;
        public int seats;
        public string BookId;
        public Booking Booked { get; set; }
        public string ReservesionType {  get; set; }
        public List<Passenger> Pax { get; set; }
        public UserInfo UserLoginInfo { get; set; }
        public List<Passenger> Passengers { get; set; }
        public Booking Abooking { get; set; }
        public ListModel(ILogger<ListModel> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, IMailService _MailService, IViewRenderService viewRenderService)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
            _mailService = _MailService;
            _viewRenderService = viewRenderService;
    }

        public async Task OnGet(string type, string departure, string arrival, string departureDate, int passenger, int adult, int children)
        {
            try
            {
                    paxCount = passenger;
                    if (User.Identity.Name != null)
                    {
                        UserLogin = await _userManager.FindByNameAsync(User.Identity.Name);
                        UserLoginInfo = _dbContext.UserInfo.FirstOrDefault(x => x.CreatedBy.Contains(User.Identity.Name));
                    }

                    Airports = _dbContext.Airports.ToList();
                    var data = _dbContext.Flights
                        .Where(x =>
                            x.Departure == departure &&
                            x.Arrival == arrival &&
                            x.DepartureTime.Date.ToString() == departureDate &&
                            x.AvailableSeats >= passenger &&
                            x.Status == "Active")
                        .ToList();

                    flights = data;
                    flightsWithPrice = new List<FlightWithPrice>(); // Initialize the list

                    foreach (var flight in flights)
                    {
                        var ticketPrices = _dbContext.TicketsPrices.Where(tp => tp.FlightCode == flight.Code).ToList();


                        foreach (var ticketPrice in ticketPrices)
                        {
                            double amount = CalculateTotalAmount(ticketPrice, adult, children);
                            double tax = CalculateTotaltax(ticketPrice, adult, children);
                            var flightWithPrice = new FlightWithPrice
                            {
                                flight = flight,
                                tax = tax,
                                amount = amount,
                                passengercount = passenger,
                            };

                            flightsWithPrice.Add(flightWithPrice);
                        }

                    }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error in OnGet method: {ex.Message}");
                throw; // Re-throw the exception if necessary
            }
        }

        private double CalculateTotalAmount(TicketsPrices ticketPrice, int adult, int children)
        {

            double adjustedAmount = ticketPrice.Price * adult + ticketPrice.Price * 0.7 * children;

            return adjustedAmount;
        }
        private double CalculateTotaltax(TicketsPrices ticketPrice, int adult, int children)
        {

            double adjustedAmount = ticketPrice.Tax * adult + ticketPrice.Tax * 0.7 * children;

            return adjustedAmount;
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                
                bool isSave = await SaveBooking();
                

                

                if (isSave)
                {

                    var htmlMailData = new HTMLMailData
                    {
                        EmailToName = Booked.ContactEmail, 
                        EmailToId = Booked.ContactEmail,

                    };
                    
                   
                    string body = await _viewRenderService.RenderToStringAsync("_Template", new Template { Booking = Booked, Pax = Pax });


                    bool isEmailSent = await _mailService.SendHTMLMail(htmlMailData, body);

                    if (isEmailSent)
                    {
                        return RedirectToPage("./Confirmation", new { data = BookId });
                    }
                    else
                    {
                        return RedirectToPage("/Error");
                    }
                }
                else
                {
                    return RedirectToPage("/Error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnPostAsync method: {ex.ToString()}");
                return RedirectToPage("/Error");
            }
        }


        private async Task<IActionResult> UpdateAvailableSeats(string flightId)
        {
            
            var flight = _dbContext.Flights.FirstOrDefault(f => f.Code == flightId);

            if (flight != null)
            {
                int availableSeats = flight.AvailableSeats - seats;


                flight.AvailableSeats = availableSeats;

                _dbContext.Flights.Update(flight);
                await _dbContext.SaveChangesAsync();
                return new JsonResult(Results.Accepted("success"));
            }
            return new JsonResult(Results.BadRequest("fail"));
        }
        private async Task<bool> SaveBooking()
        {
            try
            {
                Booking booking = new Booking();

                // Use model binding to populate the properties
                if (await TryUpdateModelAsync(booking, "Abooking"))
                {
                    booking.BookingId = Guid.NewGuid();
                    booking.ReservationType = "Oneway";
                    booking.CreatedDate = DateTime.Now;
                    booking.CreatedBy = User.Identity?.Name;
                    booking.ConfirmationNumber = GenerateConfirmationNumber();
                    booking.BookingStatus = "Hold";

                    List<Passenger> pax = new List<Passenger>();

                    if (await TryUpdateModelAsync(pax, "Passengers"))
                    {
                        foreach (var passengerInfo in pax)
                        {
                            var passenger = new Passenger
                            {
                                PassengerId = Guid.NewGuid(),
                                BookingId = booking.BookingId,
                                ConfirmationNumber = booking.ConfirmationNumber,
                                CreatedDate = DateTime.Now,
                                CreatedBy = User.Identity?.Name,
                                LastName = passengerInfo.LastName,
                                FirstName = passengerInfo.FirstName,
                                Title = passengerInfo.Title,
                                DateOfBirth = passengerInfo.DateOfBirth,

                            };

                            _dbContext.Passengers.Add(passenger);
                        }
                        Pax = pax;
                    }
                    _dbContext.Bookings.Add(booking);
                    Booked = booking;
                    BookId = booking.BookingId.ToString();
                    seats = pax.Count();
                    await UpdateAvailableSeats(booking.FlightNumber);
                    await _dbContext.SaveChangesAsync(); // Use async SaveChanges

                    return true;
                }
                
            }
            catch (Exception ex)
            {
                // Log or handle the exception with more details
                Console.WriteLine($"Error in SaveBooking method: {ex.ToString()}");
            }

            return false;
        }

        private string GenerateConfirmationNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();

            string confirmationNumber = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return confirmationNumber;
        }

    }

    
}