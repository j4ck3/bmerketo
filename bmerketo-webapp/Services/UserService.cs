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

    public async Task<bool> UpdateUserAsync(ManageAccountViewModel viewModel, string[] roles)
    {
        if (await UpdateUserIdentityAsync(viewModel))
            if (await UpdateUserRolesAsync(viewModel, roles))
            {

                UserProfileEntity userProfileEntity = viewModel;
                var _addressEntity = await UserProfileAddress(viewModel);
                if (_addressEntity != null)
                {
                    if (_addressEntity.StreetName != null && _addressEntity.PostalCode != null && _addressEntity.City != null)
                    {
                        userProfileEntity.Address = _addressEntity;
                        userProfileEntity.AddressId = null!;
                    }
                    else
                    {
                        userProfileEntity.AddressId = _addressEntity.Id!;
                        userProfileEntity.Address = null!;
                    }
                }
                else
                {
                    userProfileEntity.Address = null!;
                    userProfileEntity.AddressId = null!;
                }
                  


                var result = await UpdateUserProfileAsync(userProfileEntity);

                if(result != null)
                    return true;
            }
        return false; 
    }

    public async Task<UserProfileEntity> UpdateUserProfileAsync(UserProfileEntity entity)
    {
        try
        {
            _identityContext.Update(entity);
            await _identityContext.SaveChangesAsync();
            return entity;
        }
        catch { return null!; }
    }

    public async Task<bool> UpdateUserIdentityAsync(ManageAccountViewModel viewModel)
    {
        try {
            var user = await _userManager.FindByIdAsync(viewModel.Id);
            user.Email = viewModel.Email;
            user.UserName = viewModel.Email;
            user.PhoneNumber = viewModel.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                 return true;
            

            return false;
            
        }
        catch { return false; }
    }

    public async Task<AddressEntity> UserProfileAddress(ManageAccountViewModel viewModel)
    {
        if (viewModel.StreetName != null && viewModel.PostalCode != null && viewModel.City != null)
        {
            AddressEntity addressEntity = new();

            var _addressEntity = await _identityContext.Addresses.FirstOrDefaultAsync(x => x.StreetName == viewModel.StreetName && x.PostalCode == viewModel.PostalCode && x.City == viewModel.City);
            if (_addressEntity != null)
            {
                addressEntity.Id = _addressEntity.Id;
                return addressEntity;
            }
            else
            {
                addressEntity.PostalCode = viewModel.PostalCode;
                addressEntity.City = viewModel.City;
                addressEntity.StreetName = viewModel.StreetName;
                return addressEntity;
            }
        }
        return null!;
    }

    public async Task<bool> UpdateUserRolesAsync(ManageAccountViewModel viewModel, string[] roles)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(viewModel.Id);
            if (user != null)
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
            else { return false; }
        }
        catch { return false; }
    }



}