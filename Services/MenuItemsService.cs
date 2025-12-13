using HomeCafeApi.Database;
using HomeCafeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeApi.Services
{
    public class MenuItemsService : IMenuItemService
    {
        private readonly HomeCafeDb _db;

        public MenuItemsService(HomeCafeDb db) { 
            _db = db;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
            return await _db.MenuItems.ToListAsync();
        }

        public async Task<MenuItem?> GetMenuItem(long id)
        {
            return await _db.MenuItems.FindAsync(id);
        }

        public async Task<MenuItem> CreateMenuItem(MenuItem item)
        {
            _db.MenuItems.Add(item);
            await _db.SaveChangesAsync();

            return item;
        }
    }


    public interface IMenuItemService
    {
        public Task<IEnumerable<MenuItem>> GetAllMenuItems();
        public Task<MenuItem?> GetMenuItem(long id);
        public Task<MenuItem> CreateMenuItem(MenuItem item);
    }
}
