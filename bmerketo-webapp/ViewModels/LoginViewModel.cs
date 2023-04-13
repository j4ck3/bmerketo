using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage = "Password")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public bool RememberMe { get; set; }
}
