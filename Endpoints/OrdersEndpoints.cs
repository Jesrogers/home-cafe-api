using HomeCafeApi.Database;
using HomeCafeApi.Services;
using HomeCafeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeApi.Endpoints
{
    public static class OrdersEndpoints
    {
        public static void RegisterOrdersEndpoints(this WebApplication app)
        {
            var orders = app.MapGroup("/orders");

            orders.MapGet("/", GetAllOrders);
            orders.MapGet("/{id}", GetOrder);
            orders.MapPost("/", CreateOrder);
        }

        static async Task<IResult> GetAllOrders(string? status, IOrdersService ordersService)
        {
            return TypedResults.Ok(await ordersService.GetAllOrders(status));
        }

        static async Task<IResult> GetOrder(IOrdersService ordersService, long id)
        {
            return TypedResults.Ok(await ordersService.GetOrder(id));
        }

        static async Task<IResult> CreateOrder(Order order, IOrdersService ordersService) 
        {
            await ordersService.CreateOrder(order);
            return TypedResults.Created($"/orders/{order.Id}", order);
        }
    }
}
