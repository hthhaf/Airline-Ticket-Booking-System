#nullable disable

namespace B2C.ApiHelper.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AdultFare
    {
        public double Fare { get; set; }
        public double Charge { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public List<object> TaxDetails { get; set; }
    }

    public class ChildFare
    {
        public double Fare { get; set; }
        public double Charge { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public List<object> TaxDetails { get; set; }
    }

    public class Flight
    {
        public string DepartureCode { get; set; }
        public string ArrivalCode { get; set; }
        public string FlightCode { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int TotalDuration { get; set; }
        public int StopNo { get; set; }
        public string AirlineSystem { get; set; }
        public string FlightAirline { get; set; }
        public string AirlineSystemText { get; set; }
        public string FlightAirlineText { get; set; }
        public string FlightType { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<object> StopInfos { get; set; }
    }

    public class InfantFare
    {
        public double Fare { get; set; }
        public double Charge { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public List<object> TaxDetails { get; set; }
    }

    public class Inventory
    {
        public string SeatClass { get; set; }
        public string FareType { get; set; }
        public string FareBasisCode { get; set; }
        public int Available { get; set; }
        public AdultFare AdultFare { get; set; }
        public ChildFare ChildFare { get; set; }
        public InfantFare InfantFare { get; set; }
        public double TotalFare { get; set; }
        public double TotalCharge { get; set; }
        public double TotalPrice { get; set; }
        public string Currency { get; set; }
    }

    public class SearchResponse
    {
        public bool IsMergeFlight { get; set; }
        public List<Route> Routes { get; set; }
        public bool Result { get; set; }
        public List<object> Messages { get; set; }
    }

    public class Route
    {
        public int RouteNo { get; set; }
        public List<Flight> Flights { get; set; }
    }


}
