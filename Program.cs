using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Models;
using Microsoft.AspNetCore.Identity;
using The_Bread_Pit.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Configureer de verzoekcultuur
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "nl-NL", "en-US", "fr-FR" }; // Voeg andere ondersteunde culturen toe
    options.DefaultRequestCulture = new RequestCulture("nl-NL"); // Stel de standaardcultuur in
    options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuratie voor Entity Framework
builder.Services.AddDbContext<TheBreadPitContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TheBreadPitContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true) //deze op fasle zetten om bij userregistratie geen bevestiging te moeten doen)
    .AddRoles<IdentityRole>()
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

// Gebruik verzoeklokalisatie
app.UseRequestLocalization();

app.UseStatusCodePages();
app.UseAuthentication();;

// Middleware voor autorisatie
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin_area",
    areaName: "Admin",
    pattern: "Admin/{controller=Produkt}/{action=List}/{id?}"
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

// Definieer de route voor de MVC controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{url?}");

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    // Hier voer je de DbInitializer uit als die er is
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await DbInitializer.InitializeAsync(userManager, roleManager);

    // Hier controleer en creëer je de rol 'User' als deze niet bestaat
    if (!await roleManager.RoleExistsAsync("User"))
    {
        var role = new IdentityRole("User");
        await roleManager.CreateAsync(role);
    }
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();

// bij eerste keer voer volgende commando's uit in PM-console:
// Add-Migration InitialCreate
// Update-Database