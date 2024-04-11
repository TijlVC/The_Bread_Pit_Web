﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using The_Bread_Pit.Models;

#nullable disable

namespace The_Bread_Pit.Migrations
{
    [DbContext(typeof(TheBreadPitContext))]
    [Migration("20240328083507_CreateIdentitySchema")]
    partial class CreateIdentitySchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("The_Bread_Pit.Areas.User.Models.WinkelmandjeItem", b =>
                {
                    b.Property<int>("WinkelmandjeItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WinkelmandjeItemID"), 1L, 1);

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<int>("ProduktProductID")
                        .HasColumnType("int");

                    b.Property<string>("SessieId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WinkelmandjeItemID");

                    b.HasIndex("ProduktProductID");

                    b.ToTable("WinkelmandjeItems");
                });

            modelBuilder.Entity("The_Bread_Pit.Models.Categorie", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategorieNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categorien");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategorieNaam = "Soep"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategorieNaam = "Salades"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategorieNaam = "Pasta"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategorieNaam = "Snack"
                        },
                        new
                        {
                            CategoryID = 5,
                            CategorieNaam = "Belegde broodjes"
                        },
                        new
                        {
                            CategoryID = 6,
                            CategorieNaam = "Zoet / Fruit"
                        },
                        new
                        {
                            CategoryID = 7,
                            CategorieNaam = "Andere"
                        },
                        new
                        {
                            CategoryID = 8,
                            CategorieNaam = "Dranken"
                        });
                });

            modelBuilder.Entity("The_Bread_Pit.Models.Produkt", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<string>("Allergieën")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategorieCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Extra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Omschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("ProduktNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategorieCategoryID");

                    b.ToTable("Produkten");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            Allergieën = "Contacteer on hierover!",
                            CategoryID = 1,
                            Extra = "Geen extra info meer beschikbaar",
                            Omschrijving = "Soep",
                            Prijs = 1.1m,
                            ProduktNaam = "Soep van de dag"
                        },
                        new
                        {
                            ProductID = 2,
                            Allergieën = "Gluten, Lactose, Soja, Selderij",
                            CategoryID = 7,
                            Extra = "Kan sporen van noten bevatten",
                            Omschrijving = "Stokbrood",
                            Prijs = 0.55m,
                            ProduktNaam = "Stuk stokbrood"
                        },
                        new
                        {
                            ProductID = 3,
                            Allergieën = "Contacteer on hierover!",
                            CategoryID = 7,
                            Extra = "Geen extra info",
                            Omschrijving = "Boter",
                            Prijs = 0.55m,
                            ProduktNaam = "Blokje melkerij boter"
                        },
                        new
                        {
                            ProductID = 4,
                            Allergieën = "Contacteer on hierover!",
                            CategoryID = 2,
                            Extra = "Geen extra info",
                            Omschrijving = "Ceasar Salad",
                            Prijs = 5m,
                            ProduktNaam = "Sla met stukjes Kip"
                        },
                        new
                        {
                            ProductID = 5,
                            Allergieën = "Contacteer on hierover!",
                            CategoryID = 3,
                            Extra = "Geen extra info",
                            Omschrijving = "Pasta 4 Kazen",
                            Prijs = 5.5m,
                            ProduktNaam = "Pasta Klein"
                        },
                        new
                        {
                            ProductID = 6,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 3,
                            Extra = "Geen extra info",
                            Omschrijving = "Pasta 4 kazen",
                            Prijs = 7m,
                            ProduktNaam = "Pasta Groot"
                        },
                        new
                        {
                            ProductID = 7,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Panini met ham en kaas",
                            Prijs = 4m,
                            ProduktNaam = "Panini"
                        },
                        new
                        {
                            ProductID = 8,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Belegd Broodje met kaas",
                            Prijs = 2.85m,
                            ProduktNaam = "Kaas"
                        },
                        new
                        {
                            ProductID = 9,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Belegd Broodje met ham",
                            Prijs = 2.85m,
                            ProduktNaam = "Ham"
                        },
                        new
                        {
                            ProductID = 10,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Belegd Broodje met kaas/ham",
                            Prijs = 3m,
                            ProduktNaam = "Kaas/Ham"
                        },
                        new
                        {
                            ProductID = 11,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Belegd Broodje met prepare",
                            Prijs = 3m,
                            ProduktNaam = "Prepare"
                        },
                        new
                        {
                            ProductID = 12,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Belegd Broodje met smos",
                            Prijs = 3.1m,
                            ProduktNaam = "Smos"
                        },
                        new
                        {
                            ProductID = 13,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Belegd Broodje met kip curry",
                            Prijs = 3.1m,
                            ProduktNaam = "Kip curry"
                        },
                        new
                        {
                            ProductID = 14,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Belegd Broodje met surimi",
                            Prijs = 3.5m,
                            ProduktNaam = "Surimi"
                        },
                        new
                        {
                            ProductID = 15,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Belegd Broodje met gerookte ham",
                            Prijs = 4m,
                            ProduktNaam = "Gerookte ham"
                        },
                        new
                        {
                            ProductID = 16,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 5,
                            Extra = "Geen extra info",
                            Omschrijving = "Belegd Broodje met gerookte zalm",
                            Prijs = 4m,
                            ProduktNaam = "Gerookte zalm"
                        },
                        new
                        {
                            ProductID = 17,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Stukje fruit",
                            Prijs = 0.35m,
                            ProduktNaam = "Stuk fruit"
                        },
                        new
                        {
                            ProductID = 18,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Potje yogurt",
                            Prijs = 1.3m,
                            ProduktNaam = "Yogurt"
                        },
                        new
                        {
                            ProductID = 19,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Dessert",
                            Prijs = 2.2m,
                            ProduktNaam = "Home-made dessert"
                        },
                        new
                        {
                            ProductID = 20,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Foodbar",
                            Prijs = 2.75m,
                            ProduktNaam = "Crazy Berry"
                        },
                        new
                        {
                            ProductID = 21,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Foodbar",
                            Prijs = 2.75m,
                            ProduktNaam = "Good Food"
                        },
                        new
                        {
                            ProductID = 22,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Dessert",
                            Prijs = 1.45m,
                            ProduktNaam = "Muffin / Donut"
                        },
                        new
                        {
                            ProductID = 23,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Dessert",
                            Prijs = 1.65m,
                            ProduktNaam = "Gebak"
                        },
                        new
                        {
                            ProductID = 24,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Dessert",
                            Prijs = 1.3m,
                            ProduktNaam = "Dessert voorverpakt"
                        },
                        new
                        {
                            ProductID = 25,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Snoep",
                            Prijs = 1.3m,
                            ProduktNaam = "Snoep"
                        },
                        new
                        {
                            ProductID = 26,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Snoep",
                            Prijs = 1.45m,
                            ProduktNaam = "Kinder Bueno"
                        },
                        new
                        {
                            ProductID = 27,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Snoep",
                            Prijs = 1.65m,
                            ProduktNaam = "Chips"
                        },
                        new
                        {
                            ProductID = 28,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Snoep",
                            Prijs = 1.65m,
                            ProduktNaam = "Chocolade"
                        },
                        new
                        {
                            ProductID = 29,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 6,
                            Extra = "Geen extra info",
                            Omschrijving = "Smoothie",
                            Prijs = 3.1m,
                            ProduktNaam = "Innocent smoothie"
                        },
                        new
                        {
                            ProductID = 30,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Chaudefontaine",
                            Prijs = 1.3m,
                            ProduktNaam = "Plat water (0.5L)"
                        },
                        new
                        {
                            ProductID = 31,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Chaudefontaine",
                            Prijs = 1.3m,
                            ProduktNaam = "Bruis water (0.5L)"
                        },
                        new
                        {
                            ProductID = 32,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Flesje frisdrank",
                            Prijs = 1.75m,
                            ProduktNaam = "Cola (0.5L)"
                        },
                        new
                        {
                            ProductID = 33,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Flesje frisdrank",
                            Prijs = 1.75m,
                            ProduktNaam = "Fanta (0.5L)"
                        },
                        new
                        {
                            ProductID = 34,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Flesje frisdrank",
                            Prijs = 1.75m,
                            ProduktNaam = "Sprite (0.5L)"
                        },
                        new
                        {
                            ProductID = 35,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Flesje frisdrank",
                            Prijs = 1.9m,
                            ProduktNaam = "Lipton Ice-Tea (0.5L)"
                        },
                        new
                        {
                            ProductID = 36,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Flesje fruitsap",
                            Prijs = 1.75m,
                            ProduktNaam = "Appelsiensap (0.33L)"
                        },
                        new
                        {
                            ProductID = 37,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Flesje fruitsap",
                            Prijs = 1.75m,
                            ProduktNaam = "Appelsap (0.33L)"
                        },
                        new
                        {
                            ProductID = 38,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Flesje Cécémel",
                            Prijs = 1.75m,
                            ProduktNaam = "Cécémel (0.33L)"
                        },
                        new
                        {
                            ProductID = 39,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Energiedrank",
                            Prijs = 2.2m,
                            ProduktNaam = "Blikje Nalu (0.25L)"
                        },
                        new
                        {
                            ProductID = 40,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Energiedrank",
                            Prijs = 2.75m,
                            ProduktNaam = "Red-Bull (0.25L)"
                        },
                        new
                        {
                            ProductID = 41,
                            Allergieën = "Contacteer ons hierover!",
                            CategoryID = 8,
                            Extra = "Geen extra info",
                            Omschrijving = "Koffiedrank",
                            Prijs = 1.2m,
                            ProduktNaam = "Cold Coffee to Go"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("The_Bread_Pit.Areas.User.Models.WinkelmandjeItem", b =>
                {
                    b.HasOne("The_Bread_Pit.Models.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("The_Bread_Pit.Models.Produkt", b =>
                {
                    b.HasOne("The_Bread_Pit.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieCategoryID");

                    b.Navigation("Categorie");
                });
#pragma warning restore 612, 618
        }
    }
}