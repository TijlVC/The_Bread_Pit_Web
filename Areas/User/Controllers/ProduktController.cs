using Microsoft.AspNetCore.Mvc;
using The_Bread_Pit.Models;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System;

namespace The_Bread_Pit.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ProduktController : Controller
    {
        private TheBreadPitContext context;
        private IWebHostEnvironment? _environment;


        public ProduktController(TheBreadPitContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var categorien = context.Categorien.OrderBy(x => x.CategoryID).ToList();
            Produkt? produkt = context.Produkten.Find(id);
            var categoryNaam = "";

            foreach (var category in categorien)
            {
                if (category.CategoryID == produkt?.CategoryID)
                {
                    categoryNaam = category.CategorieNaam;
                }
            }

            string fileName = $"{produkt?.ProduktNaam.Replace(" ", "")}.jpeg";
            string webImagePath = $"/images/Produkten/{fileName}";

            string physicalPath = Path.Combine(_environment.WebRootPath, "images", "Produkten", fileName);
            if (!System.IO.File.Exists(physicalPath))
            {
                webImagePath = "/images/Produkten/thebreadpit.jpeg"; 
            }

            ViewBag.ImagePath = webImagePath;

            return View(produkt);
        }


        [Route("[area]/Categorien/{id?}")]
        public IActionResult List(int? id) 
        {
            var categorien = context.Categorien.OrderBy(c => c.CategoryID).ToList();
            IQueryable<Produkt> query = context.Produkten;

            if (id.HasValue)
            {
                query = query.Where(p => p.CategoryID == id.Value);
            }
            else
            {
                query = query.Where(p => true); 
            }

            var produkten = query.OrderBy(x => x.ProductID).ToList();

            var list = new ProduktenLijst
            {
                Produkten = produkten,
                Categorien = categorien,
                SelectedCategory = id.HasValue ? categorien.FirstOrDefault(c => c.CategoryID == id.Value)?.CategorieNaam : "Alles"
            };

            return View(list);
        }
    }
}