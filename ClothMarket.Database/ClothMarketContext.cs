using ClothMarket.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothMarket.Database
{
    public class ClothMarketContext : IdentityDbContext<ClothMarketUser>, IDisposable    //DbContext, IDisposable //IdentityDbContext<ApplicationUser>
    {
        public ClothMarketContext() : base("ClothMarket")
        {

            ////Database.SetInitializer<ClothMarketContext>(new ClothDBinitializer());
            //Database.SetInitializer<ClothMarketContext>(new ClothDBinitializer());
            System.Data.Entity.Database.SetInitializer<ClothMarketContext>(new ClothDBinitializer());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Config> Configurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }



        public static ClothMarketContext Create()
        {
            return new ClothMarketContext();

        }



    }



}
