namespace TheBreadPit.Areas.Employee.Models
{
    public class BestellingOverzichtViewModel
    {
        public List<BestellingDetail> Bestellingen { get; set; } = new List<BestellingDetail>();
        public decimal TotalePrijs { get; set; }
        public List<ProductSamenvatting> Producten { get; set; } = new List<ProductSamenvatting>();
    }

    public class BestellingDetail
    {
        public int BestellingId { get; set; }
        public string GebruikersNaam { get; set; }
        public DateTime BestelDatum { get; set; }
        public decimal TotaalPrijs { get; set; }
        public bool IsAfgerond { get; set; }
    }

    public class ProductSamenvatting
    {
        public string ProduktNaam { get; set; }
        public int Aantal { get; set; }
        public decimal PrijsPerStuk { get; set; }
        public decimal Subtotaal => Aantal * PrijsPerStuk;
    }
}
