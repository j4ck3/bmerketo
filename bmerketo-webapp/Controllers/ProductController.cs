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

        public IActionResult Index()
        {
            ViewData["Title"] = "Product";
            return View();
        }

        public IActionResult Search()
        {
            ViewData["Title"] = "Search Product";
            return View();
        }

        public IActionResult Products()
        {
            ViewData["Title"] = "All Products";

            var viewmodel = new ProductsViewModel
            {
                Title = "All Products",
                Button = new ButtonViewModel
                {
                    Content = "Load More",
                    Url = ""
                }
            };
            return View(viewmodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Product";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.CreateAsync(createProductViewModel))
                    return RedirectToAction("Products", "Product");

                ModelState.AddModelError("", "Something went wrong while trying to create the product");
            }
            return View();
        }

    }
}
