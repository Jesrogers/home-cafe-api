using HomeCafeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeApi.Database
{
    public class HomeCafeDb : DbContext
    {
        public HomeCafeDb(DbContextOptions<HomeCafeDb> options) : base(options) { }

        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<Order> Orders => Set<Order>();

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

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.MenuItemId).HasColumnName("menu_item_id");
                entity.Property(e => e.CustomerName).HasColumnName("customer_name");
                entity.Property(e => e.Sweetener).HasColumnName("sweetener");
                entity.Property(e => e.SpecialRequests).HasColumnName("special_requests");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne<MenuItem>()
                      .WithMany()
                      .HasForeignKey(o => o.MenuItemId)
                      .OnDelete(DeleteBehavior.Cascade);
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
