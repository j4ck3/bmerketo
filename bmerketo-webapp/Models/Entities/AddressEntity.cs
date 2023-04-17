using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace bmerketo_webapp.Models.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }


    [ForeignKey("User")]
    public string UserId { get; set; } = null!;


    public IdentityUser User { get; set; } = null!;


    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string StreetName { get; set; } = null!;


    [Column(TypeName = "char(6)")]
    public string PostalCode { get; set; } = null!;


    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string City { get; set; } = null!;
}
