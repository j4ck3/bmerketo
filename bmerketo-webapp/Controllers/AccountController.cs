using bmerketo_webapp.Services;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers;

public class AccountController : Controller
{

    private readonly AuthService _authService;

    public AccountController(AuthService authService)
    {
        _authService = authService;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Register()
    {
        ViewData["Title"] = "Register";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (!await _authService.FindAsync(viewModel))
            {
                if (await _authService.RegisterAsync(viewModel))
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Something went wrong when trying to register");
            }
            else
                ModelState.AddModelError("", "A User with the same e-mail address already exists");
        }
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Login()
    {
        ViewData["Title"] = "Login";
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.SignInAsync(viewModel))
                return RedirectToAction("Index");

            ModelState.AddModelError("", "These credentials doesn't match our records");
        }
        return View(viewModel);
    }


    [HttpGet]
    [Authorize]
    public new async Task<IActionResult> SignOut()
    {

        if (await _authService.SignOutAsync(User))
            return LocalRedirect("/");

        return RedirectToAction("Index", "Home");
    }
}


