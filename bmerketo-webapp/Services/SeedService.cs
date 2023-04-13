using Microsoft.AspNetCore.Identity;

namespace bmerketo_webapp.Services;

public class SeedService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SeedRoles()
    {
        if (!await _roleManager.RoleExistsAsync("admin"))
            await _roleManager.CreateAsync(new IdentityRole("admin"));
    } 

}
