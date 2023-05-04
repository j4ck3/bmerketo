using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.Models.Schemas;
using bmerketo_webapp.Repos;

namespace bmerketo_webapp.Services
{
    public class ProductCategoryService
    {

        private readonly ProductCategoryRepo _categoryRepo;

        public ProductCategoryService(ProductCategoryRepo categoryReop)
        {
            _categoryRepo = categoryReop;
        }

        public async Task<ProductCategoryEntity> GetOrCreateAsync(ProductCategoryEntity category)
        {
            var categoryEntity = await _categoryRepo.GetAsync(x => x.Id == category.Id);
            categoryEntity ??= await _categoryRepo.AddAsync(new ProductCategoryEntity { CategoryName = category.CategoryName}); 
            return categoryEntity;
        }

        public async Task<IEnumerable<ProductCategorySchema>> GetAllAsync()
        {
            var categories = new List<ProductCategorySchema>();

            foreach (var item in await _categoryRepo.GetAllAsync())
                categories.Add(new ProductCategorySchema { Value = item.Id, Name = item.CategoryName });

            return categories;
        }
    }
}
 