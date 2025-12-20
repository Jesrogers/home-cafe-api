using HomeCafeApi.Database;
using HomeCafeApi.Models;
using HomeCafeApi.Models.Requests;
using HomeCafeApi.Services;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            orders.MapPatch("/{id}", UpdateOrderStatus);
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

        static async Task<IResult> UpdateOrderStatus(long id, UpdateOrderStatusRequest request, IOrdersService orderService)
        {
            if (string.IsNullOrWhiteSpace(request.Status))
            {
                return TypedResults.BadRequest("Status is required.");
            }

            try
            {
                var updatedOrder = await orderService.UpdateOrderStatus(id, request.Status);

                return updatedOrder is null
                    ? TypedResults.NotFound()
                    : TypedResults.Ok(updatedOrder);
            }
            catch (ArgumentException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
