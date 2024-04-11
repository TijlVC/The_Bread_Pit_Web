using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using The_Bread_Pit.Areas.User.Models;

namespace The_Bread_Pit.Models
{
#nullable disable
    public class TheBreadPitContext : IdentityDbContext
    {
        public TheBreadPitContext(DbContextOptions<TheBreadPitContext> options) : base(options) { }

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
                    ProduktNaam = "Soep van de dag",
                    Omschrijving = "Soep",
                    Prijs = (decimal)1.1,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info meer beschikbaar",
                },
                new Produkt
                {
                    ProductID = 2,
                    CategoryID = 7,
                    ProduktNaam = "Stuk stokbrood",
                    Omschrijving = "Stokbrood",
                    Prijs = (decimal)0.55,
                    Allergieën = "Gluten, Lactose, Soja, Selderij",
                    Extra = "Kan sporen van noten bevatten",
                },
                new Produkt
                {
                    ProductID = 3,
                    CategoryID = 7,
                    ProduktNaam = "Blokje melkerij boter",
                    Omschrijving = "Boter",
                    Prijs = (decimal)0.55,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info",
                },
                new Produkt
                {
                    ProductID = 4,
                    CategoryID = 2,
                    ProduktNaam = "Sla met stukjes Kip",
                    Omschrijving = "Ceasar Salad",
                    Prijs = (decimal)5.0,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info",
                },
                new Produkt
                {
                    ProductID = 5,
                    CategoryID = 3,
                    ProduktNaam = "Pasta Klein",
                    Omschrijving = "Pasta 4 Kazen",
                    Prijs = (decimal)5.5,
                    Allergieën = "Contacteer on hierover!",
                    Extra = "Geen extra info",
                },
                new Produkt
                {
                    ProductID = 6,
                    CategoryID = 3,
                    ProduktNaam = "Pasta Groot",
                    Omschrijving = "Pasta 4 kazen",
                    Prijs = (decimal)7.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 7,
                    CategoryID = 5,
                    ProduktNaam = "Panini",
                    Omschrijving = "Panini met ham en kaas",
                    Prijs = (decimal)4.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 8,
                    CategoryID = 5,
                    ProduktNaam = "Kaas",
                    Omschrijving = "Belegd Broodje met kaas",
                    Prijs = (decimal)2.85,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 9,
                    CategoryID = 5,
                    ProduktNaam = "Ham",
                    Omschrijving = "Belegd Broodje met ham",
                    Prijs = (decimal)2.85,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 10,
                    CategoryID = 5,
                    ProduktNaam = "Kaas/Ham",
                    Omschrijving = "Belegd Broodje met kaas/ham",
                    Prijs = (decimal)3.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 11,
                    CategoryID = 5,
                    ProduktNaam = "Prepare",
                    Omschrijving = "Belegd Broodje met prepare",
                    Prijs = (decimal)3.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 12,
                    CategoryID = 5,
                    ProduktNaam = "Smos",
                    Omschrijving = "Belegd Broodje met smos",
                    Prijs = (decimal)3.10,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 13,
                    CategoryID = 5,
                    ProduktNaam = "Kip curry",
                    Omschrijving = "Belegd Broodje met kip curry",
                    Prijs = (decimal)3.10,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 14,
                    CategoryID = 5,
                    ProduktNaam = "Surimi",
                    Omschrijving = "Belegd Broodje met surimi",
                    Prijs = (decimal)3.50,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 15,
                    CategoryID = 5,
                    ProduktNaam = "Gerookte ham",
                    Omschrijving = "Belegd Broodje met gerookte ham",
                    Prijs = (decimal)4.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 16,
                    CategoryID = 5,
                    ProduktNaam = "Gerookte zalm",
                    Omschrijving = "Belegd Broodje met gerookte zalm",
                    Prijs = (decimal)4.00,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 17,
                    CategoryID = 6,
                    ProduktNaam = "Stuk fruit",
                    Omschrijving = "Stukje fruit",
                    Prijs = (decimal)0.35,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 18,
                    CategoryID = 6,
                    ProduktNaam = "Yogurt",
                    Omschrijving = "Potje yogurt",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 19,
                    CategoryID = 6,
                    ProduktNaam = "Home-made dessert",
                    Omschrijving = "Dessert",
                    Prijs = (decimal)2.20,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 20,
                    CategoryID = 6,
                    ProduktNaam = "Crazy Berry",
                    Omschrijving = "Foodbar",
                    Prijs = (decimal)2.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 21,
                    CategoryID = 6,
                    ProduktNaam = "Good Food",
                    Omschrijving = "Foodbar",
                    Prijs = (decimal)2.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 22,
                    CategoryID = 6,
                    ProduktNaam = "Muffin / Donut",
                    Omschrijving = "Dessert",
                    Prijs = (decimal)1.45,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 23,
                    CategoryID = 6,
                    ProduktNaam = "Gebak",
                    Omschrijving = "Dessert",
                    Prijs = (decimal)1.65,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 24,
                    CategoryID = 6,
                    ProduktNaam = "Dessert voorverpakt",
                    Omschrijving = "Dessert",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 25,
                    CategoryID = 6,
                    ProduktNaam = "Snoep",
                    Omschrijving = "Snoep",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 26,
                    CategoryID = 6,
                    ProduktNaam = "Kinder Bueno",
                    Omschrijving = "Snoep",
                    Prijs = (decimal)1.45,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 27,
                    CategoryID = 6,
                    ProduktNaam = "Chips",
                    Omschrijving = "Snoep",
                    Prijs = (decimal)1.65,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 28,
                    CategoryID = 6,
                    ProduktNaam = "Chocolade",
                    Omschrijving = "Snoep",
                    Prijs = (decimal)1.65,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 29,
                    CategoryID = 6,
                    ProduktNaam = "Innocent smoothie",
                    Omschrijving = "Smoothie",
                    Prijs = (decimal)3.10,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 30,
                    CategoryID = 8,
                    ProduktNaam = "Plat water (0.5L)",
                    Omschrijving = "Chaudefontaine",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 31,
                    CategoryID = 8,
                    ProduktNaam = "Bruis water (0.5L)",
                    Omschrijving = "Chaudefontaine",
                    Prijs = (decimal)1.30,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 32,
                    CategoryID = 8,
                    ProduktNaam = "Cola (0.5L)",
                    Omschrijving = "Flesje frisdrank",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 33,
                    CategoryID = 8,
                    ProduktNaam = "Fanta (0.5L)",
                    Omschrijving = "Flesje frisdrank",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 34,
                    CategoryID = 8,
                    ProduktNaam = "Sprite (0.5L)",
                    Omschrijving = "Flesje frisdrank",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 35,
                    CategoryID = 8,
                    ProduktNaam = "Lipton Ice-Tea (0.5L)",
                    Omschrijving = "Flesje frisdrank",
                    Prijs = (decimal)1.90,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 36,
                    CategoryID = 8,
                    ProduktNaam = "Appelsiensap (0.33L)",
                    Omschrijving = "Flesje fruitsap",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 37,
                    CategoryID = 8,
                    ProduktNaam = "Appelsap (0.33L)",
                    Omschrijving = "Flesje fruitsap",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 38,
                    CategoryID = 8,
                    ProduktNaam = "Cécémel (0.33L)",
                    Omschrijving = "Flesje Cécémel",
                    Prijs = (decimal)1.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 39,
                    CategoryID = 8,
                    ProduktNaam = "Blikje Nalu (0.25L)",
                    Omschrijving = "Energiedrank",
                    Prijs = (decimal)2.20,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 40,
                    CategoryID = 8,
                    ProduktNaam = "Red-Bull (0.25L)",
                    Omschrijving = "Energiedrank",
                    Prijs = (decimal)2.75,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                },
                new Produkt
                {
                    ProductID = 41,
                    CategoryID = 8,
                    ProduktNaam = "Cold Coffee to Go",
                    Omschrijving = "Koffiedrank",
                    Prijs = (decimal)1.20,
                    Allergieën = "Contacteer ons hierover!",
                    Extra = "Geen extra info"
                }
                );
        }
    }
}
