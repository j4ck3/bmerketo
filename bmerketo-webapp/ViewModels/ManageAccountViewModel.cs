using bmerketo_webapp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webapp.ViewModels;

public class ManageAccountViewModel
{
    public string Id { get; set; } = null!;

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

    [MaxLength(6)]
    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }

    [Display(Name = "City")]
    public string? City { get; set; }

    [Display(Name = "Company")]
    public string? Company { get; set; }

    public static implicit operator IdentityUser(ManageAccountViewModel viewModel)
    {
        return new IdentityUser
        {
            Id = viewModel.Id,
            UserName = viewModel.Email,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
        };
    }

    public static implicit operator UserProfileEntity(ManageAccountViewModel viewModel)
    {
        return new UserProfileEntity
        {
            UserId = viewModel.Id,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Company = viewModel.Company,
            Address = new Models.Entities.AddressEntity
            {
                StreetName = viewModel.StreetName,
                City = viewModel.City,
                PostalCode = viewModel.PostalCode
            }
        };
    }
}
