using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace B2C.Data
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }
        [StringLength(50)]
        public string Route { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DepartureDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ArrivalDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DepartureDateRe { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ArrivalDateRe { get; set; }


        public string ReservationType { get; set; }
        [StringLength(10)]
        public string FlightNumber { get; set; }
        [StringLength(10)]
		public string FlightNumberRe { get; set; }
		[StringLength(10)]
		public string ConfirmationNumber { get; set; }
        [StringLength(50)]
        public string Departure { get; set; }
        [StringLength(50)]
        public string Arrival { get; set; }
        [StringLength(50)]

       
        public string BookingStatus { get; set; }
        [StringLength(50)]
        
        [Column(TypeName = "datetime")]
        public DateTime? BookDate { get; set; }
        public double? BalancedDue { get; set; }
        [StringLength(50)]
        public string ContactEmail { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TimeLimit { get; set; }
        public int? PassengerCount { get; set; }
        public int? ContactPhoneNumber { get; set; }
        
            public string ContactFirstName { get; set; }
            public string ContactLastName { get; set; }
        public string ContactAddress { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        [StringLength(255)]
        public string ModifiedBy { get; set; }
    }
}
