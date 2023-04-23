using bmerketo_webapp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.ViewModels;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "You must enter a Name")]
    [MinLength(2, ErrorMessage = "First Name must be atleast {1} characters in length.")]
    [Display(Name = "Name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid Email")]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company")]
    public string? Company { get; set; }

    [Display(Name = "Message")]
    [Required(ErrorMessage = "You must enter a Message")]
    public string Message { get; set; } = null!;


    public static implicit operator ContactFormEntity(ContactFormViewModel viewModel)
    {
        return new ContactFormEntity
        {
            FirstName = viewModel.FirstName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            Company = viewModel.Company,
            Message = viewModel.Message,
        };
    }
}


