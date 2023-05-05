using bmerketo_webapp.Services;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string id)
        {
            var item = await _productService.Get(id);
            ViewData["Title"] = $"{item.Title}";
            return View(item);
        }

        public IActionResult Search()
        {
            ViewData["Title"] = "Search Product";
            return View();
        }

        public async Task<IActionResult> Products(string? category)
        {
            ViewData["Title"] = "All Products";
            List<ItemViewModel>? _items;

            if (!string.IsNullOrEmpty(category))
            {
                _items = await _productService.GetAllAsync(category);
            }
            else
            {
                _items = await _productService.GetAllAsync("");
            }

            var viewModel = new ProductsViewModel
            {
                Title = "All Products",
                Button = new ButtonViewModel
                {
                    Content = "Load More",
                    Url = ""
                },
                Items = _items
            };
            return View(viewModel);
        }
    }
}
