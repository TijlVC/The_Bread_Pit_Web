using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Models;
using Microsoft.AspNetCore.Identity;
using The_Bread_Pit.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuratie voor Entity Framework
builder.Services.AddDbContext<TheBreadPitContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TheBreadPitContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false) //deze op fasle zetten om bij userregistratie geen 'bevstiging te moeten sturen)
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

app.UseStatusCodePages();
app.UseAuthentication();;

// Middleware voor autorisatie
app.UseAuthorization();

app.MapAreaControllerRoute(
       name: "Admin",
          areaName: "Admin",
             pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Employee_area",
    areaName: "Employee",
    pattern: "Employee/{controller=BestellingOverzicht}/{action=OpenBestellingen}/{id?}"
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

var scope = app.Services.CreateScope();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
await DbInitializer.InitializeAsync(userManager, roleManager);

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();

// bij eerste keer voer volgende commando's uit in PM-console:
// Add-Migration InitialCreate
// Update-Database