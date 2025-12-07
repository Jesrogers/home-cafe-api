using HomeCafeApi.Database;
using HomeCafeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeApi.Endpoints
{
    public static class MenuItemsEndpoints
    {
        public static void RegisterMenuItemsEndpoints(this WebApplication app)
        {
            var menuItems = app.MapGroup("/menuItems");

            menuItems.MapGet("/", GetAllMenuItems);
            menuItems.MapGet("/{id}", GetMenuItem);
            menuItems.MapPost("/", CreateMenuItem);
        }

        static async Task<IResult> GetAllMenuItems(HomeCafeDb db)
        {
            return TypedResults.Ok(await db.MenuItems.ToListAsync());
        }
        static async Task<IResult> GetMenuItem(int id, HomeCafeDb db)
        {
            return await db.MenuItems.FindAsync(id)
                is MenuItem menuItem
                    ? TypedResults.Ok(menuItem)
                    : TypedResults.NotFound();
        }

        static async Task<IResult> CreateMenuItem(MenuItem menuItem, HomeCafeDb db)
        {
            db.MenuItems.Add(menuItem);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/menuItems/{menuItem.Id}", menuItem);
        }

    }
}
