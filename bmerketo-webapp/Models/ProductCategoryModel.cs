using bmerketo_webapp.Models.Entities;

namespace bmerketo_webapp.Models;

public class ProductCategoryModel
{
    public string? Value { get; set; }
    public string? Name { get; set; }


    public static implicit operator ProductCategoryEntity(ProductCategoryModel model)
    {
        return new ProductCategoryEntity
        {
            Id = model.Value,
            CategoryName = model.Name,
        };
    }
}