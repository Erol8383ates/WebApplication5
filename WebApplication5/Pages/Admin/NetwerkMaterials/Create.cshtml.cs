using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.NetwerkMaterials
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject ApplicationDbContext
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NetwerkMaterial NetwerkMaterial { get; set; }  // Changed from Printer to NetwerkMaterial

        public IActionResult OnGet()
        {
            return Page();  // When GET is called, return the create page
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();  // If the model state is invalid, return to the same page
            }

            _context.NetwerkMaterials.Add(NetwerkMaterial);  // Add the new NetwerkMaterial to the database
            await _context.SaveChangesAsync();  // Save the changes asynchronously
            return RedirectToPage("/Admin/NetwerkMaterials/Index");  // Redirect to the index page after saving
        }
    }
}
