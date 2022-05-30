namespace MyOnlineShop.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }

        public int? CategoryId { get; set; }

        public DateTime Created { get; set; }

      
    }

}
