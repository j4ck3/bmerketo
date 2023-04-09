using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace bmerketo_webapp.Controllers
{
    public class ProductController : Controller
    {
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


        public IActionResult Create(CreateProductViewModel createProductViewModel)
        {
            ViewData["Title"] = "Create Product";
            if (ModelState.IsValid)
            {

            }
            return View();
        }

    }
}
