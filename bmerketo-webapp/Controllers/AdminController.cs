using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.Schemas;
using bmerketo_webapp.Services;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers;


[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    #region private fiels & ctor
    private readonly ProductService _productService;
    private readonly AuthService _authService;
    private readonly TagService _tagService;
    private readonly ProductCategoryService _productCategoryService;
    private readonly UserService _userService;
    private readonly UserManager<IdentityUser> _userManager;

    public AdminController(ProductService productService, AuthService authService, TagService tagService, ProductCategoryService productCategoryService, UserService userService, UserManager<IdentityUser> userManager)
    {
        _productService = productService;
        _authService = authService;
        _tagService = tagService;
        _productCategoryService = productCategoryService;
        _userService = userService;
        _userManager = userManager;
    }
    #endregion

    #region views HTTPGET

    public IActionResult Index()
    {
        ViewData["Title"] = "Admin Dashboard";
        return View();
    }

    public IActionResult Users()
    {
        ViewData["Title"] = "Users";
        return View();
    }
    public IActionResult CreateUser()
    {
        ViewData["Title"] = "New User";
        return View();
    }

    public async Task<IActionResult> EditUser(string userId)
    {
        ViewData["Title"] = "Edit User";
        ViewData["Id"] = $"{userId}";
        var userProfile = await _userService.GetAsync(userId);

        var _userRoles = await _userManager.GetRolesAsync(userProfile.User);

        var viewModel = new ManageAccountViewModel
        {
            Id = userProfile.UserId,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,

            Email = userProfile.User.UserName,
            PhoneNumber = userProfile.User.PhoneNumber,

            StreetName = userProfile.Address.StreetName,
            PostalCode = userProfile.Address.PostalCode,
            City = userProfile.Address.City,
        };

        
        return View(viewModel);
    }

    public async Task<IActionResult> CreateProduct()
    {
        ViewBag.Tags = await _tagService.GetTagsToFormAsync();
        ViewData["Title"] = "New Prodcut";
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

    public async Task<IActionResult> Categories()
    {
        ViewData["Title"] = "Categories";
        ViewBag.Categories = await _productCategoryService.GetAllAsync();
        return View();
    }
    public IActionResult CreateCategory()
    {
        ViewData["Title"] = "Create Category";
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

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateProductCategoryViewModel viewmodel)
    {
        if (ModelState.IsValid)
        {
            var result = await _productCategoryService.GetAsync(viewmodel.Name);

            if (result == null)
            {
                try
                {
                    await _productCategoryService.CreateAsync(viewmodel);
                }
                catch
                {
                    ModelState.AddModelError("", "Something went wrong when trying to create the category");
                }
            }
            else
                ModelState.AddModelError("", "A category with the same name already exists.");
        }
        return View(viewmodel);
    }

    [HttpPost]
    public async Task<IActionResult> EditUser(ManageAccountViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _authService.UpdateAsync(viewModel);
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong when trying to update the user.");
            }
        }
        return View(viewModel);
    }


}