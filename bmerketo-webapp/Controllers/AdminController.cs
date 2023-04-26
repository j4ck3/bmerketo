using bmerketo_webapp.Models;
using bmerketo_webapp.Services;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers;

public class AdminController : Controller
{

    private readonly ProductService _productService;
    private readonly AuthService _authService;

    public AdminController(ProductService productService, AuthService authService)
    {
        _productService = productService;
        _authService = authService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Admin Dashboard";
        return View();
    }

    public IActionResult CreateUser()
    {
        ViewData["Title"] = "New User";
        return View();
    }

    public IActionResult CreateProduct()
    {
        ViewData["Title"] = "New Prodcut";
        return View();
    }

    public IActionResult Users()
    {
        ViewData["Title"] = "Users";
        return View();
    }

    public IActionResult Products()
    {
        ViewData["Title"] = "Products";
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (!await _authService.FindAsync(viewModel))
            {
                if (await _authService.RegisterAsync(viewModel))
                    return RedirectToAction("users");

                ModelState.AddModelError("", "Something went wrong when trying to create the user");
                return View(viewModel);
            }
            ModelState.AddModelError("", "A User with the same e-mail address already exists");
        }
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductFormModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _productService.CreateAsync(viewModel))
                return RedirectToAction("products");

            ModelState.AddModelError("", "Something went wrong while trying to create the product");
        }
        
        else 
             ModelState.AddModelError("", "Please Validate the form");

        return View(viewModel);
    }     
}