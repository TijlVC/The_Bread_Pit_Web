using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_Bread_Pit.Models
{
    public class Bestelling
    {
        public int BestellingId { get; set; }
        public DateTime BestelDatum { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        public List<BestelItem> Items { get; set; }
        public bool IsAfgerond { get; set; } = false;
        public bool IsBetaald { get; set; } = false;
        public bool IsGeannuleerd { get; set; } = false;


        // Bereken de totaalprijs van de bestelling
        [NotMapped]
        public decimal TotaalPrijs
        {
            get { return Items?.Sum(i => i.Aantal * i.PrijsPerStuk) ?? 0; }
        }
    }
}
