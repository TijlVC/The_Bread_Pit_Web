using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using The_Bread_Pit.Models;

namespace The_Bread_Pit.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            HttpContext.Session.SetString("Init", "1"); // Zorgt ervoor dat een sessie-ID wordt gegenereerd en bewaard
            return View();
        }

        [Route("action")]
        public IActionResult About()
        {
            return View();
        }

    }
}