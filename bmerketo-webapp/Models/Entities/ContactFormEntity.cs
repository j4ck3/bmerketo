using bmerketo_webapp.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webapp.Models.Entities
{
    public class ContactFormEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string? FirstName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string? Company { get; set; }

        public string Message { get; set; } = null!;

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public virtual UserProfileEntity User { get; set; } = null!;

    }
}
