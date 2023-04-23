using bmerketo_webapp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.ViewModels;

public class CreateUserViewModel
{
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

    [Required(ErrorMessage = "You must enter a password. Minmum length: 8, Atleast 1 upppercase letter")]
    [MinLength(8, ErrorMessage = "You must enter a password. Minmum length: 8, Atleast 1 upppercase letter")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "You must confirm your password.")]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "The passwords do not match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Street Name")]
    public string? StreetName { get; set; }

    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }

    [Display(Name = "City")]
    public string? City { get; set; }

    [Display(Name = "Company")]
    public string? Company { get; set; }

    public static implicit operator IdentityUser(CreateUserViewModel createUserViewModel)
    {
        return new IdentityUser
        {
            UserName = createUserViewModel.Email,
            Email = createUserViewModel.Email,
            PhoneNumber = createUserViewModel.PhoneNumber,
        };
    }

    public static implicit operator UserProfileEntity(CreateUserViewModel createUserViewModel)
    {
        return new UserProfileEntity
        {
            FirstName = createUserViewModel.FirstName,
            LastName = createUserViewModel.LastName,
            Company = createUserViewModel.Company,
            Address = new Models.Entities.AddressEntity
            {
                StreetName = createUserViewModel.StreetName,
                City = createUserViewModel.City,
                PostalCode = createUserViewModel.PostalCode
            }
        };
    }

}