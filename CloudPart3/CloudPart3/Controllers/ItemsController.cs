using CloudPart3.Areas.Identity.Data;
using CloudPart3.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CloudPart3.Controllers
{
    public class ItemsController : Controller
    { 

        private readonly ApplicationDbContext _context;

    public ItemsController(ApplicationDbContext context)
    {
        
        _context = context;
    }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Items.ToListAsync();

            if (items == null || !items.Any())
            {
                items = new List<Items>(); // Return an empty list if no items are found
            }
            return View(items);
        }

        public async Task<IActionResult> ManageItems()
        {
            var items = await _context.Items.ToListAsync();

            if (items == null || !items.Any())
            {
                items = new List<Items>(); // Return an empty list if no items are found
            }
            return View(items);
        }


        [HttpGet]
        public IActionResult AddItem()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(Items item, IFormFile ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload != null && ImageUpload.Length > 0)
                {
                    // Convert the uploaded file to a byte array
                    using (var memoryStream = new MemoryStream())
                    {
                        await ImageUpload.CopyToAsync(memoryStream);
                        item.ImageData = memoryStream.ToArray();
                    }

                    // Save the MIME type of the image (e.g., "image/jpeg", "image/png")
                    item.ImageMimeType = ImageUpload.ContentType;
                }

               

                // Add the new item to the database
                _context.Items.Add(item);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("ManageItems");
        }

        public IActionResult GetImage(int id)
        {
            var item = _context.Items.Find(id);

            if (item != null && item.ImageData != null)
            {
                return File(item.ImageData, item.ImageMimeType);
            }

            // Return a default image if no image is found
            return NotFound();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item); // Optional: show a delete confirmation view
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ManageItems)); // After deletion, redirect to the index page
        }

        [HttpGet]
        public async Task<IActionResult> EditItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            // Return the item to the view for editing
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditItem(int id, [Bind("Item_Id, Name, Description, Price, AvailableQuantity")] Items item, IFormFile imageFile)
        {
            if (id != item.Item_Id)
            {
                return BadRequest();
            }

            // Fetch the existing item from the database (including its image data)
            var existingItem = await _context.Items.AsNoTracking().FirstOrDefaultAsync(i => i.Item_Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // If a new image file is uploaded, update the image data
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await imageFile.CopyToAsync(memoryStream);
                            item.ImageData = memoryStream.ToArray(); // Save binary data
                            item.ImageMimeType = imageFile.ContentType; // Save MIME type
                        }
                    }
                    else
                    {
                        // If no new image is uploaded, keep the existing image data
                        item.ImageData = existingItem.ImageData;
                        item.ImageMimeType = existingItem.ImageMimeType;
                    }

                    // Update the other item fields (Name, Description, Price, etc.)
                    _context.Update(item);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(ManageItems));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Item_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(item);
        }


        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Item_Id == id);
        }
    }
}
