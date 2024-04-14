using Microsoft.AspNetCore.Mvc;
using The_Bread_Pit.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace The_Bread_Pit.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class WinkelmandjeController : Controller
    {
        private readonly TheBreadPitContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public WinkelmandjeController(TheBreadPitContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("[area]/Winkelmandje/Toevoegen/{productId}")]
        public async Task<IActionResult> Toevoegen(int productId)
        {
            var product = _context.Produkten.Find(productId);
            if (product != null)
            {
                
                var user = await _userManager.GetUserAsync(User);
                var userId = user?.Id; // Dit zou de ID van de ingelogde gebruiker moeten zijn

                var bestaandItem = _context.WinkelmandjeItems
                    .FirstOrDefault(w => w.Produkt.ProductID == productId && w.UserId == userId);

                if (bestaandItem == null)
                {
                    var winkelmandjeItem = new WinkelmandjeItem
                    {
                        Produkt = product,
                        Aantal = 1,
                        UserId = userId, // Set de UserId hier
                        BestellingId = null
                    };
                    _context.WinkelmandjeItems.Add(winkelmandjeItem);
                }
                else
                {
                    bestaandItem.Aantal++;
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(string action, int itemId)
        {
            var item = await _context.WinkelmandjeItems.FindAsync(itemId);
            if (item != null)
            {
                if (action == "plus")
                    item.Aantal++;
                else if (action == "minus" && item.Aantal > 1)
                    item.Aantal--;

                await _context.SaveChangesAsync();
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

        public async Task<IActionResult> Index()
        {
            // Verkrijg de UserId van de huidige ingelogde gebruiker
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;

            var winkelmandjeItems = _context.WinkelmandjeItems
                .Include(w => w.Produkt)
                .Where(w => w.UserId == userId) // Gebruik UserId om de items op te halen
                .ToList();

            return View(winkelmandjeItems);
        }

    }
}