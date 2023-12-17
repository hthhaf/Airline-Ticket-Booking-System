using B2C.ApiHelper.Model;

namespace B2C.Data
{
    public class FlightWithPrice
    {
        public FlightModel flight { get; set; }
        public double amount { get; set; }
        public double tax { get; set; }
        public int passengercount { get; set; }
        
    }
}
