using System.ComponentModel.DataAnnotations;
using bmerketo_webapp.Models.Schemas;

namespace bmerketo_webapp.Models.Entities
{
    public class ProductCategoryEntity
    {
        [Key]
        public string Id { get; set; } = new Guid().ToString();

        public string CategoryName { get; set; } = null!;

        public ICollection<ProductEntity>? Products { get; set; } = new HashSet<ProductEntity>();



        public static implicit operator ProductCategorySchema(ProductCategoryEntity model)
        {
            return new ProductCategorySchema
            {
                Value = model.Id,
                Name = model.CategoryName,
            };
        }
    }
}
