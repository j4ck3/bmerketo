using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models;
using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bmerketo_webapp.Services;

public class ProductService
{
    private readonly DataContext _dataContext;

    public ProductService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> CreateAsync(CreateProductViewModel createProductViewModel)
    {
        try
        {
            ProductEntity productEntity = createProductViewModel;
            _dataContext.Products.Add(productEntity);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var products = new List<ProductModel>();
        var items = await _dataContext.Products.ToListAsync();
        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }
        return products;
    }

}
