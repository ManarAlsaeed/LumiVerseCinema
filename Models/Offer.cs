using System.ComponentModel.DataAnnotations;
 
namespace MiniCinema.Models
{
    public enum OfferType { Percentage, FixedAmount, BuyOneGetOne, ComboMeal }
 
    public class Offer
    {
        public int Id { get; set; }
 
        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;
 
        [Required, MaxLength(500)]
        public string Description { get; set; } = string.Empty;
 
        public OfferType Type { get; set; } = OfferType.Percentage;
 
        // e.g. 20 for 20% off OR 5.00 for $5 off
        [Range(0, 100)]
        public decimal DiscountValue { get; set; }
 
        [Required, MaxLength(30)]
        public string PromoCode { get; set; } = string.Empty;
 
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today.AddMonths(1);
 
        public bool IsActive { get; set; } = true;
 
        public string BadgeColor { get; set; } = "warning"; // Bootstrap color
 
        public string ImageUrl { get; set; } = string.Empty;
 
        // Applies to specific hall type? null = all halls
        public HallType? ApplicableHallType { get; set; } = null;
    }
}