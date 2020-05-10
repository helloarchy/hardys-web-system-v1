using System.Security.Claims;
using System.Threading.Tasks;
using HardysWebSystem.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace HardysWebSystem.Server.Data
{
    public class DbSeed
    {
        private static UserManager<ApplicationUser> _userManager;

        public static async Task SeedDatabase(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

            await context.Database.EnsureCreatedAsync();

            var customerClaim = new Claim("Customer", "True");
            var adminClaim = new Claim("Admin", "True");

            // Standard password for all users
            const string password = "Password123!";

            await SeedAdmin(customerClaim, adminClaim, password);
            await SeedCustomer(customerClaim, password);
        }


        /**
         * Seed users for the Admin role
         */
        private static async Task SeedAdmin(Claim customerClaim, Claim adminClaim,
            string password)
        {
            await CreateUser("Admin1",
                "Admin1@email.com", "Ada", "Lovelace",
                password, customerClaim, adminClaim);
        }


        /**
         * Seed users for the Customer role
         */
        private static async Task SeedCustomer(Claim customerClaim, string password)
        {
            // Customer 1
            await CreateUser("Customer1", "Customer1@email.com",
                "Alan", "Turing", password, customerClaim);

            // Customer 2
            await CreateUser("Customer2", "Customer2@email.com",
                "Donald", "Knuth", password, customerClaim);

            // Customer 3
            await CreateUser("Customer3", "Customer3@email.com",
                "Grace", "Hopper", password, customerClaim);

            // Customer 4
            await CreateUser("Customer4", "Customer4@email.com",
                "Brian", "Kernighan", password, customerClaim);

            // Customer 5
            await CreateUser("Customer5", "Customer5@email.com",
                "John", "Backus", password, customerClaim);
        }


        private static async Task CreateUser(string username, string email,
            string firstName, string lastName, string password, Claim claim,
            Claim extraClaim = null)
        {
            if (await _userManager.FindByNameAsync(username) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = username,
                    Email = email,
                    /*FirstName = firstName,
                    LastName = lastName*/
                };

                IdentityResult result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(user, password);
                    await _userManager.AddClaimAsync(user, claim);
                    if (extraClaim != null)
                    {
                        await _userManager.AddClaimAsync(user, extraClaim);
                    }
                }
            }
        }
    }
}