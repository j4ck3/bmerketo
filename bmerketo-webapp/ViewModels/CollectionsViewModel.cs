using bmerketo_webapp.Models.Schemas;

namespace bmerketo_webapp.ViewModels
{
    public class CollectionsViewModel
    {
        public string? Title { get; set; }
        public IEnumerable<ProductCategorySchema>? Categories { get; set; }
        public IEnumerable<ItemViewModel>? GridItems { get; set; } = null!;
        public bool LoadMore { get; set; } = false;
    }
}
