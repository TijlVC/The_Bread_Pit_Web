using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuratie voor Entity Framework
builder.Services.AddDbContext<TheBreadPitContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TheBreadPitContext")));

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

// Middleware voor sessies; belangrijk om dit vóór app.UseRouting() en na app.UseStaticFiles() te plaatsen
app.UseSession();

// Middleware voor routing
app.UseRouting();

app.UseStatusCodePages();

// Middleware voor autorisatie
app.UseAuthorization();

app.MapAreaControllerRoute(
       name: "Admin",
          areaName: "Admin",
             pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

// Definieer de route voor de MVC controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{url?}");

app.Run();