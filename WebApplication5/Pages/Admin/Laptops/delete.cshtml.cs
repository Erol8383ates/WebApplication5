using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.Laptops
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Laptop Laptop { get; set; } // The laptop to be deleted

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET method to load the laptop details to confirm deletion
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Laptops/Index");
            }

            var laptop = _context.Laptops.Find(id);
            if (laptop == null)
            {
                return RedirectToPage("/Admin/Laptops/Index");
            }

            Laptop = laptop; // Set the Laptop property to display the details

            return Page(); // Show the delete confirmation page
        }

        // POST method to delete the laptop from the database
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Laptops/Index");
            }

            var laptop = _context.Laptops.Find(id);
            if (laptop == null)
            {
                return RedirectToPage("/Admin/Laptops/Index");
            }

            // Delete the laptop from the database
            _context.Laptops.Remove(laptop);
            _context.SaveChanges();

            SuccessMessage = "Laptop deleted successfully!";
            return RedirectToPage("/Admin/Laptops/Index"); // Redirect back to the index page
        }
    }
}
