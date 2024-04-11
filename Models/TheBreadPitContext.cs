using Microsoft.EntityFrameworkCore;

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
                },
                new Produkt
                {
                    ProductID = 2,
                    CategoryID = 1,
                    Omschrijving = "Stuk stokbrood",
                    ProduktNaam = "Stokbrood",
                    Prijs = (decimal)0.55,
                },
                new Produkt
                {
                    ProductID = 3,
                    CategoryID = 1,
                    Omschrijving = "Blokje melkerij boter",
                    ProduktNaam = "Boter",
                    Prijs = (decimal)0.55,
                },
                new Produkt
                {
                    ProductID = 4,
                    CategoryID = 1,
                    Omschrijving = "Sla met stukjes Kip",
                    ProduktNaam = "Ceasar Salad",
                    Prijs = (decimal)5.0,
                },
                new Produkt
                {
                    ProductID = 5,
                    CategoryID = 1,
                    Omschrijving = "Pasta Klein",
                    ProduktNaam = "Pasta 4 Kazen",
                    Prijs = (decimal)5.5,
                }
                );
        }
    }
}
