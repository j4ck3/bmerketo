using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.Models.DTOS;
using bmerketo_webapp.Models.Schemas;

namespace bmerketo_webapp.ViewModels;

public class ItemViewModel
{
    public string Id { get; set; } = null!;
    public string? Title { get; set; }
    public decimal? Price { get; set; }
    public decimal? OldPrice { get; set; }
    public string? ImageName { get; set; }
    public string? Creator { get; set; }
    public int? Comments { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();

    public ProductCategorySchema? Category { get; set; }
    public ButtonViewModel? Button { get; set; }
}