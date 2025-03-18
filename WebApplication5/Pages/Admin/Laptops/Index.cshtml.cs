using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication5.Pages.Admin.Laptops
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Properties for filtering
        public string SearchNaam { get; set; } = string.Empty; // Initialize with an empty string
        public string SearchLokaal { get; set; } = string.Empty; // Initialize with an empty string

        // List of Computers that will be displayed in the view
        public List<Laptop> Laptops { get; set; } = new List<Laptop>(); // Initialize to avoid nullability issues

        // Constructor initializes the context and list
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(string searchNaam, string searchLokaal)
        {
            // Set the filter properties to pass them back to the view
            SearchNaam = searchNaam ?? string.Empty;  // Default to empty string if null
            SearchLokaal = searchLokaal ?? string.Empty;  // Default to empty string if null

            // Start with all Computers
            var query = _context.Laptops.AsQueryable(); // Use DbSet<Computer> from ApplicationDbContext

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
            Laptops = query.ToList();
        }
    }
}
