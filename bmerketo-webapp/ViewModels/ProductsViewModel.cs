namespace bmerketo_webapp.ViewModels;

public class ProductsViewModel
{
    public string? Title { get; set; }
    public IEnumerable<ItemViewModel>? Items { get; set; }
    public ButtonViewModel? Button { get; set; }
}
