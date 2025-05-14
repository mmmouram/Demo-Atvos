namespace BackEnd.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
