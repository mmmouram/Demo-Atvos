using System.Threading.Tasks;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderDetailAsync(int orderNumber);
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderNumber);
        // Additional methods for Observations, Blocks and Invoices can be added here if needed
    }
}
