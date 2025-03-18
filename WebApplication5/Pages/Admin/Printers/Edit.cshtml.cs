using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;
namespace WebApplication5.Pages.Admin.Printers
{
    public class editModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public PrinterDto PrinterDto { get; set; } = new PrinterDto();
        public Printer Printer { get; set; } = new Printer();
        public string errorMessage = "";
        public string successMessage = "";

        public editModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Printers/Index");
                return;
            }

            var printer = context.Printers.Find(id);
            if (printer == null)
            {
                Response.Redirect("/Admin/Printers/Index");
                return;
            }
            PrinterDto.Naam = printer.Naam;
            PrinterDto.Lokaal = printer.Lokaal;
            PrinterDto.Ipaddress = printer.Ipaddress;
            PrinterDto.Model = printer.Model;
            PrinterDto.Opmerkingen = printer.Opmerkingen;
           

            Printer = printer;
        }

        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Printers/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields.";
                return;
            }

            var printer = context.Printers.Find(id);
            if (printer == null)
            {
                Response.Redirect("/Admin/Printers/Index");
                return;
            }

            // Handle image file upload

            // Update the product fields in the database
            printer.Naam = PrinterDto.Naam;
            printer.Lokaal = PrinterDto.Lokaal;
            printer.Ipaddress = PrinterDto.Ipaddress;
            printer.Model = PrinterDto.Model;
            printer.Opmerkingen = PrinterDto.Opmerkingen;



            context.SaveChanges();

            Printer = printer;
            successMessage = "Product updated successfully!";
            Response.Redirect("/Admin/Printers/Index");
        }


                // Delete the printer
    public IActionResult OnDelete(int id)
        {
            var printer = context.Printers.Find(id);
            if (printer == null)
            {
                return NotFound();
            }

            context.Printers.Remove(printer);
            context.SaveChanges();

            return RedirectToPage("/Admin/Printers/Index");
        }
    }

}
   