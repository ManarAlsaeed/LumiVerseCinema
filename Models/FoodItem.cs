using System.ComponentModel.DataAnnotations;
 
namespace MiniCinema.Models
{
    public enum FoodCategory { Popcorn, Drinks, Combo, Snacks, Desserts }
 
    public class FoodItem
    {
        public int Id { get; set; }
 
        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;
 
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;
 
        [Required]
        public decimal Price { get; set; }
 
        public FoodCategory Category { get; set; } = FoodCategory.Snacks;
 
        public string ImageUrl { get; set; } = string.Empty;
 
        public bool IsAvailable { get; set; } = true;
 
        public bool IsBestSeller { get; set; } = false;
 
        // Navigation
        public ICollection<FoodOrderItem> FoodOrderItems { get; set; } = new List<FoodOrderItem>();
    }
}