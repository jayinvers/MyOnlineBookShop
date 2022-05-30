using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyOnlineShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }


        public decimal Total { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public List<IdentityUser> User { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        // 0 Unpaid, 1 completed
        public OrderStatusEnum OrderStatus { get; set; }



    }

    public enum OrderStatusEnum : ushort
    {
        Unpaid = 0,
        Completed = 1
    }
}
