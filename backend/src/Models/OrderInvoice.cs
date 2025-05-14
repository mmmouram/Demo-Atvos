using System;

namespace BackEnd.Models
{
    public class OrderInvoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
