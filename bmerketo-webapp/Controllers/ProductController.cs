using Microsoft.AspNetCore.Mvc;

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
    }
}
