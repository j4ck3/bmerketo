using bmerketo_webapp.Services;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers
{
    public class ProductController : Controller
    {

        private  readonly ProductService _productService;

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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel createProductViewModel)
        {
            ViewData["Title"] = "Create Product";
            if (ModelState.IsValid)
            {
                if (await _productService.CreateAsync(createProductViewModel))
                    return RedirectToAction("Index", "Product");

                ModelState.AddModelError("", "Something went wrong while trying to create the product");
            }
            return View();
        }

    }
}
