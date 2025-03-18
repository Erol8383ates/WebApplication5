using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.NetwerkMaterials
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public NetwerkMaterial NetwerkMaterial { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET method to load the NetwerkMaterial to delete
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/NetwerkMaterials/Index"); // Redirect to index if no id is provided
            }

            NetwerkMaterial = _context.NetwerkMaterials.Find(id); // Fetch the NetwerkMaterial from the database

            if (NetwerkMaterial == null)
            {
                return RedirectToPage("/Admin/NetwerkMaterials/Index"); // Redirect to index if NetwerkMaterial not found
            }

            return Page(); // Render the Delete confirmation page
        }

        // POST method to delete the NetwerkMaterial after confirmation
        public IActionResult OnPost()
        {
            if (NetwerkMaterial != null)
            {
                _context.NetwerkMaterials.Remove(NetwerkMaterial); // Remove the NetwerkMaterial from the database
                _context.SaveChanges(); // Commit the changes
            }

            return RedirectToPage("/Admin/NetwerkMaterials/Index"); // Redirect back to the NetwerkMaterials list
        }
    }
}
