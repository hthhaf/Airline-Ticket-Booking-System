using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace B2C.Data
{
    public class UserInfo 
    {
        [Key]
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? ProfilePictureDataUrl { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public int? Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(255)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        [StringLength(255)]
        public string? ModifiedBy { get; set; }
        
    }
}
