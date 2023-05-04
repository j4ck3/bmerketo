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

        var roles = await UserManager.GetRolesAsync(user);
        claimsIdentity.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));

        var userProfileEntity = await _userService.GetAsync(user.Id);

        claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName} {userProfileEntity.LastName}"));
        claimsIdentity.AddClaim(new Claim("Id", userProfileEntity.UserId));

        return claimsIdentity;
    }
}
    