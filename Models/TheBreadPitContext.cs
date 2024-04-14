using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Areas.User.Models;

namespace The_Bread_Pit.Models
{
#nullable disable
    public class TheBreadPitContext: IdentityDbContext
    {
        public TheBreadPitContext(DbContextOptions<TheBreadPitContext> options) :base(options) { }

        public DbSet<Produkt> Produkten { get; set; } 

        public DbSet<Categorie> Categorien { get; set; }

        public DbSet<Bestelling> Bestellingen { get; set; }

        public DbSet<BestelItem> BestelItems { get; set; }
        public DbSet<WinkelmandjeItem> WinkelmandjeItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WinkelmandjeItem>()
           .HasOne(w => w.Produkt)
           .WithMany()
           .HasForeignKey(w => w.ProduktProductID);

            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { CategoryID = 1, CategorieNaam = "Soep" },
                new Categorie { CategoryID = 2, CategorieNaam = "Salades" },
                new Categorie { CategoryID = 3, CategorieNaam = "Pasta" },
                new Categorie { CategoryID = 4, CategorieNaam = "Snack" },
                new Categorie { CategoryID = 5, CategorieNaam = "Belegde broodjes" },
                new Categorie { CategoryID = 6, CategorieNaam = "Zoet / Fruit" },
                new Categorie { CategoryID = 7, CategorieNaam = "Andere" },
                new Categorie { CategoryID = 8, CategorieNaam = "Dranken" }
                );

