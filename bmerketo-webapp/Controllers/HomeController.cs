using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webapp.Controllers;

public class HomeController : Controller
{

    private readonly IdentityContext _identityContext;

    public HomeController(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            Title = "Home",
            BestCollection = new CollectionsViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },
                GridItems = new List<ItemViewModel>
                {
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "Apple watch collection", Price = 10, ImageUrl = "imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "Apple watch collection", Price = 20, ImageUrl = "imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "Apple watch collection", Price = 30, ImageUrl = "imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "Apple watch collection", Price = 40, ImageUrl = "imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "Apple watch collection", Price = 50, ImageUrl = "imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "Apple watch collection", Price = 60, ImageUrl = "imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "Apple watch collection", Price = 70, ImageUrl = "imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "Apple watch collection", Price = 80, ImageUrl = "imgs/placeholders/270x295.svg" }
                }
            },

            Landing = new LandingViewModel
            {
                Title = "WELLCOME TO bmarketo SHOP",
                Messgae = "Exclusive Chair gold Collection",
                ImgUrl = "/imgs/placeholders/625x647.svg",
                Button = new ButtonViewModel
                {
                    Content = "shop now",
                    Url = "sale"
                }
            },
            ProductTileGrid = new ProductTileGridViewModel
            {
                Title1 = "UP TO SELL",
                Title2 = "50% OFF",
                Title3 = "Get The Best Price",
                Title4 = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",
                Button = new ButtonViewModel
                {
                    Content = "Discover More",
                    Url = "sale"
                },

                GridItems = new List<ItemViewModel>
                {
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is first element", Price = 25, OldPrice = 50, ImageUrl = "/imgs/placeholders/370x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is second element", Price = 79, OldPrice = 99, ImageUrl = "/imgs/placeholders/370x295.svg" },
                }
            },
            ProductTileRow = new ProductTileRowViewModel
            {
                Title = "Top selling products in this week",
                Items = new List<ItemViewModel>
                {
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is first element", Price = 25, OldPrice = 50, ImageUrl = "/imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is second element", Price = 79, OldPrice = 99, ImageUrl = "/imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is second element", Price = 79, OldPrice = 99, ImageUrl = "/imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is second element", Price = 79, OldPrice = 99, ImageUrl = "/imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is second element", Price = 79, OldPrice = 99, ImageUrl = "/imgs/placeholders/270x295.svg" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is second element", Price = 79, OldPrice = 99, ImageUrl = "/imgs/placeholders/270x295.svg" },
                }
            },
            ProductTileRowXl = new ProductTileRowXlViewModel
            {
                Items = new List<ItemViewModel>
                {
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is first element", Price = 25, OldPrice = 50, Creator = "Admin", Comments = 2, ImageUrl = "imgs/placeholders/370x295.svg", Description = "Best dress for everyone ed totam velit risus viverra donec recusandae perspiciatis incididuno" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is second element", Price = 79, OldPrice = 99, Creator = "Johon", Comments = 2, ImageUrl = "imgs/placeholders/370x295.svg", Description = "Best dress for everyone ed totam velit risus viverrannobis donec recusandae perspiciatis incididuno" },
                    new ItemViewModel { Id = Guid.NewGuid(), Title = "this is third element", Price = 49, OldPrice = 99, Creator = "Doe", Comments = 2, ImageUrl = "imgs/placeholders/370x295.svg", Description = "Best dress for everyone ed totam velit risus viverranobis donec recusandae perspiciatis incididuno"},
                }
            }

        };
        return View(viewModel);


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
