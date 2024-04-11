using Microsoft.AspNetCore.Mvc;
using The_Bread_Pit.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace The_Bread_Pit.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ProduktController : Controller
    {
        private TheBreadPitContext context;

        public ProduktController(TheBreadPitContext context)
        {
            this.context = context;
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

            string imageFileName = produkt?.Omschrijving + "-m.jpg";
            ViewBag.CategoryName = categoryNaam;
            ViewBag.ImageFileName = imageFileName;

            return View(produkt);
        }

        [Route("[area]/Categorien/{id?}")]
        public IActionResult List(int? id) // Let op dat we nu een nullable int accepteren
        {
            var categorien = context.Categorien.OrderBy(c => c.CategoryID).ToList();
            IQueryable<Produkt> query = context.Produkten;

            if (id.HasValue) // Als er een ID is opgegeven
            {
                query = query.Where(p => p.CategoryID == id.Value);
            }
            else
            {
                query = query.Where(p => true); // Als er geen ID is, toon alle producten
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