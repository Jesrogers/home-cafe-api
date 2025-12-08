using HomeCafeApi.Database;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeApi.Endpoints
{
    public static class OrdersEndpoints
    {
        public static void RegisterOrdersEndpoints(this WebApplication app)
        {
            var orders = app.MapGroup("/orders");

            orders.MapGet("/", GetAllOrders);
        }

        static async Task<IResult> GetAllOrders(HomeCafeDb db)
        {
            return TypedResults.Ok(await db.Orders.ToListAsync());
        }
    }
}
