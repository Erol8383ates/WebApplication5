using WebApplication5.Pages;
using WebApplication5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication5.Services;
using Microsoft.Data.SqlClient;  // Add this namespace for SqlException

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
        public IActionResult OnGet()
        {
            try
            {
                // Try fetching the printers from the database
                Printers = _context.Printers.ToList();
            }
            catch (SqlException ex)
            {
                // Log detailed exception information
                // You can log it to a file, a database, or just output it to the console
                Console.WriteLine("SQL Error Number: " + ex.Number);
                Console.WriteLine("SQL Error Message: " + ex.Message);
                Console.WriteLine("SQL Error Stack Trace: " + ex.StackTrace);

                // Optionally, return an error view or a custom message
                ViewData["ErrorMessage"] = "There was an issue fetching printers from the database.";
                return RedirectToPage("/Error"); // You can change this to an appropriate error page
            }

            return Page(); // Return the page with the list of printers
        }
    }
}
