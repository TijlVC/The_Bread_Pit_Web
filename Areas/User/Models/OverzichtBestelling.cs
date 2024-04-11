using System;
using System.Collections.Generic;

namespace The_Bread_Pit.Areas.User.Models
{
    public class BestellingViewModel
    {
        public int BestellingId { get; set; }
        public string GebruikerNaam { get; set; }
        public DateTime BestelDatum { get; set; }
        public List<WinkelmandjeItemViewModel> Items { get; set; }
        public decimal TotaalPrijs { get; set; }
        public bool IsBetaald { get; set; }
        public bool IsGeannuleerd { get; set; }
    }

    public class WinkelmandjeItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductNaam { get; set; }
        public int Aantal { get; set; }
        public decimal Prijs { get; set; }
        public decimal Subtotaal => Aantal * Prijs;
    }
}