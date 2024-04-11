namespace The_Bread_Pit.Areas.User.Models
{
    public class Bestelling
    {
        public int BestellingId { get; set; }
        public string UserId { get; set; } // ForeignKey naar de IdentityUser
        public DateTime BestelDatum { get; set; }
        public decimal TotaalPrijs { get; set; }
        // Overige velden zoals status, betalingswijze, afleveradres, etc.

        public List<WinkelmandjeItem> BesteldeItems { get; set; } // Items die tot deze bestelling behoren
    }
}
