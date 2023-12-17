using B2C.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable

namespace B2C
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ApplicationDbContext _dbContext;

        [BindProperty]
        public List<Airport> Airports { get; set; }
        public List<PopularFlight> Destination { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Airports = _dbContext.Airports.ToList();
            Destination = _dbContext.PopularFlight.ToList();
            /*ViewBag.AirportList = Airports;*/
        }

    }
}
