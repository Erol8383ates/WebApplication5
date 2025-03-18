using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;
using System.Collections.Generic;

namespace WebApplication5.Pages.Admin.NetwerkMaterials
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public string SearchNaam { get; set; } = string.Empty; // Initialize with an empty string
        public string SearchLokaal { get; set; } = string.Empty; // Initialize with an empty string

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<NetwerkMaterial> NetwerkMaterials { get; set; }
     

        public void OnGet(string searchNaam, string searchLokaal)
        {
            // Set the filter properties to pass them back to the view
            SearchNaam = searchNaam ?? string.Empty;  // Default to empty string if null
            SearchLokaal = searchLokaal ?? string.Empty;  // Default to empty string if null

            // Start with all Computers
            var query = _context.NetwerkMaterials.AsQueryable(); // Use DbSet<Computer> from ApplicationDbContext

            // Apply filters if values are provided
            if (!string.IsNullOrEmpty(searchNaam))
            {
                query = query.Where(c => c.Naam.Contains(searchNaam));
            }

            if (!string.IsNullOrEmpty(searchLokaal))
            {
                query = query.Where(c => c.Lokaal.Contains(searchLokaal));
            }

            // Fetch filtered Computers and assign to the Computers list
            NetwerkMaterials = query.ToList();
        }
    }
}
