using System.ComponentModel.DataAnnotations;

namespace B2C.Data
{
    
        public class PopularFlight
    {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string Image { get; set; }
            [StringLength(50)]
            public string Arrival { get; set; }

            [StringLength(250)]
            public double PriceTo { get; set; }
            [StringLength(50)]
            public string Status { get; set; }
            public string Description { get; set; }
        }
    
}
