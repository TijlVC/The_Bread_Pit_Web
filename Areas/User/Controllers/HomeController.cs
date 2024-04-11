using Microsoft.AspNetCore.Mvc;

namespace The_Bread_Pit.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}