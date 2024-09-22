using BstEnvanter.WebUI.Models;
using Microsoft.AspNetCore.Identity;

namespace BstEnvanter.WebUI.Identity
{
    public static class SeedIdentity
    {

        public static void Seed(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {

            if (roleManager.FindByNameAsync("bst").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "bst@iku.edu.tr",
                    name = "bst",
                    surname = "bst",
                    age = 0,
                    gender = "bst",
                    Email = "bst@iku.edu.tr",
                    department = "bst",
                    roomNo = "bst",
                    title = "bst",
                };
                var result = userManager.CreateAsync(user, "A.a123").Result;
                if (result.Succeeded)
                {

                    if (!roleManager.RoleExistsAsync("admin").Result)
                    {
                        ApplicationRole role = new ApplicationRole()
                        {
                            Name = "admin"
                        };
                        IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                    }
                    userManager.AddToRoleAsync(user, "admin").Wait();

                }
            }
        }
    }
}
