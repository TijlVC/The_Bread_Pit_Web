using System.ComponentModel.DataAnnotations.Schema;
using The_Bread_Pit.Models;

namespace The_Bread_Pit.Models
{
    public class BestelItem
    {
        public int BestelItemId { get; set; }
        public int Aantal { get; set; }
        public decimal PrijsPerStuk { get; set; }

        [ForeignKey("Produkt")]
        public int ProduktProductID { get; set; }
        public Produkt Produkt { get; set; }

        [ForeignKey("Bestelling")]
        public int BestellingId { get; set; }
        public Bestelling Bestelling { get; set; }
    }
}
