using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.DTOS;
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
}