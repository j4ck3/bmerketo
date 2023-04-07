namespace bmerketo_webapp.ViewModels
{
    public class CollectionsViewModel
    {
        public string? Title { get; set; }
        public IEnumerable<string>? Categories { get; set; }
        public IEnumerable<ItemViewModel> GridItems { get; set; } = null!;
        public bool LoadMore { get; set; } = false;
    }
}
