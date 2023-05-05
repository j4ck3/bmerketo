using bmerketo_webapp.Models.Schemas;
using bmerketo_webapp.Services;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers;


[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    #region private fiels & ctor
    private readonly ProductService _productService;
    private readonly AuthService _authService;
    private readonly TagService _tagService;

    public AdminController(ProductService productService, AuthService authService, TagService tagService)
    {
        _productService = productService;
        _authService = authService;
        _tagService = tagService;
    }
    #endregion

    #region views HTTPGET

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

    public async Task<IActionResult> CreateProduct()
    {
        ViewBag.Tags = await _tagService.GetTagsToFormAsync();
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

    public IActionResult Tags()
    {
        ViewData["Title"] = "Tags";
        return View();
    }
    public IActionResult CreateTag()
    {

        ViewData["Title"] = "Create tag";
        return View();
    }

    #endregion

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
    public async Task<IActionResult> CreateProduct(CreateProductFormModel viewModel, string[] tags)
    {
        if (ModelState.IsValid)
        {
            var productEntity = await _productService.CreateAsync(viewModel);

            if(productEntity != null)
            {
                if (await _tagService.CreateProductTagsAsync(productEntity, tags))
                {
                    if (viewModel.Image != null)
                        await _productService.UploadImageAsync(productEntity, viewModel.Image);

                    return RedirectToAction("products");
                }
                ModelState.AddModelError("", "Something went wrong while trying to add the tags to the product.");
            }
            ModelState.AddModelError("", "Something went wrong while trying to create the product");
        }

        ModelState.AddModelError("", "Please Validate the form");
        ViewBag.Tags = await _tagService.GetTagsToFormAsync(tags);
        return View(viewModel);
    }



    [HttpPost]
    public async Task<IActionResult> CreateTag(TagSchema schema)
    {
        if (ModelState.IsValid)
        {
            var result = await _tagService.GetAsync(schema.Name);
            
            if (result == null)
            {
                try
                {
                    await _tagService.CreateAsync(schema);
                }
                catch 
                {
                    ModelState.AddModelError("", "Something went wrong when trying to create the Tag");
                }
            }else
                ModelState.AddModelError("", "A tag with the same name already exists.");
        }
        return View(schema);
    }
}