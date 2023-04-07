using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
