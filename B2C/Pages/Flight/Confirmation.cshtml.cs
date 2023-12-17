using B2C.ApiHelper.Model;
using B2C.Data;
using B2C.Model;
using B2C.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
#nullable disable

namespace B2C.Pages.Flight
{
    public class ConfirmationModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ListModel> _logger;
        private readonly IMailService _mailService;
        //injecting the IMailService into the constructor
        

        
        
        
        public Booking Booked { get; set; }
        public List<Passenger> pax { get; set; }

        public ConfirmationModel(ILogger<ListModel> logger, ApplicationDbContext dbContext, IMailService _MailService)
        {
            _logger = logger;
            _mailService = _MailService;
            _dbContext = dbContext;
        }

        public void OnGet(string data)
        {
            if (Guid.TryParse(data, out Guid bookingId))
            {
                Booked = _dbContext.Bookings.Where(b => b.BookingId == bookingId).FirstOrDefault();
                pax = _dbContext.Passengers.Where(p => p.BookingId == bookingId).ToList();
            }
        }

        
    }
}
