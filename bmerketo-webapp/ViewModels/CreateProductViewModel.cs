using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.ViewModels
{
    public class CreateProductViewModel
    {
        public string Id = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Du måste ange ett namn")]
        [MinLength(2, ErrorMessage = "Namnet måsta vara minst {1} bokstäver långt.")]
        [Display(Name = "Produkt namn")]
        public string Name { get; set; } = null!;

        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Du måste ange ett pris")]
        [Range(typeof(decimal), "1", "100000", ErrorMessage = "Ange ett giltigt pris mellan 1 och 100000")]
        [Display(Name = "Pris")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Rabatterat pris")]
        [DataType(DataType.Currency)]
        public decimal? OldPrice { get; set; }

        //[Display(Name = "Välj minst en kategori")]
        //public string? Stock { get; set; }

    }
}
