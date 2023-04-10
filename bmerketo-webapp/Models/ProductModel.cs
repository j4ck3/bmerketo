
using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.ViewModels;

namespace bmerketo_webapp.Models
{
    public class ProductModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }


        public static implicit operator ProductModel(ProductEntity entity)
        {
            return new ProductModel
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                OldPrice = entity.OldPrice,
            };
        }
    }   
}
