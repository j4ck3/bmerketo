using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.Models.Schemas;
using bmerketo_webapp.Repos;
using bmerketo_webapp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bmerketo_webapp.Services;

public class ProductService
{
    private readonly ProductCategoryService _categoryService;
    private readonly ProductRepo _productRepo;
    private readonly DataContext _dataContext;

    public ProductService(ProductRepo productRepo, ProductCategoryService categoryService, DataContext dataContext)
    {
        _productRepo = productRepo;
        _categoryService = categoryService;
        _dataContext = dataContext;
    }

    public async Task<List<ItemViewModel>> GetAllAsync(string category)
    {
        List<ItemViewModel> products = new();
        if(!string.IsNullOrEmpty(category))
        {
            var items = await _dataContext.Products.Where(c => c.Category.CategoryName == category).Include(x => x.Category).ToListAsync();
            foreach (var item in items)
            {
                products.Add(new ItemViewModel
                {
                    Id = item.Id,
                    Title = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    OldPrice = item.OldPrice,
                    ImageName = item.ImageName,
                    Category = item.Category,
                });
            }
            return products;

        }else
        {
            var items = await  _dataContext.Products.Include(x => x.Category).ToListAsync();
            foreach (var item in items)
            {
                products.Add(new ItemViewModel
                {
                    Id = item.Id,
                    Title = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    OldPrice = item.OldPrice,
                    ImageName = item.ImageName,
                    Category = item.Category,
                });
            }
            return products;
        }
    }

    public async Task<ProductEntity> CreateAsync(CreateProductFormModel form)
    {
        try
        {
            ProductEntity productEntity = form;
            productEntity.CategoryId = form.CategoryId;
            // = (await _categoryService.GetOrCreateAsync(productEntity.Category)).Id;


            var result = await _productRepo.AddAsync(productEntity);
            return result;
        }
        catch { return null!; }
    }

    public async Task<ItemViewModel> Get(string id)
    {
        try
        {
            var item = await _dataContext.Products.Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
            {
                ItemViewModel itemViewModel = item;
                return itemViewModel!;
            }
            return null!;
        }catch { return null!; }
    }
}
 