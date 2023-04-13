using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace bmerketo_webapp.Services;

public class CustomClaimsService : UserClaimsPrincipalFactory<IdentityUser>
{

    private readonly UserService _userService;
    public CustomClaimsService(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService) : base(userManager, optionsAccessor)
    {
        _userService = userService;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
    {

        var claimsIdentity = await base.GenerateClaimsAsync(user);

        var userProfileEntity = await _userService.Get(user.Id);

        claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FistName} {userProfileEntity.LastName}"));

        return claimsIdentity;
    }
}
    