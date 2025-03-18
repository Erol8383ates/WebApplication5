using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.Beamers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Beamer Beamer { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET method to load the product to delete
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Beamers/Index"); // Redirect to index if no id is provided
            }

            Beamer = _context.Beamers.Find(id); // Fetch the product from the database

            if (Beamer == null)
            {
                return RedirectToPage("/Admin/Beamers/Index"); // Redirect to index if product not found
            }

            return Page(); // Render the Delete confirmation page
        }

        // POST method to delete the product after confirmation
        public IActionResult OnPost()
        {
            if (Beamer != null)
            {
                _context.Beamers.Remove(Beamer); // Remove the product from the database
                _context.SaveChanges(); // Commit the changes
            }

            return RedirectToPage("/Admin/Beamers/Index"); // Redirect back to the products list
        }
    }
}
