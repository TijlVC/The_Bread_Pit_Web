using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Areas.User.Models;

namespace The_Bread_Pit.Models
{
#nullable disable
    public class TheBreadPitContext: DbContext
    {
        public TheBreadPitContext(DbContextOptions<TheBreadPitContext> options) :base(options) { }

        public DbSet<Produkt> Produkten { get; set; } 

        public DbSet<Categorie> Categorien { get; set; }

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
                    Omschrijving = "Soep van de dag",
                    ProduktNaam = "Soep",
                    Prijs = (decimal)1.1,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info meer beschikbaar",
                },
                new Produkt
                {
                    ProductID = 2,
                    CategoryID = 7,
                    Omschrijving = "Stuk stokbrood",
                    ProduktNaam = "Stokbrood",
                    Prijs = (decimal)0.55,
                    Allergieën = "Gluten, Lactose, Soja, Selderij",
                    Extra = "Kan sporen van noten bevatten",
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
                },
                new Produkt
                {
                    ProductID = 5,
                    CategoryID = 3,
                    Omschrijving = "Pasta Klein",
                    ProduktNaam = "Pasta 4 Kazen",
                    Prijs = (decimal)5.5,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info",
                },
                new Produkt
                {
                    ProductID = 6,
                    CategoryID = 3,
                    Omschrijving = "Pasta Groot",
                    ProduktNaam = "Pasta 4 kazen",
                    Prijs = (decimal)7.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 7,
                    CategoryID = 5,
                    Omschrijving = "Panini",
                    ProduktNaam = "Panini met ham en kaas",
                    Prijs = (decimal)4.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 8,
                    CategoryID = 5,
                    Omschrijving = "Kaas",
                    ProduktNaam = "Belegd Broodje met kaas",
                    Prijs = (decimal)2.85,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 9,
                    CategoryID = 5,
                    Omschrijving = "Ham",
                    ProduktNaam = "Belegd Broodje met ham",
                    Prijs = (decimal)2.85,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 10,
                    CategoryID = 5,
                    Omschrijving = "Kaas/Ham",
                    ProduktNaam = "Belegd Broodje met kaas/ham",
                    Prijs = (decimal)3.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 11,
                    CategoryID = 5,
                    Omschrijving = "Prepare",
                    ProduktNaam = "Belegd Broodje met prepare",
                    Prijs = (decimal)3.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 12,
                    CategoryID = 5,
                    Omschrijving = "Smos",
                    ProduktNaam = "Belegd Broodje met smos",
                    Prijs = (decimal)3.10,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 13,
                    CategoryID = 5,
                    Omschrijving = "Kip curry",
                    ProduktNaam = "Belegd Broodje met kip curry",
                    Prijs = (decimal)3.10,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 14,
                    CategoryID = 5,
                    Omschrijving = "Surimi",
                    ProduktNaam = "Belegd Broodje met surimi",
                    Prijs = (decimal)3.50,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 15,
                    CategoryID = 5,
                    Omschrijving = "Gerookte ham",
                    ProduktNaam = "Belegd Broodje met gerookte ham",
                    Prijs = (decimal)4.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 16,
                    CategoryID = 5,
                    Omschrijving = "Gerookte zalm",
                    ProduktNaam = "Belegd Broodje met gerookte zalm",
                    Prijs = (decimal)4.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 17,
                    CategoryID = 6,
                    Omschrijving = "Stuk fruit",
                    ProduktNaam = "Stukje fruit",
                    Prijs = (decimal)0.35,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 18,
                    CategoryID = 6,
                    Omschrijving = "Yogurt",
                    ProduktNaam = "Potje yogurt",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 19,
                    CategoryID = 6,
                    Omschrijving = "Home-made dessert",
                    ProduktNaam = "Dessert",
                    Prijs = (decimal)2.20,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 20,
                    CategoryID = 6,
                    Omschrijving = "Crazy Berry",
                    ProduktNaam = "Foodbar",
                    Prijs = (decimal)2.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 21,
                    CategoryID = 6,
                    Omschrijving = "Good Food",
                    ProduktNaam = "Foodbar",
                    Prijs = (decimal)2.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 22,
                    CategoryID = 6,
                    Omschrijving = "Muffin / Donut",
                    ProduktNaam = "Dessert",
                    Prijs = (decimal)1.45,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 23,
                    CategoryID = 6,
                    Omschrijving = "Gebak",
                    ProduktNaam = "Dessert",
                    Prijs = (decimal)1.65,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 24,
                    CategoryID = 6,
                    Omschrijving = "Dessert voorverpakt",
                    ProduktNaam = "Dessert",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 25,
                    CategoryID = 6,
                    Omschrijving = "Snoep",
                    ProduktNaam = "Snoep",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 26,
                    CategoryID = 6,
                    Omschrijving = "Kinder Bueno",
                    ProduktNaam = "Snoep",
                    Prijs = (decimal)1.45,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 27,
                    CategoryID = 6,
                    Omschrijving = "Chips",
                    ProduktNaam = "Snoep",
                    Prijs = (decimal)1.65,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 28,
                    CategoryID = 6,
                    Omschrijving = "Chocolade",
                    ProduktNaam = "Snoep",
                    Prijs = (decimal)1.65,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 29,
                    CategoryID = 6,
                    Omschrijving = "Innocent smoothie",
                    ProduktNaam = "Smoothie",
                    Prijs = (decimal)3.10,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 30,
                    CategoryID = 8,
                    Omschrijving = "Plat water (0.5L)",
                    ProduktNaam = "Chaudefontaine",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 31,
                    CategoryID = 8,
                    Omschrijving = "Bruis water (0.5L)",
                    ProduktNaam = "Chaudefontaine",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 32,
                    CategoryID = 8,
                    Omschrijving = "Cola (0.5L)",
                    ProduktNaam = "Flesje frisdrank",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 33,
                    CategoryID = 8,
                    Omschrijving = "Fanta (0.5L)",
                    ProduktNaam = "Flesje frisdrank",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 34,
                    CategoryID = 8,
                    Omschrijving = "Sprite (0.5L)",
                    ProduktNaam = "Flesje frisdrank",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 35,
                    CategoryID = 8,
                    Omschrijving = "Lipton Ice-Tea (0.5L)",
                    ProduktNaam = "Flesje frisdrank",
                    Prijs = (decimal)1.90,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 36,
                    CategoryID = 8,
                    Omschrijving = "Appelsiensap (0.33L)",
                    ProduktNaam = "Flesje fruitsap",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 37,
                    CategoryID = 8,
                    Omschrijving = "Appelsap (0.33L)",
                    ProduktNaam = "Flesje fruitsap",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 38,
                    CategoryID = 8,
                    Omschrijving = "Cécémel (0.33L)",
                    ProduktNaam = "Flesje Cécémel",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 39,
                    CategoryID = 8,
                    Omschrijving = "Blikje Nalu (0.25L)",
                    ProduktNaam = "Energiedrank",
                    Prijs = (decimal)2.20,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 40,
                    CategoryID = 8,
                    Omschrijving = "Red-Bull (0.25L)",
                    ProduktNaam = "Energiedrank",
                    Prijs = (decimal)2.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 41,
                    CategoryID = 8,
                    Omschrijving = "Cold Coffee to Go",
                    ProduktNaam = "Koffiedrank",
                    Prijs = (decimal)1.20,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                }
                );
        }
    }
}
