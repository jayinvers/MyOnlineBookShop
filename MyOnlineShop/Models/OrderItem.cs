namespace MyOnlineShop.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        
        public int BookId { get; set; }
        public Book Book { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
