using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

public class SeedData
{
    public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await CreateRoles(roleManager);
        await EnsureUserHasRole(userManager, "user@thebreadpit.be", "User");
        await EnsureUserHasRole(userManager, "employee@thebreadpit.be", "Employee");
        await EnsureUserHasRole(userManager, "admin@thebreadpit.be", "Admin");
    }

    private static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
    {
        await CreateRoleIfNotExists(roleManager, "User");
        await CreateRoleIfNotExists(roleManager, "Employee");
        await CreateRoleIfNotExists(roleManager, "Admin");
    }

    private static async Task CreateRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    private static async Task EnsureUserHasRole(UserManager<IdentityUser> userManager, string userEmail, string roleName)
    {
        var user = await userManager.FindByEmailAsync(userEmail);
        if (user == null)
        {
            user = new IdentityUser { UserName = userEmail, Email = userEmail, EmailConfirmed = true };
            await userManager.CreateAsync(user, "Passw0rd!"); // Gebruik een veiliger wachtwoord in productie!
        }

        if (!await userManager.IsInRoleAsync(user, roleName))
        {
            await userManager.AddToRoleAsync(user, roleName);
        }
    }
}
