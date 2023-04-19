using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.Models.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string? StreetName { get; set; }


    [Column(TypeName = "char(6)")]
    public string? PostalCode { get; set; }


    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string? City { get; set; }
}
