using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Pages.Admin.NetwerkMaterials
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public NetwerkMaterialDto NetwerkMaterialDto { get; set; } = new NetwerkMaterialDto();
        public NetwerkMaterial NetwerkMaterial { get; set; } = new NetwerkMaterial();
        public string errorMessage = "";
        public string successMessage = "";

        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/NetwerkMaterials/Index");
                return;
            }

            var netwerkMaterial = context.NetwerkMaterials.Find(id);
            if (netwerkMaterial == null)
            {
                Response.Redirect("/Admin/NetwerkMaterials/Index");
                return;
            }
            NetwerkMaterialDto.Lokaal = netwerkMaterial.Lokaal;
            NetwerkMaterialDto.Product = netwerkMaterial.Product;
            NetwerkMaterialDto.Naam = netwerkMaterial.Naam;
            NetwerkMaterialDto.Model = netwerkMaterial.Model;
            NetwerkMaterialDto.Ipaddress = netwerkMaterial.Ipaddress;
            NetwerkMaterialDto.Opmerkingen = netwerkMaterial.Opmerkingen;


            NetwerkMaterial = netwerkMaterial;
        }

        public NetwerkMaterial GetNetwerkMaterial()
        {
            return NetwerkMaterial;
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Admin/NetwerkMaterials/Index");
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields.";
                return Page();
            }

            // Fetch the existing netwerk material from the database
            var netwerkMaterial = context.NetwerkMaterials.Find(id);
            if (netwerkMaterial == null)
            {
                return RedirectToPage("/Admin/NetwerkMaterials/Index");
            }

            // Update the netwerk material fields with the values from NetwerkMaterialDto
            netwerkMaterial.Lokaal = NetwerkMaterialDto.Lokaal;
            netwerkMaterial.Product = NetwerkMaterialDto.Product;
            netwerkMaterial.Naam = NetwerkMaterialDto.Naam;
            netwerkMaterial.Model = NetwerkMaterialDto.Model;
            netwerkMaterial.Ipaddress = NetwerkMaterialDto.Ipaddress;
            netwerkMaterial.Opmerkingen = NetwerkMaterialDto.Opmerkingen;


            // Save changes to the database
            context.SaveChanges();

            successMessage = "Netwerk Material updated successfully!";
            return RedirectToPage("/Admin/NetwerkMaterials/Index");
        }
    }
}
