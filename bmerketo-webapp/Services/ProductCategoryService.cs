using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.Models.Schemas;
using bmerketo_webapp.Repos;
using bmerketo_webapp.ViewModels;

namespace bmerketo_webapp.Services
{
    public class ProductCategoryService
    {

        private readonly ProductCategoryRepo _categoryRepo;

        public ProductCategoryService(ProductCategoryRepo categoryReop)
        {
            _categoryRepo = categoryReop;
        }

        public async Task<ProductCategoryEntity> GetAsync(string name)
        {
            try 
            {
               return await _categoryRepo.GetAsync(x => x.CategoryName == name);
            }
            catch { return null!; }
        }

        public async Task<ProductCategoryEntity> CreateAsync(CreateProductCategoryViewModel viewmodel)
        {
            try
            {
               return await _categoryRepo.AddAsync(viewmodel);
            }
            catch { return null!; }
        }

        public async Task<IEnumerable<ProductCategorySchema>> GetAllAsync()
        {
            try
            {
                var categories = new List<ProductCategorySchema>();
                foreach (var item in await _categoryRepo.GetAllAsync())
                    categories.Add(new ProductCategorySchema { Value = item.Id, Name = item.CategoryName });

                return categories;
            }
            catch { return null!; }
        }
    }
}
