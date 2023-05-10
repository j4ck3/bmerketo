using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.DTOS;
using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace bmerketo_webapp.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(IdentityContext identityContext, UserManager<IdentityUser> userManager)
    {
        _identityContext = identityContext;
        _userManager = userManager;
    }

    public async Task<UserProfileEntity> GetAsync(string UserId)
    {
        var user = await _identityContext.UserProfiles.Include(x => x.User).Include(x => x.Address).FirstOrDefaultAsync(x => x.UserId == UserId);

        if (user != null)
            return user;
        return null!;
    }


    public async Task<List<User>> GetAllAsync()
    {
        var users = new List<User>();

        foreach (var userProfile in await _identityContext.UserProfiles.Include(x => x.User).Include(x => x.Address).ToListAsync())
        {
            var _userRoles = await _userManager.GetRolesAsync(userProfile.User);
            users.Add(new User
            {
                Id = userProfile.UserId,
                Roles = _userRoles,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Email = userProfile.User.UserName,
                Address = userProfile.Address,
            });
        }

        if (users != null)
            return users;

        return null!;
    }

    public async Task<bool> UpdateUserAsync(ManageAccountViewModel viewModel)
    {
        try
        {
            IdentityUser identityUser = viewModel;
            identityUser.Id = viewModel.Id;
            UserProfileEntity userProfileEntity = viewModel;
            userProfileEntity.UserId = identityUser.Id;

            // ------- Check if address exists. If: assign found addressEntity.Id to userProfile.AddressId  If Not: create a new AddressEntity and later save it to db
            if (viewModel.StreetName != null && viewModel.PostalCode != null && viewModel.City != null)
            {
                var _addressEntity = await _identityContext.Addresses.FirstOrDefaultAsync(x => x.StreetName == viewModel.StreetName && x.PostalCode == viewModel.PostalCode && x.City == viewModel.City);
                if (_addressEntity != null)
                {
                    userProfileEntity.AddressId = _addressEntity.Id;
                    userProfileEntity.Address = null!;
                }
                else
                    userProfileEntity.Address = new Models.Entities.AddressEntity
                    {
                        StreetName = viewModel.StreetName,
                        PostalCode = viewModel.PostalCode,
                        City = viewModel.City
                    };
            }
            else
            {
                userProfileEntity.AddressId = null!;
                userProfileEntity.Address = null!;
            }
            _identityContext.UserProfiles.Update(userProfileEntity);
            await _userManager.UpdateAsync(identityUser);
            await _identityContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }
    }

    public async Task<bool> UpdateUserRolesAsync(IdentityUser user, string[] roles)
    {
        try
        {
            var currentRoles = await _userManager.GetRolesAsync(user);

            // ------ Remove roles that are unchecked
            var rolesToRemove = currentRoles.Except(roles);
            foreach (var role in rolesToRemove)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }

            // ------- Add roles that are checked
            var rolesToAdd = roles.Except(currentRoles);
            foreach (var role in rolesToAdd)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            return true;
        }
        catch { return false; }
    }

}