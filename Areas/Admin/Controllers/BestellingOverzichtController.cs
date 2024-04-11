using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheBreadPit.Areas.Admin.Models;
using System.Linq;
using System.Threading.Tasks;
using The_Bread_Pit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheBreadPit.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BestellingOverzichtController : Controller
    {
        private readonly TheBreadPitContext _context;

        public BestellingOverzichtController(TheBreadPitContext context)
        {
            _context = context;
        }

        // Geeft een overzicht van alle bestellingen
        public async Task<IActionResult> OverzichtBestellingen(string searchQuery, string statusFilter)
        {
            ViewData["CurrentFilter"] = searchQuery;

            var bestellingenQuery = _context.Bestellingen.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                bestellingenQuery = bestellingenQuery.Where(b => b.User.UserName.Contains(searchQuery));
            }

            if (statusFilter == "afgerond")
            {
                bestellingenQuery = bestellingenQuery.Where(b => b.IsAfgerond);
            }
            if (statusFilter == "nietAfgerond")
            {
                bestellingenQuery = bestellingenQuery.Where(b => !b.IsAfgerond);
            }
            if (statusFilter == "geannuleerd")
            {
                bestellingenQuery = bestellingenQuery.Where(b => b.IsGeannuleerd);
            }

            var bestellingen = await bestellingenQuery
                .Include(b => b.User)
                        .Select(b => new BestellingDetail
                {
                    BestellingId = b.BestellingId,
                    GebruikersNaam = b.User.UserName,  // Gebruik UserId als UserName niet direct beschikbaar is
                    BestelDatum = b.BestelDatum,
                    TotaalPrijs = b.Items.Sum(i => i.Aantal * i.PrijsPerStuk),
                    IsAfgerond = b.IsAfgerond
                })
                .ToListAsync();

            return View("OverzichtBestellingen", bestellingen);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int bestellingId)
        {
            var bestelling = await _context.Bestellingen.FindAsync(bestellingId);
            if (bestelling != null)
            {
                bestelling.IsAfgerond = !bestelling.IsAfgerond;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("OverzichtBestellingen");
        }

        [HttpPost]
        public async Task<IActionResult> AnnuleerBestelling(int bestellingId)
        {
            var bestelling = await _context.Bestellingen.FindAsync(bestellingId);
            if (bestelling != null)
            {
                bestelling.IsGeannuleerd = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("OverzichtBestellingen");
        }

        [HttpPost]
        public async Task<IActionResult> VerwijderGeselecteerdeBestellingen(List<int> selectedBestellingen)
        {
            var bestellingen = _context.Bestellingen.Where(b => selectedBestellingen.Contains(b.BestellingId));
            _context.Bestellingen.RemoveRange(bestellingen);
            await _context.SaveChangesAsync();

            return RedirectToAction("OverzichtBestellingen");
        }

        public async Task<IActionResult> Details(int Id)
        {
            var bestelling = await _context.Bestellingen
                .Include(b => b.Items)
                .ThenInclude(i => i.Produkt)
                .FirstOrDefaultAsync(b => b.BestellingId == Id);

            if (bestelling == null)
            {
                return NotFound();
            }

            ViewBag.Producten = new SelectList(await _context.Produkten.ToListAsync(), "ProductID", "ProduktNaam");

            return View(bestelling);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateItemAantal(int id, int nieuwAantal)
        {
            var item = await _context.BestelItems.FindAsync(id);
            if (item != null)
            {
                item.Aantal = nieuwAantal;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", new { id = item.BestellingId }); // Terug naar details
        }

        [HttpPost]
        public async Task<IActionResult> VoegProductToe(int bestellingId, int productId, int aantal)
        {
            var product = await _context.Produkten.FindAsync(productId);
            if (product != null)
            {
                var bestelItem = new BestelItem
                {
                    BestellingId = bestellingId,
                    ProduktProductID = productId,
                    Aantal = aantal,
                    PrijsPerStuk = product.Prijs // Aannemende dat 'Prijs' een veld is van 'Produkt'
                };

                _context.BestelItems.Add(bestelItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", new { id = bestellingId });
        }
    }
}
