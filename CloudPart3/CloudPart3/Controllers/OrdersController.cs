using CloudPart3.Areas.Identity.Data;
using CloudPart3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudPart3.Controllers
{
    public class OrdersController : Controller
    {


        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public OrdersController(
        
        UserManager<ApplicationUser> userManager,
        ApplicationDbContext context)
        {
            
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Cart()
        {
            var user = await _userManager.GetUserAsync(User);
            var customerEmail = user?.Email;

            // Fetch the cart orders for the current user
            var orders = await _context.CartOrders
                .Where(o => o.CustomerId == customerEmail)
                .ToListAsync();

            if (orders == null || !orders.Any())
            {
                orders = new List<CartOrders>(); // Return an empty list if no items are found
            }
            return View(orders);
        }


        public async Task<IActionResult> OrderItem(int itemId)
        {
            var item = await _context.Items.FindAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }

            var model = new CartOrders
            {
                ItemId = item.Item_Id,
                ItemName = item.Name,
                TotalPrice = item.Price
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CartOrders model)
        {
            if (ModelState.IsValid)
            {
                var item = await _context.Items.FindAsync(model.ItemId);
                if (item == null)
                {
                    return NotFound();
                }

                var user = await _userManager.GetUserAsync(User);
                var customerEmail = user?.Email;

                var customerName = user?.FirstName;

                // Check if there's enough quantity available
                if (item.AvailableQuantity >= model.quantity)
                {
                    var order = new CartOrders
                    {
                        
                        ItemId = model.ItemId,
                        ItemName = item.Name,
                        CustomerId = customerEmail,
                        CustomerName = customerName,
                        quantity = model.quantity,
                        Address=model.Address,
                        PhoneNumber=model.PhoneNumber,
                        TotalPrice = item.Price * model.quantity,
                        OrderDateTime = DateTime.Now
                    };

                    // Decrease the available quantity of the item
                    item.AvailableQuantity -= model.quantity;

                    // Save the order and the updated item
                    _context.CartOrders.Add(order);
                    _context.Items.Update(item);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("OrderSuccess");
                }
                else
                {
                    return RedirectToAction("StockLimitExceeded", new { availableQuantity = item.AvailableQuantity, requestedQuantity = model.quantity });
                }
            }

            return View(model); // Return the view with the model in case of an error
        }

        public IActionResult StockLimitExceeded(int availableQuantity, int requestedQuantity)
        {
            // Pass the available and requested quantities to the view using ViewBag
            ViewBag.AvailableQuantity = availableQuantity;
            ViewBag.RequestedQuantity = requestedQuantity;

            return View();
        }


        public IActionResult OrderSuccess()
        {
            return View();
        }

        public IActionResult CheckoutSuccess()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.CartOrders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            // Find the associated item and restore the quantity
            var item = await _context.Items.FindAsync(order.ItemId);
            if (item != null)
            {
                item.AvailableQuantity += order.quantity;
                _context.Items.Update(item);
            }

            _context.CartOrders.Remove(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Cart"); // Redirect to the cart view after deletion
        }


        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            // Get the current user's email
            var user = await _userManager.GetUserAsync(User);
            var customerEmail = user?.Email;

            

            // Get all cart orders for the current user
            var cartOrders = await _context.CartOrders
                .Where(co => co.CustomerId == customerEmail)
                .ToListAsync();

            if (!cartOrders.Any())
            {
                ModelState.AddModelError("", "Your cart is empty.");
                return RedirectToAction("Cart"); // Redirect back to the cart if it's empty
            }

            // Loop through the cart orders and move them to the checkout table
            foreach (var cartOrder in cartOrders)
            {
                var checkout = new CheckoutOrders
                {
                    
                    ItemId = cartOrder.ItemId,
                    ItemName = cartOrder.ItemName,
                    Address = cartOrder.Address,
                    PhoneNumber = cartOrder.PhoneNumber,
                    CustomerId = cartOrder.CustomerId,
                    CustomerName = cartOrder.CustomerName,
                    quantity = cartOrder.quantity,
                    TotalPrice = cartOrder.TotalPrice,
                    CheckoutDateTime = DateTime.Now
                };

                // Add the order to the checkout table
                _context.CheckoutOrders.Add(checkout);
            }

            // Remove the orders from the cart
            _context.CartOrders.RemoveRange(cartOrders);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Redirect to a success page after checkout
            return RedirectToAction("CheckoutSuccess");
        }

        public async Task<IActionResult> CheckoutHistory()
        {
            // Get the current user's email
            var user = await _userManager.GetUserAsync(User);
            var customerEmail = user?.Email;

            // Fetch all checkouts for the current user
            var checkoutHistory = await _context.CheckoutOrders
                .Where(c => c.CustomerId == customerEmail)
                .ToListAsync();

            return View(checkoutHistory);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder(int orderId)
        {
            var order = await _context.CheckoutOrders.FindAsync(orderId);
            if (order != null)
            {
                // Update the status to "Processed"
                order.OrderStatus = "Processed";

                // Save the changes to the database
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Order processed successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Order not found!";
            }

            // Redirect to the view that lists all orders (adjust if needed)
            return View();
        }

        public async Task<IActionResult> TrackOrder()
        {
            var user = await _userManager.GetUserAsync(User);
            var customerEmail = user?.Email;

            // Fetch the cart orders for the current user
            var orders = await _context.CheckoutOrders
                .Where(o => o.CustomerId == customerEmail)
                .ToListAsync();

            if (orders == null || !orders.Any())
            {
                orders = new List<CheckoutOrders>(); // Return an empty list if no items are found
            }
            return View(orders);
        }

        public async Task<IActionResult> ManageOrders()
        {
            

            // Fetch the cart orders for the current user
            var orders = await _context.CheckoutOrders.ToListAsync();

            if (orders == null || !orders.Any())
            {
                orders = new List<CheckoutOrders>(); // Return an empty list if no items are found
            }
            return View(orders);
           
        }
    }
}
