using System.Threading.Tasks;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrderDetailAsync(int orderNumber);
        Task<IEnumerable<BackEnd.Models.OrderItem>> GetOrderItemsAsync(int orderNumber);
        Task<byte[]> ExportListToExcelAsync(int orderNumber, string listType);
    }
}
