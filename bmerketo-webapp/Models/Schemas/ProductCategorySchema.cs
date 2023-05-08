using bmerketo_webapp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.Models.Schemas;

public class ProductCategorySchema
{
    public string? Value { get; set; }
    [Required(ErrorMessage = "You must enter a Category")]
    [MinLength(2, ErrorMessage = "Category must be atleast {1} characters in length.")]
    [Display(Name = "Category")]
    public string? Name { get; set; }


    public static implicit operator ProductCategoryEntity(ProductCategorySchema model)
    {
        return new ProductCategoryEntity
        {
            Id = model.Value,
            CategoryName = model.Name,
        };
    }
}