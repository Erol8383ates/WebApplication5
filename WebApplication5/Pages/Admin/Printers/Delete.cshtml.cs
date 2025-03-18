using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.Printers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Printer Printer { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET method to load the product to delete
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Products/Index"); // Redirect to index if no id is provided
            }

            Printer = _context.Printers.Find(id); // Fetch the product from the database

            if (Printer == null)
            {
                return RedirectToPage("/Admin/Printers/Index"); // Redirect to index if product not found
            }

            return Page(); // Render the Delete confirmation page
        }

        // POST method to delete the product after confirmation
        public IActionResult OnPost()
        {
            if (Printer != null)
            {
                _context.Printers.Remove(Printer); // Remove the product from the database
                _context.SaveChanges(); // Commit the changes
            }

            return RedirectToPage("/Admin/Printers/Index"); // Redirect back to the products list
        }
    }
}
