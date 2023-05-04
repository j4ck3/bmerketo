using bmerketo_webapp.Models.Entities;

namespace bmerketo_webapp.Models.Schemas;

public class ProductCategorySchema
{
    public string? Value { get; set; }
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