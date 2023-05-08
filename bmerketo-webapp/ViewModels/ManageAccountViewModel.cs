using bmerketo_webapp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.ViewModels;

public class ManageAccountViewModel
{
    public string Id = null!;

    [Required(ErrorMessage = "You must enter a First Name")]
    [MinLength(2, ErrorMessage = "First Name must be atleast {1} characters in length.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a Last Name")]
    [MinLength(2, ErrorMessage = "Last Name must be atleast {1} characters in length.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a valid Email")]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Street Name")]
    public string? StreetName { get; set; }

    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }

    [Display(Name = "City")]
    public string? City { get; set; }

    [Display(Name = "Company")]
    public string? Company { get; set; }

    [Display(Name = "Välj en kategori")]
    [Required(ErrorMessage = "Du måste välja en kategori")]
    public string CategoryId { get; set; } = null!;

    public static implicit operator IdentityUser(ManageAccountViewModel manageUserViewModel)
    {
        return new IdentityUser
        {
            UserName = manageUserViewModel.Email,
            Email = manageUserViewModel.Email,
            PhoneNumber = manageUserViewModel.PhoneNumber,
        };
    }

    public static implicit operator UserProfileEntity(ManageAccountViewModel manageUserViewModel)
    {
        return new UserProfileEntity
        {
            FirstName = manageUserViewModel.FirstName,
            LastName = manageUserViewModel.LastName,
            Company = manageUserViewModel.Company,
            Address = new Models.Entities.AddressEntity
            {
                StreetName = manageUserViewModel.StreetName,
                City = manageUserViewModel.City,
                PostalCode = manageUserViewModel.PostalCode
            }
        };
    }
}
