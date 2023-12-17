using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace B2C.Data
{
    public class Passenger
    {
        [Key]
        public Guid PassengerId { get; set; }
        public Guid BookingId { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        [StringLength(255)]
        public string PassengerType { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        public string ConfirmationNumber { get; set; }
       
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
