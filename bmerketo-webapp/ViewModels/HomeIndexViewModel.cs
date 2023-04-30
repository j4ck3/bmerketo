namespace bmerketo_webapp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string? Title { get; set; }
        public CollectionsViewModel? BestCollection { get; set; }
        public LandingViewModel? Landing { get; set; }
        public ProductTileGridViewModel? ProductTileGrid { get; set; }
        public ProductTileRowViewModel? ProductTileRow { get; set; }
        public ProductTileRowXlViewModel? ProductTileRowXl { get; set; }
    }
}
