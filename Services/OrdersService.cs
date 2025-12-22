using HomeCafeApi.Database;
using HomeCafeApi.Models;
using HomeCafeApi.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeApi.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly HomeCafeDb _db;

        public OrdersService(HomeCafeDb db) { 
            _db = db;
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrders(string? status)
        {
            IQueryable<Order> query = _db.Orders.Include(o => o.MenuItem);

            if (!string.IsNullOrWhiteSpace(status))
            {
                var normalized = status.Trim().ToLower();
                query = query.Where(o => o.Status.ToLower() == normalized);
            }

            return await query
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    MenuItemName = o.MenuItem.Name,
                    CustomerName = o.CustomerName,
                    Sweetener = o.Sweetener,
                    SpecialRequests = o.SpecialRequests,
                    Status = o.Status,
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<OrderResponse?> GetOrder(long id)
        {
            return await _db.Orders
                .Include(o => o.MenuItem)
                .Where(o => o.Id == id)
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    MenuItemName = o.MenuItem.Name,
                    CustomerName = o.CustomerName,
                    Sweetener = o.Sweetener,
                    SpecialRequests = o.SpecialRequests,
                    Status = o.Status,
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return order;
        }

        public async Task<Order?> UpdateOrderStatus(long id, string status)
        {
            var order = await _db.Orders.FindAsync(id);

            if (order is null)
            {
                return null;
            }

            order.Status = status.Trim();
            await _db.SaveChangesAsync();

            return order;
        }
    }



    public interface IOrdersService
    {
        Task<IEnumerable<OrderResponse>> GetAllOrders(string? status);
        Task<OrderResponse?> GetOrder(long id);
        Task<Order> CreateOrder(Order order);
        Task<Order?> UpdateOrderStatus(long id, string status);
    }
}
