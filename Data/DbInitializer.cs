namespace The_Bread_Pit.Data
{

    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using The_Bread_Pit.Models;

    public static class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Employee", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create admin user
            await CreateUserAsync(userManager, "admin1@thebreadpit.com", "Passw0rd!", "Admin");
            // Create employee user
            await CreateUserAsync(userManager, "employee1@thebreadpit.com", "Passw0rd!", "Employee");
            // Create general user
            await CreateUserAsync(userManager, "user1@thebreadpit.com", "Passw0rd!", "User");
        }

        private static async Task CreateUserAsync(UserManager<IdentityUser> userManager, string email, string password, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = email,
                    Email = email
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        private static void SeedProducts(TheBreadPitContext context)
        {
            if (!context.Produkten.Any())
            {
                context.Produkten.AddRange(
                    new Produkt
                    {
                        ProduktNaam = "Panini",
                        Prijs = 5.00M,
                        Omschrijving = "Heerlijk Italiaans broodje",
                        Allergieën = "Bevat gluten",
                        Extra = "Ook verkrijgbaar met extra kaas",
                        CategoryID = 1, // Zorg dat dit ID overeenkomt met een bestaande categorie
                        ImagePath = "default.jpg"
                    },
                    new Produkt
                    {
                        ProduktNaam = "Donut",
                        Prijs = 2.50M,
                        Omschrijving = "Zoete traktatie met glazuur",
                        Allergieën = "Bevat gluten en noten",
                        Extra = "Verkrijgbaar in verschillende smaken",
                        CategoryID = 2,
                        ImagePath = "default.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
