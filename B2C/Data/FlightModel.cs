using System.ComponentModel.DataAnnotations;

namespace B2C.Data
{
    public class FlightModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Code { get; set; }
        [StringLength(50)]
        public string? Route { get; set; }
        [StringLength(50)]
        public string? Status { get; set; }
        [StringLength(50)]
        public string? Departure { get; set; }
        [StringLength(50)]
        public string? Arrival { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }


        public double Duration { get; set; }

        public int AvailableSeats { get; set; }

        public static implicit operator FlightModel(FlightWithPrice v)
        {
            throw new NotImplementedException();
        }
    }
}
