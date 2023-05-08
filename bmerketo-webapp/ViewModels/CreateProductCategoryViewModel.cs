using bmerketo_webapp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.ViewModels
{
    public class CreateProductCategoryViewModel
    {
        [Required(ErrorMessage = "You must enter a Category")]
        [MinLength(2, ErrorMessage = "Category must be atleast {1} characters in length.")]
        [Display(Name = "Category")]
        public string Name { get; set; } = null!;

        public static implicit operator ProductCategoryEntity(CreateProductCategoryViewModel viewModel)
        {
            return new ProductCategoryEntity
            {
                CategoryName = viewModel.Name,
            };
        }
    }
}
