using Microsoft.AspNetCore.Mvc;
using The_Bread_Pit.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace The_Bread_Pit.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Employee")]
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
        public IActionResult List(string id = "Alles")
        {
            var categorien = context.Categorien.OrderBy(c => c.CategoryID).ToList();
            IQueryable<Produkt> query = context.Produkten;

            if (id != "Alles")
            {
                if (int.TryParse(id, out int categoryId))
                {
                    query = query.Where(p => p.CategoryID == categoryId);
                }
                else
                {
                    query = query.Where(p => false);
                }
            }

            var produkten = query.OrderBy(x => x.ProductID).ToList();

            var list = new ProduktenLijst
            {
                Produkten = produkten,
                Categorien = categorien,
                SelectedCategory = id
            };

            return View(list);
        }
    }
}