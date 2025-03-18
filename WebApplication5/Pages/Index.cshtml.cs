using WebApplication5.Pages;
using WebApplication5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.Printers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // This property will hold the list of printers fetched from the database
        public List<Printer> Printers { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // This method is called when the page is loaded (GET request)
        public void OnGet()
        {
            Printers = _context.Printers.ToList();
        }
    }
}
