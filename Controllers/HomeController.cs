using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using The_Bread_Pit.Models;

namespace The_Bread_Pit.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            // Zorgt ervoor dat een sessie-ID wordt gegenereerd en bewaard
            HttpContext.Session.SetString("Init", "1"); 
            return View();
        }

        [Route("action")]
        public IActionResult About()
        {
            return View();
        }

    }
}