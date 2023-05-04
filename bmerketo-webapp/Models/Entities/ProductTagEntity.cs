using Microsoft.EntityFrameworkCore;

namespace bmerketo_webapp.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(TagId))]
public class ProductTagEntity
{
    public string ProductId { get; set; } = null!;

    public ProductEntity Product { get; set; } = null!;

    public int TagId { get; set; }

    public TagEntity Tag { get; set; } = null!;
}
