using HomeCafeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeApi.Database
{
    public class HomeCafeDb : DbContext
    {
        public HomeCafeDb(DbContextOptions<HomeCafeDb> options) : base(options) { }

        public DbSet<MenuItem> MenuItems => Set<MenuItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>().ToTable("menu_items");

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Cappuccino",
                    Description = "Rich espresso with steamed milk foam",
                    Price = 4.5m
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Latte",
                    Description = "Smooth espresso with creamy milk",
                    Price = 4.0m
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Mocha",
                    Description = "Chocolate espresso delight",
                    Price = 4.75m
                },
                new MenuItem
                {
                    Id = 4,
                    Name = "Chai Latte",
                    Description = "Spiced tea with steamed milk",
                    Price = 4.25m
                },
                new MenuItem
                {
                    Id = 5,
                    Name = "Matcha Latte",
                    Description = "Creamy green tea latte",
                    Price = 4.50m
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
