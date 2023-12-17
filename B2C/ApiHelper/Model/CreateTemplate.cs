#nullable disable

namespace B2C.ApiHelper.Model
{
    public class _Baggage
    {
        public int RouteNo { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
    }

    public class _FareInfo
    {
        public string SeatClass { get; set; }
    }

    public class _Flight
    {
        public int RouteNo { get; set; }
        public string FlightCode { get; set; }
        public string AirlineSystem { get; set; }
        public string FlightAirline { get; set; }
        public string DepartureCode { get; set; }
        public string ArrivalCode { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public _FareInfo FareInfo { get; set; }
    }

    public class _Passenger
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public List<_Baggage> Baggages { get; set; }
    }

    public class CreateRequest
    {
        public string BookType { get; set; }
        public bool IsTicketing { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneRemark { get; set; }
        public string Remark { get; set; }
        public List<_Passenger> Passengers { get; set; } = new List<_Passenger>();
        public List<_Flight> Flights { get; set; } = new List<_Flight>();
        public string PromotionCode { get; set; }
    }



    public class _RecordLocation
    {
        public int RouteNo { get; set; }
        public string AirlineSystem { get; set; }
        public string RecordLocation { get; set; }
        public string RecordStatus { get; set; }
        public DateTime HoldExpireDate { get; set; }
        public object TicketedDate { get; set; }
    }

    public class CreateResponse
    {
        public List<_RecordLocation> RecordLocations { get; set; }
        public string TicketFace { get; set; }
        public double TotalAmount { get; set; }
        public bool Result { get; set; }
        public List<object> Messages { get; set; }
    }
}
