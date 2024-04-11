using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using The_Bread_Pit.Models;
using System.Linq;

namespace The_Bread_Pit.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProduktController : Controller
    {
        private readonly TheBreadPitContext _context;

        public ProduktController(TheBreadPitContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[area]/Categorien/{id?}")]
        //[Route("[controller]s/{id}/")]
        public IActionResult List(string id = "Alles")
        {
            var categorien = _context.Categorien.OrderBy(c => c.CategoryID).ToList();
            IQueryable<Produkt> query = _context.Produkten;

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

        [HttpGet]
        public IActionResult Add(int? id)
        {
                     
            // Ophalen van alle categorieën uit de database
            ViewBag.Categorieen = _context.Categorien.ToList();


            if (id.HasValue)
            {
                var produkt = _context.Produkten.Find(id.Value);
                if (produkt != null)
                {
                    return View(produkt);
                }
            }

            return View(new Produkt());
        }

        [HttpPost]
        public IActionResult Add(Produkt produkt) // POST voor zowel Add als Edit
        {


            if (ModelState.IsValid)
            {
                _context.Produkten.Add(produkt);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(produkt);
        }

        [HttpGet]
        public IActionResult Edit(int? id) // Gecombineerd Add en Edit in één actie
        {

            // Ophalen van alle categorieën uit de database en instellen in de ViewBag voorafgaand aan andere logica
            ViewBag.Categorieen = _context.Categorien.ToList();

            if (id.HasValue)
            {
                var produkt = _context.Produkten.Find(id.Value);
                if (produkt != null)
                {
                    // Als het product bestaat, stuur het naar de view
                    return View(produkt);
                }
            }

            // Als er geen id is opgegeven of het product niet gevonden kan worden, stuur dan een nieuw product naar de view
            // Nu met de zekerheid dat ViewBag.Categorieen is ingesteld
            return View(new Produkt());
        }


        [HttpPost]
        public IActionResult Edit(Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                _context.Produkten.Update(produkt);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            // Er zijn fouten in het model
            ViewBag.Categorieen = _context.Categorien.ToList();
            return View(produkt);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produkt = _context.Produkten.Find(id);
            if (produkt != null)
            {
                return View(produkt);
            }
            return View("~/Areas/Admin/Views/Produkt/Delete.cshtml", produkt);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id) // Om naamgevingsconflicten te voorkomen
        {
            var produkt = _context.Produkten.Find(id);
            if (produkt != null)
            {
                _context.Produkten.Remove(produkt);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }

}
