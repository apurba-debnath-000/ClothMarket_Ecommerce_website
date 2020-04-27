using ClothMarket.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClothMarket.Services
{
    public class ClothMarketSignInManager : SignInManager<ClothMarketUser, string>
    {
        public ClothMarketSignInManager(ClothMarketUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ClothMarketUser user)
        {
            return user.GenerateUserIdentityAsync((ClothMarketUserManager)UserManager);
        }

        public static ClothMarketSignInManager Create(IdentityFactoryOptions<ClothMarketSignInManager> options, IOwinContext context)
        {
            return new ClothMarketSignInManager(context.GetUserManager<ClothMarketUserManager>(), context.Authentication);
        }
    }
}
