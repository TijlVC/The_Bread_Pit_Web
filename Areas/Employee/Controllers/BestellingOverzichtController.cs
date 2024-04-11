using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheBreadPit.Areas.Employee.Models;
using System.Linq;
using System.Threading.Tasks;
using The_Bread_Pit.Models;
using Microsoft.AspNetCore.Authorization;

namespace TheBreadPit.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Employee")]
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
            else if (statusFilter == "nietAfgerond")
            {
                bestellingenQuery = bestellingenQuery.Where(b => !b.IsAfgerond);
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

        public async Task<IActionResult> OpenBestellingen()
        {
            var openBestellingen = await _context.Bestellingen
                .Where(b => !b.IsAfgerond)
                .Include(b => b.Items).ThenInclude(i => i.Produkt)
                .ToListAsync();

            var productSamenvatting = openBestellingen
                .SelectMany(b => b.Items)
                .GroupBy(i => i.Produkt.ProduktNaam)
                .Select(group => new ProductSamenvatting
                {
                    ProduktNaam = group.Key,
                    Aantal = group.Sum(i => i.Aantal),
                    PrijsPerStuk = group.First().PrijsPerStuk
                }).ToList();

            var viewModel = new BestellingOverzichtViewModel
            {
                Producten = productSamenvatting,
                TotalePrijs = productSamenvatting.Sum(p => p.Subtotaal)
            };

            return View("OpenBestellingen", viewModel);
        }

        public async Task<IActionResult> AfgerondeBestellingen()
        {
            // Logica om alleen producten uit afgeronde bestellingen te halen
            var afgerondeSamenvatting = await _context.BestelItems
                .Where(bi => bi.Bestelling.IsAfgerond) // Filter op afgeronde bestellingen
                .Include(bi => bi.Produkt)
                .GroupBy(bi => bi.Produkt.ProduktNaam)
                .Select(group => new ProductSamenvatting
                {
                    ProduktNaam = group.Key,
                    Aantal = group.Sum(bi => bi.Aantal),
                    PrijsPerStuk = group.Select(bi => bi.PrijsPerStuk).FirstOrDefault()
                })
                .ToListAsync();

            var viewModel = new BestellingOverzichtViewModel
            {
                Producten = afgerondeSamenvatting,
                TotalePrijs = afgerondeSamenvatting.Sum(p => p.Subtotaal)
            };

            return View("AfgerondeBestellingen", viewModel); // Zorg ervoor dat de viewnaam overeenkomt
        }
    }
}
