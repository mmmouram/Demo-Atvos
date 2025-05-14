using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BackEnd.Services;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Retrieves the complete details of an order including client info, items, observations, blocks and invoices.
        /// </summary>
        /// <param name="orderNumber">Order identifier</param>
        [HttpGet("{orderNumber}")]
        public async Task<IActionResult> GetOrderDetail(int orderNumber)
        {
            try
            {
                var order = await _orderService.GetOrderDetailAsync(orderNumber);
                if (order == null)
                {
                    return NotFound(new { message = "Order not found" });
                }
                return Ok(order);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves the updated list of order items.
        /// </summary>
        /// <param name="orderNumber">Order identifier</param>
        [HttpGet("{orderNumber}/items")]
        public async Task<IActionResult> GetOrderItems(int orderNumber)
        {
            try
            {
                var items = await _orderService.GetOrderItemsAsync(orderNumber);
                if (items == null)
                {
                    return NotFound(new { message = "Items not found for the given order" });
                }
                return Ok(items);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Exports the specified list (ex: items, observations, blocks, invoices) of an order to an Excel file.
        /// </summary>
        /// <param name="orderNumber">Order identifier</param>
        /// <param name="listType">Type of list to export (e.g., items)</param>
        [HttpGet("{orderNumber}/export")]
        public async Task<IActionResult> ExportListToExcel(int orderNumber, [FromQuery] string listType)
        {
            try
            {
                var fileBytes = await _orderService.ExportListToExcelAsync(orderNumber, listType);
                if (fileBytes == null)
                {
                    return NotFound(new { message = "No data found to export" });
                }
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{listType}_{orderNumber}.xlsx");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
