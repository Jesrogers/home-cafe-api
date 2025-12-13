using HomeCafeApi.Database;
using HomeCafeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeCafeApi.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly HomeCafeDb _db;

        public OrdersService(HomeCafeDb db) { 
            _db = db;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrder(long id)
        {
            return await _db.Orders.FindAsync(id);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return order;
        }
    }



    public interface IOrdersService
    {
        public Task<IEnumerable<Order>> GetAllOrders();
        public Task<Order?> GetOrder(long id);
        public Task<Order> CreateOrder(Order order);
    }
}
