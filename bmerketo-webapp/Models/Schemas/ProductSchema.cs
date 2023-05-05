using bmerketo_webapp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.Models.Schemas;

public class CreateProductFormModel
{
    [Required]
    [MinLength(2, ErrorMessage = "Name must be atleast {1} characters in legnt.")]
    [Display(Name = "Product Name")]
    public string Name { get; set; } = null!;


    [Display(Name = "Description")]
    public string? Description { get; set; }


    [Required]
    [Range(typeof(decimal), "1", "100000", ErrorMessage = "Enter a value between 1 & 100000")]
    [Display(Name = "Price")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Discounted price")]
    [DataType(DataType.Currency)]
    public decimal? OldPrice { get; set; }


    [Display(Name = "Product Image")]
    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; }

    [Display(Name = "Category")]
    [Required]
    public string CategoryId { get; set; } = null!;

    public static implicit operator ProductEntity(CreateProductFormModel viewModel)
    {


        var entity = new ProductEntity
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            Price = viewModel.Price,
            OldPrice = viewModel.OldPrice,
        };

        if (viewModel.Image != null)
            entity.ImageName = $"{Guid.NewGuid()}_{viewModel.Image.FileName}";

        return entity;
    }
}
