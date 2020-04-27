
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothMarket.Entities;

namespace ClothMarket.Database
{
    public class ClothDBinitializer : CreateDatabaseIfNotExists<ClothMarketContext>
    {
        protected override void Seed(ClothMarketContext context)
        {
            seedRoles(context);
            seedUsers(context);
        }
        public void seedRoles(ClothMarketContext context)
        {
            List<IdentityRole> rolesInCB = new List<IdentityRole>();
            rolesInCB.Add(new IdentityRole() { Name = "Administrator" });
            rolesInCB.Add(new IdentityRole() { Name = "Moderator" });
            rolesInCB.Add(new IdentityRole() { Name = "User" });

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            foreach (IdentityRole role in rolesInCB)
            {
                if (!roleManager.RoleExists(role.Name))
                {
                    var result = roleManager.Create(role);

                    if (result.Succeeded) continue;

                }
            }

        }

        public void seedUsers(ClothMarketContext context)
        {
            var userStore = new UserStore<ClothMarketUser>(context);
            var userManager = new UserManager<ClothMarketUser>(userStore);

            ClothMarketUser admin = new ClothMarketUser();
            admin.Email = "admin@gmail.com";
            admin.UserName = "admin";
            var password = "admin123";


            if (userManager.FindByEmail(admin.Email) == null)
            {
                var results = userManager.Create(admin, password);
                if (results.Succeeded)
                {
                    userManager.AddToRole(admin.Id, "Administrator");
                    userManager.AddToRole(admin.Id, "Moderator");
                    userManager.AddToRole(admin.Id, "User");
                }
            }
        }
    }
}
