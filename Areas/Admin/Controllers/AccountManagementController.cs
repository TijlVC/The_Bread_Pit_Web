using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Areas.Admin.Models;
using System.Threading.Tasks;
using System.Diagnostics;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AccountManagementController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountManagementController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Personeel()
    {
        var adminUsers = (await _userManager.GetUsersInRoleAsync("Admin")).ToList();
        var employeeUsers = (await _userManager.GetUsersInRoleAsync("Employee")).ToList();

        var model = new UserManagementViewModel
        {
            Admins = adminUsers,
            Employees = employeeUsers,
            Roles = (await _roleManager.Roles.ToListAsync())
        };

        return View(model);
    }

    public async Task<IActionResult> Klanten()
    {
        // Haal alle gebruikers op
        var allUsers = await _userManager.Users.ToListAsync();

        // Filter de onbevestigde gebruikers
        var unconfirmedUsers = allUsers.Where(u => !u.EmailConfirmed).ToList();

        // Haal de bevestigde gebruikers op die geen admin of employee zijn
        var confirmedUsers = new List<IdentityUser>();
        foreach (var user in allUsers)
        {
            if (user.EmailConfirmed)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Contains("Admin") && !roles.Contains("Employee"))
                {
                    confirmedUsers.Add(user);
                }
            }
        }

        var model = new UserManagementViewModel
        {
            UnconfirmedUsers = unconfirmedUsers,
            Users = confirmedUsers, // Dit zijn nu alleen de bevestigde 'User' rollen
            Roles = (await _roleManager.Roles.ToListAsync())
        };

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> CreateUser(string email, string password, string role)
    {
        var user = new IdentityUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, role);
            // Redirect of toon succesbericht
        }
        else
        {
            // Toon foutberichten
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(string email, string password, string role)
    {
        var user = new IdentityUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, role);
            return RedirectToAction(nameof(Personeel));
        }
        // Foutafhandeling
        return View();
    }

    
    [HttpPost]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                // Redirect of toon succesbericht
                return RedirectToAction(nameof(Klanten));
            }
            else
            {
                // Toon foutberichten
            }
        }
        return RedirectToAction(nameof(Klanten));
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"Gebruiker met ID '{userId}' niet gevonden.");
        }

        if (!user.EmailConfirmed)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
            {
                // Log de fouten of toon ze aan de gebruiker
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        // Als alles succesvol was, toon dan de bevestigingspagina
        return View();
    }

    public IActionResult PersoneelWachtwoordReset()
    {
        return View();
    }

    public IActionResult KlantenWachtwoordReset()
    {
        return View();
    }
    
}

