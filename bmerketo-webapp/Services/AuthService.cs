using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace bmerketo_webapp.Services;

public class AuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IdentityContext _identityContext;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RolesService _rolesService;

    public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, RolesService seedService)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
        _rolesService = seedService;
    }

    public async Task<bool> RegisterAsync(CreateUserViewModel model)
    {
        try
        {
            // ------- Init roles, Create user and give user a role
            await _rolesService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            IdentityUser identityUser = model;
            await _userManager.CreateAsync(identityUser, model.Password);
            await _userManager.AddToRoleAsync(identityUser, roleName);


            // ------- Sets userProfileEntity.UserId from identityUser Id
            UserProfileEntity userProfileEntity = model;
            userProfileEntity.UserId = identityUser.Id;


            // ------- Check if address exists. If: assign found addressEntity.Id to userProfile.AddressId  If Not: create a new AddressEntity and later save it to db
            if (model.StreetName != null && model.PostalCode != null && model.City != null)
            {
                var _addressEntity = await _identityContext.Addresses.FirstOrDefaultAsync(x => x.StreetName == model.StreetName && x.PostalCode == model.PostalCode && x.City == model.City);
                if (_addressEntity != null)
                {
                    userProfileEntity.AddressId = _addressEntity.Id;
                    userProfileEntity.Address = null!;
                }
                else
                    userProfileEntity.Address = new Models.Entities.AddressEntity
                    {
                        StreetName = model.StreetName,
                        PostalCode = model.PostalCode,
                        City = model.City
                    };
            }
            else
            {
                userProfileEntity.AddressId = null!;
                userProfileEntity.Address = null!;
            }

            // ------- Save UserProfile
            _identityContext.UserProfiles.Add(userProfileEntity);
            await _identityContext.SaveChangesAsync();

            return true;
        }
        catch { return false; }
    }

    public async Task<bool> FindAsync(CreateUserViewModel model)
    {
        var _user = await _userManager.FindByEmailAsync(model.Email);

        if (_user != null)
            return true;
        return false;
    }

    public async Task<bool> SignInAsync(LoginViewModel model)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result.Succeeded;
        }
        catch { return false; }
    }

    public async Task<bool> SignOutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();
        return _signInManager.IsSignedIn(user);
    }
}
