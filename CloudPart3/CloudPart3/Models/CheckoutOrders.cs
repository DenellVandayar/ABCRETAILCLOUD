using System.ComponentModel.DataAnnotations;

namespace CloudPart3.Models
{
    public class CheckoutOrders
    {
        [Key]
        public int? OrderId { get; set; }
        public string? CustomerId { get; set; }
        public int? ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? CustomerName { get; set; }
        public int? quantity { get; set; }
        public string? Address { get; set; }
        public DateTime CheckoutDateTime { get; set; }
        public string? PhoneNumber { get; set; }
        public double? TotalPrice { get; set; }
        public string? OrderStatus { get; set; } = "Not Processed";


    }
}
