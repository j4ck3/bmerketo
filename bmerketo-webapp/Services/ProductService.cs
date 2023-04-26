using bmerketo_webapp.Models;
using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.Repos;

namespace bmerketo_webapp.Services;

public class ProductService
{
    private readonly ProductCategoryService _categoryService;
    private readonly ProductRepo _productRepo;

    public ProductService(ProductRepo productRepo, ProductCategoryService categoryService)
    {
        _productRepo = productRepo;
        _categoryService = categoryService;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _productRepo.GetAllAsync();
    }

    public async Task<bool> CreateAsync(CreateProductFormModel form)
    {
        try
        {
            ProductEntity productEntity = form;
            productEntity.CategoryId = form.CategoryId;
            //= (await _categoryService.GetOrCreateAsync(productEntity.Category)).Id;


            await _productRepo.AddAsync(productEntity);
            return true;
        }
        catch { return false; }
    }
}
 