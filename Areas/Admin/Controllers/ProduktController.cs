using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using The_Bread_Pit.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace The_Bread_Pit.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProduktController : Controller
    {
        private TheBreadPitContext _context;
        private IWebHostEnvironment _environment;

        public ProduktController(TheBreadPitContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
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
                    // Als het ophalen van de lijst met produkten niet lukt worden er geen producten getoond.
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
        public async Task<IActionResult> Add(Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                if (produkt.File != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "Produkten");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + produkt.File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await produkt.File.CopyToAsync(fileStream);
                    }
                    produkt.ImagePath = uniqueFileName;
                }
                else
                {
                    produkt.ImagePath = "TheBreadPit.jpg"; // Standaard afbeelding als de specifieke niet bestaat
                }

                _context.Produkten.Add(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
            ViewBag.Categorieen = _context.Categorien.ToList();
            return View(produkt);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produkt = _context.Produkten.Find(id);
            if (produkt == null)
            {
                return NotFound();
            }

            string fileName = $"{produkt.ProduktNaam.Replace(" ", "").Replace("/", "-")}.jpeg";
            string physicalPath = Path.Combine(_environment.WebRootPath, "images", "Produkten", fileName);
            if (!System.IO.File.Exists(physicalPath))
            {
                fileName = "thebreadpit.jpeg";
            }

            ViewBag.ImagePath = $"/images/Produkten/{fileName}";
            ViewBag.Categorieen = _context.Categorien.ToList();

            return View(produkt);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                if (produkt.File != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "Produkten");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + produkt.File.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await produkt.File.CopyToAsync(fileStream);
                    }
                    produkt.ImagePath = uniqueFileName;
                }

                _context.Update(produkt);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }
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
        public IActionResult DeleteConfirmed(int id)
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
