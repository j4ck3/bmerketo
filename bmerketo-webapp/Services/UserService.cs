using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models;
using bmerketo_webapp.Models.Entities;
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

    public async Task<UserProfileEntity> Get(string UserId)
    {
        var user = await _identityContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == UserId);

        if (user != null)
            return user;
        return null!;
    }


    public async Task<List<UserModel>> GetAllAsync()
    {
        var users = new List<UserModel>();

        foreach (var userProfile in await _identityContext.UserProfiles.Include(x => x.User).Include(x => x.Address).ToListAsync())
        {
            var _userRoles = await _userManager.GetRolesAsync(userProfile.User);
            users.Add(new UserModel
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




}