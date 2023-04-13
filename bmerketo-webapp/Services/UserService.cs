using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace bmerketo_webapp.Services;

public class UserService
{


    private readonly IdentityContext _identityContext;

    public UserService(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<UserProfileEntity> Get(string UserId)
    {
        var user = await _identityContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == UserId);

        if (user != null)
            return user;
        return null!;
    }
}
