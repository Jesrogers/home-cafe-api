using HomeCafeApi.Database;
using HomeCafeApi.Models;
using HomeCafeApi.Services;
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

        static async Task<IResult> GetAllMenuItems(IMenuItemService menuItemService)
        {
            return TypedResults.Ok(await menuItemService.GetAllMenuItems());
        }
        static async Task<IResult> GetMenuItem(long id, IMenuItemService menuItemService)
        {
            var item = await menuItemService.GetMenuItem(id);

            return item is not null
                    ? TypedResults.Ok(item)
                    : TypedResults.NotFound();
        }

        static async Task<IResult> CreateMenuItem(MenuItem menuItem, IMenuItemService menuItemService)
        {
            await menuItemService.CreateMenuItem(menuItem);
            return TypedResults.Created($"/menuItems/{menuItem.Id}", menuItem);
        }

    }
}
