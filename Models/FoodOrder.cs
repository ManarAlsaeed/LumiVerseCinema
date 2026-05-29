using System.ComponentModel.DataAnnotations;
 
namespace MiniCinema.Models
{
    public class FoodOrder
    {
        public int Id { get; set; }
 
        public int? BookingId { get; set; }
        public int? UserId { get; set; }
 
        public decimal TotalAmount { get; set; }
 
        public DateTime OrderedAt { get; set; } = DateTime.Now;
 
        // Navigation
        public Booking? Booking { get; set; }
        public User? User { get; set; }
        public ICollection<FoodOrderItem> Items { get; set; } = new List<FoodOrderItem>();
    }
 
    public class FoodOrderItem
    {
        public int Id { get; set; }
 
        public int FoodOrderId { get; set; }
        public int FoodItemId { get; set; }
 
        [Required, Range(1, 20)]
        public int Quantity { get; set; } = 1;
 
        public decimal UnitPrice { get; set; }
 
        // Navigation
        public FoodOrder? FoodOrder { get; set; }
        public FoodItem? FoodItem { get; set; }
    }
}