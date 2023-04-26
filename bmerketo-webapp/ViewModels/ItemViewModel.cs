using bmerketo_webapp.Models;
namespace bmerketo_webapp.ViewModels;

public class ItemViewModel
{
    public Guid? Id { get; set; }
    public string? ImageUrl { get; set; }
    public string? Title { get; set; }
    public decimal? Price { get; set; }
    public decimal? OldPrice { get; set; }
    

    public string? Creator { get; set; }
    public int? Comments { get; set; }
    public string? Description { get; set; }

    public string? Category { get; set; }
    public ButtonViewModel? Button { get; set; }

    public static implicit operator ItemViewModel(ProductModel model)
    {
        return new ItemViewModel
        {
            Id = model.Id,
            Title = model.Name,
            Description = model.Description,
            Price = model.Price,
            OldPrice = model.OldPrice,
        };
    }
}