            modelBuilder.Entity<Produkt>().HasData(
                new Produkt
                {
                    ProductID = 1,
                    CategoryID = 1,
                    Omschrijving = "Soep van de dag (zie bord)",
                    ProduktNaam = "Soep",
                    Prijs = (decimal)1.1,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info meer beschikbaar",
                    ImagePath = "soep.jpeg"
                },
                new Produkt
                {
                    ProductID = 2,
                    CategoryID = 7,
                    Omschrijving = "Stuk stokbrood (20cm)",
                    ProduktNaam = "Stokbrood",
                    Prijs = (decimal)0.55,
                    Allergieën = "Gluten, Lactose, Soja, Selderij",
                    Extra = "Kan sporen van noten bevatten",
                    ImagePath = "stokbrood.jpeg"
                },
                new Produkt
                {
                    ProductID = 3,
                    CategoryID = 7,
                    Omschrijving = "Blokje melkerij boter",
                    ProduktNaam = "Boter",
                    Prijs = (decimal)0.55,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Boter.jpeg"
                },
                new Produkt
                {
                    ProductID = 4,
                    CategoryID = 2,
                    Omschrijving = "Sla met stukjes Kip",
                    ProduktNaam = "Ceasar Salad",
                    Prijs = (decimal)5.0,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "CeasarSalad.jpeg"
                },
                new Produkt
                {
                    ProductID = 5,
                    CategoryID = 3,
                    Omschrijving = "Pasta 4 kazen klein",
                    ProduktNaam = "Pasta Klein",
                    Prijs = (decimal)5.5,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "PastaKlein.jpeg"
                },
                new Produkt
                {
                    ProductID = 6,
                    CategoryID = 3,
                    Omschrijving = "Pasta 4 kazen Groot",
                    ProduktNaam = "Pasta Groot",
                    Prijs = (decimal)7.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "PastaGroot.jpeg"
                },
                new Produkt
                {
                    ProductID = 7,
                    CategoryID = 5,
                    Omschrijving = "Panini",
                    ProduktNaam = "Panini met ham en kaas",
                    Prijs = (decimal)4.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Panini.jpeg"
                },
                new Produkt
                {
                    ProductID = 8,
                    CategoryID = 5,
                    Omschrijving = "Belegd Broodje met kaas",
                    ProduktNaam = "Broodje Kaas",
                    Prijs = (decimal)2.85,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "BroodjeKaas.jpg"
                },
                new Produkt
                {
                    ProductID = 9,
                    CategoryID = 5,
                    Omschrijving = "Belegd broodje metham",
                    ProduktNaam = "Broodje Ham",
                    Prijs = (decimal)2.85,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "BroodjeHam.jpeg"
                },
                new Produkt
                {
                    ProductID = 10,
                    CategoryID = 5,
                    Omschrijving = "Belegd Broodje met kaas/ham",
                    ProduktNaam = "Broodje Kaas - Ham",
                    Prijs = (decimal)3.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "BroodjeKaas-Ham.jpeg"
                },
                new Produkt
                {
                    ProductID = 11,
                    CategoryID = 5,
                    Omschrijving = "Prepare",
                    ProduktNaam = "Belegd Broodje met prepare",
                    Prijs = (decimal)3.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "BroodjePrepare.jpeg"
                },
                new Produkt
                {
                    ProductID = 12,
                    CategoryID = 5,
                    Omschrijving = "Smoske",
                    ProduktNaam = "Belegd Broodje met smos",
                    Prijs = (decimal)3.10,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Smoske.jpeg"
                },
                new Produkt
                {
                    ProductID = 13,
                    CategoryID = 5,
                    Omschrijving = "Belegd Broodje met kip curry",
                    ProduktNaam = "Broodje Kip Curry",
                    Prijs = (decimal)3.10,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "BroodjeKipCurry.jpeg"
                },
                new Produkt
                {
                    ProductID = 14,
                    CategoryID = 5,
                    Omschrijving = "Belegd Broodje met surimi",
                    ProduktNaam = "Broodje Surimi",
                    Prijs = (decimal)3.50,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "BroodjeSurimi.jpeg"
                },
                new Produkt
                {
                    ProductID = 15,
                    CategoryID = 5,
                    Omschrijving = "Belegd Broodje met gerookte ham",
                    ProduktNaam = "Broodje Gerookte Ham",
                    Prijs = (decimal)4.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "BroodjeGerookteHam.jpeg"
                },
                new Produkt
                {
                    ProductID = 16,
                    CategoryID = 5,
                    Omschrijving = "Belegd Broodje met gerookte zalm",
                    ProduktNaam = "Broodje Gerookte Zalm",
                    Prijs = (decimal)4.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "BroodjeGerookteZalm.jpeg"
                },
                new Produkt
                {
                    ProductID = 17,
                    CategoryID = 6,
                    Omschrijving = "Stuk fruit (Appel, Peer, Banaan, 2x kiwi)",
                    ProduktNaam = "Stukje fruit",
                    Prijs = (decimal)0.35,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "StukjeFruit.jpeg"
                },
                new Produkt
                {
                    ProductID = 18,
                    CategoryID = 6,
                    Omschrijving = "Potje yogurt",
                    ProduktNaam = "Potje yogurt",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "PotjeYogurt.jpeg"
                },
                new Produkt
                {
                    ProductID = 19,
                    CategoryID = 6,
                    Omschrijving = "Home-made dessert",
                    ProduktNaam = "Dessert",
                    Prijs = (decimal)2.20,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "HomeMadeDessert.jpeg"
                },
                new Produkt
                {
                    ProductID = 20,
                    CategoryID = 6,
                    Omschrijving = "Foodbar - Crazy Berry",
                    ProduktNaam = "Foodbar Berry",
                    Prijs = (decimal)2.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "FoodbaryBerry.jpeg"
                },
                new Produkt
                {
                    ProductID = 21,
                    CategoryID = 6,
                    Omschrijving = "Foodbar - Good Food",
                    ProduktNaam = "Foodbar Healt",
                    Prijs = (decimal)2.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "FoodbarHealt.jpeg"
                },
                new Produkt
                {
                    ProductID = 22,
                    CategoryID = 6,
                    Omschrijving = "Muffin of Donut",
                    ProduktNaam = "Muffin - Donut",
                    Prijs = (decimal)1.45,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Muffin-Donut.jpeg"
                },
                new Produkt
                {
                    ProductID = 23,
                    CategoryID = 6,
                    Omschrijving = "Stukje gebak (zelf gebakken)",
                    ProduktNaam = "Gebak",
                    Prijs = (decimal)1.65,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Gebak.jpeg"
                },
                new Produkt
                {
                    ProductID = 24,
                    CategoryID = 6,
                    Omschrijving = "Dessert in voorverpakking",
                    ProduktNaam = "Voorverpakt Dessert",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "DessertVoorverpaktDessert.jpeg"
                },
                new Produkt
                {
                    ProductID = 25,
                    CategoryID = 6,
                    Omschrijving = "Zakje Snoep",
                    ProduktNaam = "Snoep",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Snoep.jpeg"
                },
                new Produkt
                {
                    ProductID = 26,
                    CategoryID = 6,
                    Omschrijving = "Kinder Bueno",
                    ProduktNaam = "Kinder Bueno",
                    Prijs = (decimal)1.45,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "KinderBueno.jpeg"
                },
                new Produkt
                {
                    ProductID = 27,
                    CategoryID = 6,
                    Omschrijving = "Zakje Chips",
                    ProduktNaam = "Chips",
                    Prijs = (decimal)1.65,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Chips.jpeg"
                },
                new Produkt
                {
                    ProductID = 28,
                    CategoryID = 6,
                    Omschrijving = "Reep Chocolade",
                    ProduktNaam = "Chocolade",
                    Prijs = (decimal)1.65,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Chocolade.jpeg"
                },
                new Produkt
                {
                    ProductID = 29,
                    CategoryID = 6,
                    Omschrijving = "Innocent smoothie",
                    ProduktNaam = "Smoothie",
                    Prijs = (decimal)3.10,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Smoothie.jpeg"
                },
                new Produkt
                {
                    ProductID = 30,
                    CategoryID = 8,
                    Omschrijving = "Plat water (0.5L)",
                    ProduktNaam = "Chaudefontaine",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Chaudefontaine.jpeg"
                },
                new Produkt
                {
                    ProductID = 31,
                    CategoryID = 8,
                    Omschrijving = "Bruis water (0.5L)",
                    ProduktNaam = "Chaudefontaine",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Chaudefontaine.jpeg"
                },
                new Produkt
                {
                    ProductID = 32,
                    CategoryID = 8,
                    Omschrijving = "Cola (0.5L)",
                    ProduktNaam = "Cola",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Cola.jpeg"
                },
                new Produkt
                {
                    ProductID = 33,
                    CategoryID = 8,
                    Omschrijving = "Fanta (0.5L)",
                    ProduktNaam = "Fanta",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Fanta.jpeg"
                },
                new Produkt
                {
                    ProductID = 34,
                    CategoryID = 8,
                    Omschrijving = "Sprite (0.5L)",
                    ProduktNaam = "Sprite",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Sprite.jpeg"
                },
                new Produkt
                {
                    ProductID = 35,
                    CategoryID = 8,
                    Omschrijving = "Lipton Ice-Tea (0.5L)",
                    ProduktNaam = "Lipton Ice-Tea",
                    Prijs = (decimal)1.90,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "LiptonIce-Tea.jpeg"
                },
                new Produkt
                {
                    ProductID = 36,
                    CategoryID = 8,
                    Omschrijving = "Appelsiensap (0.33L)",
                    ProduktNaam = "Appelsiensap",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Appelsiensap.jpeg"
                },
                new Produkt
                {
                    ProductID = 37,
                    CategoryID = 8,
                    Omschrijving = "Appelsap (0.33L)",
                    ProduktNaam = "Appelsap",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Appelsap.jpeg"
                },
                new Produkt
                {
                    ProductID = 38,
                    CategoryID = 8,
                    Omschrijving = "Cécémel (0.33L)",
                    ProduktNaam = "Cécémel",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Cécémel.jpeg"
                },
                new Produkt
                {
                    ProductID = 39,
                    CategoryID = 8,
                    Omschrijving = "Nalu (0.25L)",
                    ProduktNaam = "Blikje Nalu",
                    Prijs = (decimal)2.20,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "BlikjeNalu.jpeg"
                },
                new Produkt
                {
                    ProductID = 40,
                    CategoryID = 8,
                    Omschrijving = "Red-Bull (0.25L)",
                    ProduktNaam = "Blikje Red-Bull",
                    Prijs = (decimal)2.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "Red-Bull.jpeg"
                },
                new Produkt
                {
                    ProductID = 41,
                    CategoryID = 8,
                    Omschrijving = "Cup koude kofie om mee te nemen",
                    ProduktNaam = "Cold Coffee to Go",
                    Prijs = (decimal)1.20,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info",
                    ImagePath = "ColdCoffeeToGo.jpeg"
                }
                ) ;
        }
    }
}
