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
                entity.Property(e => e.ShouldAllowCaffeine).HasColumnName("should_allow_caffeine");
                entity.Property(e => e.ShouldAllowSugar).HasColumnName("should_allow_sugar");
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

                entity.HasOne(o => o.MenuItem)    
                      .WithMany()        
                      .HasForeignKey(o => o.MenuItemId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Cafe Latte",
                    Description = "espresso, steamed milk"
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Iced Cafe Latte",
                    Description = "espresso, milk, ice"
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Iced Americano",
                    Description = "espresso, water, ice"
                },
                new MenuItem
                {
                    Id = 4,
                    Name = "Americano",
                    Description = "espresso, hot water"
                },
                new MenuItem
                {
                    Id = 5,
                    Name = "Matcha Latte",
                    Description = "matcha, steamed milk"
                },
                new MenuItem
                {
                    Id = 6,
                    Name = "Iced Matcha Latte",
                    Description = "matcha, milk, ice"
                },
                new MenuItem
                {
                    Id = 7,
                    Name = "Hojicha Latte",
                    Description = "hojicha, steamed milk"
                },
                new MenuItem
                {
                    Id = 8,
                    Name = "Iced Hojicha Latte",
                    Description = "hojicha, milk, ice"
                },
                new MenuItem
                {
                    Id = 9,
                    Name = "Hot Chocolate",
                    Description = "hot chocolate mix, steamed milk"
                },
                new MenuItem
                {
                    Id = 10,
                    Name = "Tea",
                    Description = "please ask JP for current tea selection"
                },
                new MenuItem
                {
                    Id = 11,
                    Name = "Iced Pumpkin Spice Latte (seasonal)",
                    Description = "espresso, milk, ice, pumpkin syrup, whipped cream"
                },
                new MenuItem
                {
                    Id = 12,
                    Name = "Iced Peppermint Mocha (seasonal)",
                    Description = "espresso, milk, ice, chocolate sauce, peppermint flavor, whipped cream, candy cane topping"
                },
                new MenuItem
                {
                    Id = 13,
                    Name = "Iced Jasmine Latte",
                    Description = "jasmine tea, milk, ice"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
