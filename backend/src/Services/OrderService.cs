using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Models;
using BackEnd.Repositories;
using System.Linq;
using ClosedXML.Excel;
using System.IO;

namespace BackEnd.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetOrderDetailAsync(int orderNumber)
        {
            try
            {
                return await _orderRepository.GetOrderDetailAsync(orderNumber);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Failed to retrieve order details: " + ex.Message);
            }
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderNumber)
        {
            try
            {
                var items = await _orderRepository.GetOrderItemsAsync(orderNumber);
                if (items == null) { throw new Exception("No items found for the order"); }
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve order items: " + ex.Message);
            }
        }

        public async Task<byte[]> ExportListToExcelAsync(int orderNumber, string listType)
        {
            // Only export items are implemented for demonstration
            try
            {
                byte[] fileContents = null;
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Data");

                    if (listType.ToLower() == "items")
                    {
                        var items = await _orderRepository.GetOrderItemsAsync(orderNumber);
                        if (items == null || !items.Any())
                            throw new Exception("No items data found to export");

                        // Header
                        worksheet.Cell(1, 1).Value = "ID";
                        worksheet.Cell(1, 2).Value = "Description";
                        worksheet.Cell(1, 3).Value = "Quantity";
                        worksheet.Cell(1, 4).Value = "Price";

                        int row = 2;
                        foreach (var item in items)
                        {
                            worksheet.Cell(row, 1).Value = item.Id;
                            worksheet.Cell(row, 2).Value = item.Description;
                            worksheet.Cell(row, 3).Value = item.Quantity;
                            worksheet.Cell(row, 4).Value = item.Price;
                            row++;
                        }
                    }
                    else
                    {
                        throw new Exception("Export for the specified list type is not implemented");
                    }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        fileContents = stream.ToArray();
                    }
                }
                return fileContents;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to export data: " + ex.Message);
            }
        }
    }
}
