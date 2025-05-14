using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using BackEnd.Config;
using System.Collections.Generic;

namespace BackEnd.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderDetailAsync(int orderNumber)
        {
            // Using eager loading to get related entities
            return await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Items)
                .Include(o => o.Observations)
                .Include(o => o.Blocks)
                .Include(o => o.Invoices)
                .FirstOrDefaultAsync(o => o.OrderNumber == orderNumber);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderNumber)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.OrderNumber == orderNumber);
            return order?.Items;
        }
    }
}
