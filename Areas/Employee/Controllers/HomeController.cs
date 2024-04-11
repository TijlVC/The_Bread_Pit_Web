using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace The_Bread_Pit.Areas.Employee.Controllers
{
    public class HomeController : Controller
    {
        [Area("Employee")]
        [Authorize(Roles = "Employee")]
        public IActionResult Index()
        {
            return View();
        }            
    }
}