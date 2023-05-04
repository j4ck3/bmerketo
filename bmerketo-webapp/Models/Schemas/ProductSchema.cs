using bmerketo_webapp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.Models.Schemas;

public class CreateProductFormModel
{
    [Required(ErrorMessage = "Du måste ange ett namn")]
    [MinLength(2, ErrorMessage = "Namnet måsta vara minst {1} bokstäver långt.")]
    [Display(Name = "Produkt namn")]
    public string Name { get; set; } = null!;

    [Display(Name = "Beskrivning")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Du måste ange ett pris")]
    [Range(typeof(decimal), "1", "100000", ErrorMessage = "Ange ett giltigt pris mellan 1 och 100000")]
    [Display(Name = "Pris")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Rabatterat pris")]
    [DataType(DataType.Currency)]
    public decimal? OldPrice { get; set; }

    [Display(Name = "Välj en kategori")]
    public ProductCategorySchema Category { get; set; } = new ProductCategorySchema();

    [Display(Name = "Välj en kategori")]
    [Required(ErrorMessage = "Du måste välja en kategori")]
    public string CategoryId { get; set; } = null!;

    public static implicit operator ProductEntity(CreateProductFormModel viewModel)
    {
        return new ProductEntity
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            Price = viewModel.Price,
            OldPrice = viewModel.OldPrice,
        };
    }
}
