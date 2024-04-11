using System.ComponentModel.DataAnnotations;

namespace The_Bread_Pit.Models
{
    public class Categorie
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Gelieve een categorienaam in te geven")]
        public string? CategorieNaam { get; set; }
    }
}