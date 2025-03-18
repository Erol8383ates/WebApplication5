using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.Computers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Computer Computer { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET method to load the product to delete
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Computers/Index"); // Redirect to index if no id is provided
            }

            Computer = _context.Computers.Find(id); // Fetch the product from the database

            if (Computer == null)
            {
                return RedirectToPage("/Admin/Computers/Index"); // Redirect to index if product not found
            }

            return Page(); // Render the Delete confirmation page
        }

        // POST method to delete the product after confirmation
        public IActionResult OnPost()
        {
            if (Computer != null)
            {
                _context.Computers.Remove(Computer); // Remove the product from the database
                _context.SaveChanges(); // Commit the changes
            }

            return RedirectToPage("/Admin/Computers/Index"); // Redirect back to the computers list
        }
    }
}

