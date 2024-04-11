﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace The_Bread_Pit.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult Index()
        {
            return View();
        }
    }
}