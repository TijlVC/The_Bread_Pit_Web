﻿using The_Bread_Pit.Models;

namespace The_Bread_Pit.Areas.User.Models
{
    public class WinkelmandjeItem
    {
        public int WinkelmandjeItemID { get; set; }
        public int ProduktProductID { get; set; } // Foreign Key
        public Produkt? Produkt { get; set; }
        public int Aantal { get; set; }
        public string SessieId { get; set; } = string.Empty;
    }
}