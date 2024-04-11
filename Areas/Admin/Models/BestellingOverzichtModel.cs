namespace TheBreadPit.Areas.Admin.Models
{
    public class BestellingDetail
    {
        public int BestellingId { get; set; }
        public string GebruikersNaam { get; set; }
        public DateTime BestelDatum { get; set; }
        public decimal TotaalPrijs { get; set; }
        public bool IsAfgerond { get; set; }
        public bool IsGeannuleerd { get; set; }
    }

}
