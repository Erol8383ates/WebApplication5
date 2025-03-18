using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using System.Linq;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.Beamers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public BeamerDto BeamerDto { get; set; } = new BeamerDto();

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Populate the BeamerDto with data from the database
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Beamers/Index");
            }

            var beamer = _context.Beamers.Find(id);
            if (beamer == null)
            {
                return RedirectToPage("/Admin/Beamers/Index");
            }

            // Populate the BeamerDto with data from the database
            BeamerDto.Lokaal = beamer.Lokaal;
            BeamerDto.MerkModel = beamer.MerkModel;
            BeamerDto.Lamp = beamer.Lamp;
            BeamerDto.Aansluting = beamer.Aansluting;
            BeamerDto.Opmerkingen = beamer.Opmerkingen;

            return Page();
        }

        // POST: Handle form submission and update the Beamer
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/Beamers/Index");
            }

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please provide all the required fields.";
                return Page();
            }

            var beamer = _context.Beamers.Find(id);
            if (beamer == null)
            {
                return RedirectToPage("/Admin/Beamers/Index");
            }

            // Update the Beamer properties with the data from the form
            beamer.Lokaal = BeamerDto.Lokaal;
            beamer.MerkModel = BeamerDto.MerkModel;
            beamer.Lamp = BeamerDto.Lamp;
            beamer.Aansluting = BeamerDto.Aansluting;
            beamer.Opmerkingen = BeamerDto.Opmerkingen;

            // Save changes to the database
            _context.SaveChanges();

            SuccessMessage = "Beamer updated successfully!";
            return RedirectToPage("/Admin/Beamers/Index");
        }
    }
}
