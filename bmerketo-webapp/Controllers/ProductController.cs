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

        public async Task<IActionResult> Products()
        {
            ViewData["Title"] = "All Products";

            var viewModel = new ProductsViewModel
            {
                Title = "All Products",
                Button = new ButtonViewModel
                {
                    Content = "Load More",
                    Url = ""
                },
                Items = await _productService.GetAllAsync("")
            };

            return View(viewModel);
        }
    }
}
