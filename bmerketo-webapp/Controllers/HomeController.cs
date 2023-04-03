using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        ViewData["Title"] = "Home";
        return View();
    }



    public IActionResult Contact()
    {

        ViewData["Title"] = "Contact";
        return View();
    }
}
