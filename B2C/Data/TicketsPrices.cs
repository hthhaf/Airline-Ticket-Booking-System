using System.ComponentModel.DataAnnotations;

namespace B2C.Data
{
    public class TicketsPrices
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(50)]
        public string FlightCode { get; set; }

        [StringLength(250)]
        public double Price { get; set; }
        public double Tax { get; set; }
        public int FlightId { get; set; }
    }
}
