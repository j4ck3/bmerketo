using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers
{
    public class ContactController : Controller
    {


        public IActionResult Index()
        {
            ViewData["Title"] = "Contact Us";
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactFormViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}

