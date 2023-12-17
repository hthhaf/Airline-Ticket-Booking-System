using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace B2C.Data
{
    public class Airport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool International { get; set; }
        [StringLength(250)]
        public string Location { get; set; }
    }
}

