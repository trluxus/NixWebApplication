using NixWebApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NixWebApplication.DAL.EF
{
    public class NixAppContext : IdentityDbContext<NixWebApplicationUser>
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<PriceToCategory> PricesToCategories { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public NixAppContext(DbContextOptions<NixAppContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PriceToCategory>().Property(i => i.Price).HasPrecision(9, 2);

            modelBuilder.Entity<Guest>().HasData(SeedData.GuestInitializer());
            modelBuilder.Entity<Category>().HasData(SeedData.CategoryInitializer());
            modelBuilder.Entity<PriceToCategory>().HasData(SeedData.PriceToCategoryInitializer());
            modelBuilder.Entity<Room>().HasData(SeedData.RoomInitializer());
        }
    }
}
