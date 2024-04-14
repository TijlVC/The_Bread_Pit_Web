using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Models;
using Microsoft.AspNetCore.Identity;
using The_Bread_Pit.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// configure logging
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "nl-NL", "en-US", "fr-FR" }; 
    options.DefaultRequestCulture = new RequestCulture("nl-NL"); 
    options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuration for the database
builder.Services.AddDbContext<TheBreadPitContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TheBreadPitContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true) //deze op fasle zetten om bij userregistratie geen bevestiging te moeten doen
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TheBreadPitContext>();

// Session configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddHostedService<Purge>();

var app = builder.Build();


app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseRequestLocalization();

app.UseStatusCodePages();
app.UseAuthentication();;

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{url?}");

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;


    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await DbInitializer.InitializeAsync(userManager, roleManager);


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
