using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCinema.Data;
using MiniCinema.Models;
 
namespace MiniCinema.Controllers
{
    public class FoodController : Controller
    {
        private readonly CinemaDbContext _context;
        public FoodController(CinemaDbContext context) => _context = context;
 
        // GET: /Food
        public async Task<IActionResult> Index()
        {
            var items = await _context.FoodItems
                .Where(f => f.IsAvailable)
                .OrderBy(f => f.Category)
                .ToListAsync();
 
            return View(items);
        }
 
        // POST: /Food/Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(Dictionary<int, int> quantities, int? bookingId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");
 
            var selectedItems = quantities
                .Where(q => q.Value > 0)
                .ToList();
 
            if (!selectedItems.Any())
            {
                TempData["Error"] = "Please select at least one item.";
                return RedirectToAction("Index");
            }
 
            var order = new FoodOrder
            {
                UserId = userId,
                BookingId = bookingId,
                OrderedAt = DateTime.Now
            };
 
            decimal total = 0;
            var orderItems = new List<FoodOrderItem>();
 
            foreach (var item in selectedItems)
            {
                var foodItem = await _context.FoodItems.FindAsync(item.Key);
                if (foodItem == null) continue;
 
                var unitPrice = foodItem.Price;
                total += unitPrice * item.Value;
 
                orderItems.Add(new FoodOrderItem
                {
                    FoodItemId = item.Key,
                    Quantity = item.Value,
                    UnitPrice = unitPrice
                });
            }
 
            order.TotalAmount = total;
            _context.FoodOrders.Add(order);
            await _context.SaveChangesAsync();
 
            foreach (var oi in orderItems)
            {
                oi.FoodOrderId = order.Id;
                _context.FoodOrderItems.Add(oi);
            }
            await _context.SaveChangesAsync();
 
            TempData["Success"] = $"Food order placed! Total: ${total:F2}. Will be ready at your seat before the show.";
            return RedirectToAction("Index");
        }
    }
}