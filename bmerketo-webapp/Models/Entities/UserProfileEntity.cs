using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.Models.Entities;

public class UserProfileEntity
{

    [Key, ForeignKey("User")]
    public string UserId { get; set; } = null!;

    public IdentityUser User { get; set; } = null!;

    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [ProtectedPersonalData]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string? Company { get; set; }

    [ForeignKey("Address")]
    public int? AddressId { get; set; }
    public virtual AddressEntity? Address { get; set; }
}
