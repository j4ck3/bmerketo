namespace bmerketo_webapp.ViewModels
{
    public class ItemViewModel
    {
        public string? Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }
        

        public string? Creator { get; set; }
        public int? Comments { get; set; }
        public string? Description { get; set; }
        public ButtonViewModel? Button { get; set; }
    }
}
