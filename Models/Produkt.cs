using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace The_Bread_Pit.Models
{
    public class Produkt
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Gelieve een produkt naam in te geven")]
        public string? ProduktNaam { get; set; }

        [Required(ErrorMessage = "Gelieve een prijs in te geven")]
        [Column(TypeName = "decimal(20,2)")]
        public decimal Prijs { get; set; }

        public string? Omschrijving { get; set; }

        public string Allergieën { get; set; } = "Contacteer ons hierover!";
        public string Extra { get; set; } = "Geen extra info";

        public string Url => ProduktNaam == null ? "" : ProduktNaam.Replace(' ', '-');

        [Required(ErrorMessage = "Gelieve een categorie te selecteren")]
        public int CategoryID { get; set; }
        public Categorie? Categorie { get; set; }
    }
}