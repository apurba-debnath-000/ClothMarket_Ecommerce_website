using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClothMarket.Entities
{
    public class ClothMarketUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNO { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ClothMarketUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


    }
}
