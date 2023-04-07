namespace bmerketo_webapp.ViewModels
{
    public class ProductTileGridViewModel
    {
        public IEnumerable<ItemViewModel>? GridItems { get; set; }
        public string? Title1 { get; set; }
        public string? Title2 { get; set; }
        public string? Title3 { get; set; }
        public string? Title4 { get; set; }
        public ButtonViewModel? Button { get; set;}
    }
}
