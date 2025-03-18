using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;  // Correct namespace for Printer model
using WebApplication5.Services;  // Your ApplicationDbContext namespace

namespace WebApplication5.Pages.Admin.Printers
{ 
public class PrinterIndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

        public PrinterIndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

        public List<Printer> Printer { get; private set; }

        public void OnGet()
        {
            Printer = _context.Printers.ToList(); // Fetch all products from the database
        }
    }
}

