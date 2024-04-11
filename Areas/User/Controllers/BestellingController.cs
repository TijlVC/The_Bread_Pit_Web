using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Areas.User.Models;
using The_Bread_Pit.Models; // Pas dit pad aan naar waar je context zich bevindt

namespace The_Bread_Pit.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class BestellingController : Controller
    {
        private readonly TheBreadPitContext _context;

        public BestellingController(TheBreadPitContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Overzicht(int bestellingId)
        {
            var bestelling = await _context.Bestellingen
                                    .Include(b => b.BesteldeItems)
                                    .ThenInclude(i => i.Produkt)
                                    .FirstOrDefaultAsync(b => b.BestellingId == bestellingId);

            if (bestelling == null)
            {
                return NotFound();
            }

            return View(bestelling);
        }
    }
}
