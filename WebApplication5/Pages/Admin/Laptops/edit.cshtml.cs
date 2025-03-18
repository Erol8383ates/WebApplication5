using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.Laptops
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;

        // Change ComputerDto to LaptopDto
        [BindProperty]
        public LaptopDto LaptopDto { get; set; } = new LaptopDto();

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        // GET method to load the laptop details into the form
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Laptops/Index");
            }

            var laptop = _context.Laptops.Find(id); // Changed from Computers to Laptops
            if (laptop == null)
            {
                return RedirectToPage("/Admin/Laptops/Index");
            }

            // Populate the LaptopDto with the data from the database
            LaptopDto.Naam = laptop.Naam;
            LaptopDto.Lokaal = laptop.Lokaal;
            LaptopDto.Laptopcar = laptop.Laptopcar;
            LaptopDto.CPU = laptop.CPU;
            LaptopDto.Vlan = laptop.Vlan;
            LaptopDto.Ipaddress = laptop.Ipaddress;
            LaptopDto.MerkModel = laptop.MerkModel;
            LaptopDto.Opmerkingen = laptop.Opmerkingen;

            return Page();
        }

        // POST method to save the updated laptop details
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Laptops/Index");
            }

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please provide all the required fields.";
                return Page();
            }

            var laptop = _context.Laptops.Find(id); // Changed from Computers to Laptops
            if (laptop == null)
            {
                return RedirectToPage("/Admin/Laptops/Index");
            }

            // Update the laptop properties with the data from the form
            laptop.Naam = LaptopDto.Naam;
            laptop.Lokaal = LaptopDto.Lokaal;
            laptop.Laptopcar = LaptopDto.Laptopcar;
            laptop.CPU = LaptopDto.CPU;
            laptop.Ram = LaptopDto.Ram;
            laptop.Vlan = LaptopDto.Vlan;
            laptop.Ipaddress = LaptopDto.Ipaddress;
            laptop.MerkModel = LaptopDto.MerkModel;
            laptop.Opmerkingen = LaptopDto.Opmerkingen;

            // Save the changes to the database
            _context.SaveChanges();

            SuccessMessage = "Laptop updated successfully!";
            return RedirectToPage("/Admin/Laptops/Index");
        }

        // Optional: Handle the delete method if needed
        public IActionResult OnDelete(int id)
        {
            var laptop = _context.Laptops.Find(id); // Changed from Computers to Laptops
            if (laptop == null)
            {
                return NotFound();
            }

            _context.Laptops.Remove(laptop); // Changed from Computers to Laptops
            _context.SaveChanges();

            return RedirectToPage("/Admin/Laptops/Index");
        }
    }
}
