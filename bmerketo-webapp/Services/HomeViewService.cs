using bmerketo_webapp.ViewModels;
namespace bmerketo_webapp.Services;



public class HomeViewService
{
    private readonly ProductService _productService;

    public HomeViewService(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<HomeIndexViewModel> Populate()
    {
        var viewModel = new HomeIndexViewModel
        {
            Title = "Home",
            Landing = new LandingViewModel
            {
                Title = "WELLCOME TO bmarketo SHOP",
                Messgae = "Exclusive Chair gold Collection",
                ImgUrl = "/imgs/placeholders/showcase1.png",
                Button = new ButtonViewModel
                {
                    Content = "shop now",
                    Url = "sale"
                }
            },
            BestCollection = new CollectionsViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },
                //populate categories with real categoris
                GridItems = await _productService.GetAllAsync("Shoes")
            },

            ProductTileGrid = new ProductTileGridViewModel
            {
                Title1 = "UP TO SELL",
                Title2 = "50% OFF",
                Title3 = "Get The Best Price",
                Title4 = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",
                GridItems = await _productService.GetAllAsync("Shoes"),
                Button = new ButtonViewModel
                {
                    Content = "Discover More",
                    Url = "sale"
                },
            },
            ProductTileRow = new ProductTileRowViewModel
            {
                Title = "Top selling products in this week",
                Items = await _productService.GetAllAsync("Jackets"),
            },
            ProductTileRowXl = new ProductTileRowXlViewModel
            {
                Items = await _productService.GetAllAsync("Accessories")
            }
        };
        return viewModel;
    }

}
