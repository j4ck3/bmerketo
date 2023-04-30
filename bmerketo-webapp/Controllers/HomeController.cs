using bmerketo_webapp.Contexts;
using bmerketo_webapp.Services;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers;

public class HomeController : Controller
{

    private readonly IdentityContext _identityContext;
    private readonly HomeViewService _homeViewService;
    public HomeController(IdentityContext identityContext, HomeViewService homeViewService)
    {
        _identityContext = identityContext;
        _homeViewService = homeViewService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _homeViewService.Populate());
    }

    public IActionResult Contact()
    {
        ViewData["Title"] = "Contact Us";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contact(ContactFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _identityContext.ContactForm.Add(viewModel);
                await _identityContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong when trying to sumbit the form");
                return View(viewModel);
            }
        }
        return View(viewModel);
    }
}
