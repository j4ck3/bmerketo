using bmerketo_webapp.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webapp.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "nvarchar(500)")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal? OldPrice { get; set; }

        [ForeignKey("Category")]
        public string CategoryId { get; set; } = null!;

        public ProductCategoryEntity Category { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public static implicit operator ItemViewModel(ProductEntity entity)
        {
            return new ItemViewModel
            {
                Title = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                OldPrice = entity.OldPrice,
                Category = entity.Category.CategoryName,
            };
        }

    }
}
