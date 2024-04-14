using Microsoft.AspNetCore.Mvc;
using The_Bread_Pit.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Models;

namespace The_Bread_Pit.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class BestellingController : Controller
    {
        private readonly TheBreadPitContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BestellingController(TheBreadPitContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PlaatsBestelling()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;

            // Start een nieuwe bestelling
            var bestelling = new Bestelling
            {
                UserId = userId,
                BestelDatum = DateTime.Now,
                Items = new List<BestelItem>(),
                IsAfgerond = false
            };

            // Haal de winkelmandje items op voor de gebruiker
            var winkelmandjeItems = _context.WinkelmandjeItems
                .Where(w => w.UserId == userId)
                .Include(w => w.Produkt)
                .ToList();

            // Kopieer de items naar de bestelling
            foreach (var winkelmandjeItem in winkelmandjeItems)
            {
                var bestelItem = new BestelItem
                {
                    ProduktProductID = winkelmandjeItem.Produkt.ProductID,
                    Aantal = winkelmandjeItem.Aantal,
                    PrijsPerStuk = winkelmandjeItem.Produkt.Prijs
                };

                bestelling.Items.Add(bestelItem);
                _context.WinkelmandjeItems.Remove(winkelmandjeItem);
            }

            _context.Bestellingen.Add(bestelling);
            await _context.SaveChangesAsync();

            // Redirect naar de overzicht pagina die nu de bestelling zal tonen
            return RedirectToAction("Overzicht", new { bestellingId = bestelling.BestellingId });
        }

        public async Task<IActionResult> Overzicht(int bestellingId)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            var bestelling = await _context.Bestellingen
                .Include(b => b.Items)
                .ThenInclude(i => i.Produkt)
                .FirstOrDefaultAsync(b => b.BestellingId == bestellingId);

            if (bestelling == null)
            {
                return View("LegeBestelling");
            }

            var viewModel = new BestellingViewModel
            {
                BestellingId = bestelling.BestellingId,
                GebruikerNaam = user.UserName, // Haal de username van de huidige gebruiker
                BestelDatum = bestelling.BestelDatum,
                Items = bestelling.Items.Select(i => new WinkelmandjeItemViewModel
                {
                    ProductId = i.ProduktProductID,
                    ProductNaam = i.Produkt.ProduktNaam,
                    Aantal = i.Aantal,
                    Prijs = i.PrijsPerStuk
                }).ToList(),
                TotaalPrijs = bestelling.Items.Sum(i => i.Aantal * i.PrijsPerStuk),
                IsBetaald = bestelling.IsBetaald,
                IsGeannuleerd = bestelling.IsGeannuleerd
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> MarkeerAlsBetaald(int bestellingId)
        {
            var bestelling = await _context.Bestellingen.FindAsync(bestellingId);
            if (bestelling != null && !bestelling.IsGeannuleerd)
            {
                bestelling.IsBetaald = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("BetaaldBevestiging");
        }

        [HttpPost]
        public async Task<IActionResult> AnnuleerBestelling(int bestellingId)
        {
            var bestelling = await _context.Bestellingen.FindAsync(bestellingId);
            if (bestelling != null && !bestelling.IsBetaald)
            {
                bestelling.IsGeannuleerd = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GeannuleerdBevestiging");
        }

        public IActionResult BetaaldBevestiging()
        {
            return View();
        }

        public IActionResult GeannuleerdBevestiging()
        {
            return View();
        }

        public async Task<IActionResult> MijnBestellingen(string filter = "")
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;

            IQueryable<Bestelling> query = _context.Bestellingen
                                                    .Include(b => b.Items)
                                                        .ThenInclude(i => i.Produkt)
                                                    .Where(b => b.UserId == userId);

            switch (filter)
            {
                case "betaald":
                    query = query.Where(b => b.IsBetaald);
                    break;
                case "geannuleerd":
                    query = query.Where(b => b.IsGeannuleerd);
                    break;
                case "afgerond":
                    query = query.Where(b => b.IsAfgerond);
                    break;
            }

            var bestellingenViewModel = await query
                .Select(b => new BestellingViewModel
                {
                    BestellingId = b.BestellingId,
                    BestelDatum = b.BestelDatum,
                    Totaal = b.Items.Sum(i => i.Aantal * i.PrijsPerStuk), // berekening totaal prijs
                    IsBetaald = b.IsBetaald,
                    IsGeannuleerd = b.IsGeannuleerd
                })
                .ToListAsync();

            return View(bestellingenViewModel);
        }

        public async Task<IActionResult> Details(int bestellingId)
        {
            var bestelling = await _context.Bestellingen
                .Include(b => b.Items)
                    .ThenInclude(i => i.Produkt)
                .FirstOrDefaultAsync(b => b.BestellingId == bestellingId);

            if (bestelling == null)
            {
                return NotFound();
            }

            var viewModel = new BestellingViewModel
            {
                BestellingId = bestelling.BestellingId,
                GebruikerNaam = bestelling.UserId,
                BestelDatum = bestelling.BestelDatum,
                Items = bestelling.Items.Select(i => new WinkelmandjeItemViewModel
                {
                    ProductId = i.ProduktProductID,
                    ProductNaam = i.Produkt.ProduktNaam,
                    Aantal = i.Aantal,
                    Prijs = i.PrijsPerStuk
                }).ToList(),
                TotaalPrijs = bestelling.Items.Sum(i => i.Aantal * i.PrijsPerStuk),
                IsBetaald = bestelling.IsBetaald,
                IsGeannuleerd = bestelling.IsGeannuleerd
            };

            return View(viewModel);
        }
    }
}
