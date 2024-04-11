using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace The_Bread_Pit.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        [Area("User")]
        [Authorize(Policy = "RequireUserRole")]
        public IActionResult Index()
        {
            return View();
        }            
    }
}