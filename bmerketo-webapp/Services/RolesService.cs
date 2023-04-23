using Microsoft.AspNetCore.Identity;

namespace bmerketo_webapp.Services;

public class RolesService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RolesService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SeedRoles()
    {
        if (!await _roleManager.RoleExistsAsync("Admin"))
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        if (!await _roleManager.RoleExistsAsync("User"))
            await _roleManager.CreateAsync(new IdentityRole("User"));
    } 
}

