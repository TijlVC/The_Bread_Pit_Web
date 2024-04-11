using Microsoft.AspNetCore.Mvc;
using The_Bread_Pit.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace The_Bread_Pit.Controllers
{
        public class WinkelmandjeController : Controller
    {
        private readonly TheBreadPitContext _context;

        public WinkelmandjeController(TheBreadPitContext context)
        {
            _context = context;
        }

        public IActionResult Toevoegen(int productId)
        {
            var product = _context.Produkten.Find(productId);
            if (product != null)
            {
                //var sessieId = HttpContext.Session.Id;
                var sessieId = "0";
                var bestaandItem = _context.WinkelmandjeItems
                    .FirstOrDefault(w => w.Produkt.ProductID == productId && w.SessieId == sessieId);

                if (bestaandItem == null)
                {
                    var winkelmandjeItem = new WinkelmandjeItem
                    {
                        Produkt = product,
                        Aantal = 1,
                        SessieId = sessieId
                    };
                    _context.WinkelmandjeItems.Add(winkelmandjeItem);
                }
                else
                {
                    bestaandItem.Aantal++;
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(string action, int itemId)
        {
            var item = _context.WinkelmandjeItems.Find(itemId);
            if (item != null)
            {
                if (action == "plus")
                    item.Aantal++;
                else if (action == "minus" && item.Aantal > 1)
                    item.Aantal--;

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Verwijder(int itemId)
        {
            var item = _context.WinkelmandjeItems.Find(itemId);
            if (item != null)
            {
                _context.WinkelmandjeItems.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            //var sessieId = HttpContext.Session.Id;
            var sessieId = "0";
            var winkelmandjeItems = _context.WinkelmandjeItems
                .Include(w => w.Produkt) // toegevoegd
                .Where(w => w.SessieId == sessieId)
                .ToList();

            return View(winkelmandjeItems);
        }

    }
}