using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuratie voor Entity Framework
builder.Services.AddDbContext<TheBreadPitContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TheBreadPitContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TheBreadPitContext>();

// Sessie configuratie
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Stel de timeout in
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Voeg HttpContextAccessor toe
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Middleware voor statische bestanden
app.UseStaticFiles();

// Middleware voor sessies; belangrijk om dit v��r app.UseRouting() en na app.UseStaticFiles() te plaatsen
app.UseSession();

// Middleware voor routing
app.UseRouting();

app.UseStatusCodePages();
app.UseAuthentication();

// Middleware voor autorisatie
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin_area",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapAreaControllerRoute(
    name: "Employee_area",
    areaName: "Employee",
    pattern: "Employee/{controller=Home}/{action=Index}/{id?}"
);

app.MapAreaControllerRoute(
    name: "User_area",
    areaName: "User",
    pattern: "User/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{url?}"
);

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

await SeedDatabaseAsync(app.Services);

app.Run();

async Task SeedDatabaseAsync(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await SeedData.InitializeAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        // Log de fout. In een productie-app zou je waarschijnlijk wat robuustere foutafhandeling willen doen.
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Een fout opgetreden tijdens het aanmaken van rollen en gebruikers.");
    }
}

