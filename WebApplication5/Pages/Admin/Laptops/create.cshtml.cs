using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;
using WebApplication5.Pages;
namespace WebApplication5.Pages.Admin.Laptops
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Laptop Laptop { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Laptops.Add(Laptop);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Admin/Laptops/Index");
        }
    }
}
