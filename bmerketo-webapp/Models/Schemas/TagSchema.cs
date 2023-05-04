using bmerketo_webapp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.Models.Schemas;

public class TagSchema
{
    [Required(ErrorMessage = "This field is required")]
    [MinLength(2, ErrorMessage = "Tag Name must be atleast {1} characters in length.")]
    [Display(Name = "Tag Name")]
    public string Name { get; set; } = null!;


    public static implicit operator TagEntity(TagSchema schema)
    {
        return new TagEntity
        {
            Name = schema.Name,
        };
    }
}
