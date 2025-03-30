using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using System.Collections.Generic;
using System.Linq;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.Beamers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Properties for filtering
        public string SearchLokaal { get; set; } = string.Empty; // Initialize with an empty string
        public string SearchMerkModel { get; set; } = string.Empty; // Initialize with an empty string

        // List of Beamers that will be displayed in the view
        public List<Beamer> Beamers { get; set; } = new List<Beamer>(); // Initialize to avoid nullability issues

        // Constructor initializes the context and list
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(string searchLokaal, string searchMerkModel)
        {
            // Set the filter properties to pass them back to the view
            SearchLokaal = searchLokaal ?? string.Empty;  // Default to empty string if null
            SearchMerkModel = searchMerkModel ?? string.Empty;  // Default to empty string if null

            // Start with all Beamers
            var query = _context.Beamers.AsQueryable(); // Use DbSet<Beamer> from ApplicationDbContext

            // Apply filters if values are provided
            if (!string.IsNullOrEmpty(searchLokaal))
            {
                query = query.Where(b => b.Lokaal.Contains(searchLokaal));
            }

            if (!string.IsNullOrEmpty(searchMerkModel))
            {
                query = query.Where(b => b.MerkModel.Contains(searchMerkModel));
            }

            // Fetch filtered Beamers and assign to the Beamers list
            Beamers = query.ToList();
        }
    }
}

