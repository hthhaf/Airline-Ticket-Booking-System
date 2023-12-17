using B2C.ApiHelper.Model;
using B2C.Data;
using B2C.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
#nullable disable

namespace B2C.Pages.Flight
{
    public class MyBookingModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ListModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IViewRenderService _viewRenderService;
        private readonly IMailService _mailService;
        public List<Passenger> Pax { get; set; }
        public List<Airport> Airports { get; set; }
        public Booking Abooking { get; set; }
        public MyBookingModel(ILogger<ListModel> logger, ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, IMailService _MailService, IViewRenderService viewRenderService)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
            _mailService = _MailService;
            _viewRenderService = viewRenderService;
        }
        public void OnGet(string pnr, string lastName)
        {
            try
            {

                Abooking = _dbContext.Bookings.Where(x => x.ConfirmationNumber == pnr).FirstOrDefault();
                Airports = _dbContext.Airports.ToList();
                
                if (_dbContext.Passengers.Where(tp => tp.LastName == lastName && tp.ConfirmationNumber == pnr).FirstOrDefault() != null)
                {
                    Pax = _dbContext.Passengers.Where(tp => tp.ConfirmationNumber == pnr).ToList();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error in OnGet method: {ex.Message}");
                throw; // Re-throw the exception if necessary
            }
        }

    }
}
