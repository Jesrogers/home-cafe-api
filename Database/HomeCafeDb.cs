using HomeCafeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeApi.Database
{
    public class HomeCafeDb : DbContext
    {
        public HomeCafeDb(DbContextOptions<HomeCafeDb> options) : base(options) { }

        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    }
}
