using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.Models.Entities
{
    public class ProductCategoryEntity
    {
        [Key]
        public string Id { get; set; } = new Guid().ToString();

        public string CategoryName { get; set; } = null!;

        public ICollection<ProductEntity>? Products { get; set; } = new List<ProductEntity>();

        public static implicit operator ProductCategoryModel(ProductCategoryEntity model)
        {
            return new ProductCategoryModel
            {
                Value = model.Id,
                Name = model.CategoryName,
            };
        }
    }
}
