using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public OrderClient Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public List<OrderObservation> Observations { get; set; } = new List<OrderObservation>();
        public List<OrderBlock> Blocks { get; set; } = new List<OrderBlock>();
        public List<OrderInvoice> Invoices { get; set; } = new List<OrderInvoice>();
    }
}
