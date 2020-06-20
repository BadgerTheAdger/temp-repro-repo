using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace SpeakingClubApps.Data
{
    public static class IdentityDataInitializer
    {
        public static void SeedData(UserManager<Person> userManager)
        {
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<Person> userManager)
        {
            if (userManager.FindByNameAsync("test_user").GetAwaiter().GetResult() == null)
            {
                var user = new Person
                {
                    UserName = "test_user",
                    Email = "test_user@localhost", 
                    EmailConfirmed = true,
                    FirstName = "Test",
                    LastName = "User",
                    Score = 5000,
                    Visits = 10
                };

                IdentityResult result = userManager.CreateAsync(user, "123abcG$").GetAwaiter().GetResult();
                
                if (!result.Succeeded)
                {
                    var completeException = string.Join(",\n", result.Errors.Select(i => i.Description));

                    throw new InvalidOperationException("Exception at seeding users: " + completeException);
                }

            }

            if (userManager.FindByNameAsync("test_admin").GetAwaiter().GetResult() == null)
            {
                var user = new Person
                {
                    UserName = "test_admin",
                    Email = "test_admin@localhost", 
                    EmailConfirmed = true,
                    FirstName = "Mark",
                    LastName = "Virchenko",
                    Score = 20000,
                    Visits = 30
                };

                IdentityResult result = userManager.CreateAsync(user, "123abcG$").GetAwaiter().GetResult();

                if (!result.Succeeded)
                {
                    var completeException = string.Join(", ", result.Errors.Select(i => i.Description));

                    throw new InvalidOperationException("Exception at seeding admins: " + completeException);
                }
            }
        }
    }
}