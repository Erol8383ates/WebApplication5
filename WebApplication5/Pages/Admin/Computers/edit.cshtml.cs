using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.Computers
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public ComputerDto ComputerDto { get; set; } = new ComputerDto();

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        // GET method to load the computer details into the form
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Computers/Index");
            }

            var computer = _context.Computers.Find(id);
            if (computer == null)
            {
                return RedirectToPage("/Admin/Computers/Index");
            }

            // Populate the ComputerDto with the data from the database
            ComputerDto.Naam = computer.Naam;
            ComputerDto.Lokaal = computer.Lokaal;
            ComputerDto.CPU = computer.CPU;
            ComputerDto.Vlan = computer.Vlan;
            ComputerDto.Ipaddress = computer.Ipaddress;
            ComputerDto.MerkModel = computer.MerkModel;
            ComputerDto.Opmerkingen = computer.Opmerkingen;

            return Page();
        }

        // POST method to save the updated computer details
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Computers/Index");
            }

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please provide all the required fields.";
                return Page();
            }

            var computer = _context.Computers.Find(id);
            if (computer == null)
            {
                return RedirectToPage("/Admin/Computers/Index");
            }

            // Update the computer properties with the data from the form
            computer.Naam = ComputerDto.Naam;
            computer.Lokaal = ComputerDto.Lokaal;
            computer.CPU = ComputerDto.CPU;
            computer.Ram = ComputerDto.Ram;
            computer.Vlan = ComputerDto.Vlan;
            computer.Ipaddress = ComputerDto.Ipaddress;
            computer.MerkModel = ComputerDto.MerkModel;
            computer.Opmerkingen = ComputerDto.Opmerkingen;

            // Save the changes to the database
            _context.SaveChanges();

            SuccessMessage = "Computer updated successfully!";
            return RedirectToPage("/Admin/Computers/Index");
        }

        // Optional: Handle the delete method if needed
        public IActionResult OnDelete(int id)
        {
            var computer = _context.Computers.Find(id);
            if (computer == null)
            {
                return NotFound();
            }

            _context.Computers.Remove(computer);
            _context.SaveChanges();

            return RedirectToPage("/Admin/Computers/Index");
        }
    }
}
