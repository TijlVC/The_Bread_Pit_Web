using Microsoft.AspNetCore.Mvc;
using The_Bread_Pit.Models;
using System.Linq;

namespace The_Bread_Pit.Controllers
{
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

        [Route("Categorien/{id?}")]
        //[Route("[controller]s/{id}/")]
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
                    // Als de conversie faalt, toon dan mogelijk geen producten of handel anderszins af
                    // Deze regel zorgt ervoor dat wanneer het ID niet overeenkomt met een bestaande categorie,
                    // er geen producten worden teruggegeven.
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