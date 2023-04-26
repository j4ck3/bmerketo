using bmerketo_webapp.Models;

namespace bmerketo_webapp.ViewModels;
public class CreateProductViewModel
{
    public CreateProductFormModel Form { get; set; } = new CreateProductFormModel();
    public IEnumerable<ProductCategoryModel> ProductCategories { get; set; } = null!;  
}
