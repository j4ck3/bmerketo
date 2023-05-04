using bmerketo_webapp.Models.Schemas;

namespace bmerketo_webapp.ViewModels;
public class CreateProductViewModel
{
    public CreateProductFormModel Form { get; set; } = new CreateProductFormModel();
    public IEnumerable<ProductCategorySchema> ProductCategories { get; set; } = null!;  
}
