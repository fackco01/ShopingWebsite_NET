using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment2.Model;
using System.IO;
using System.Net;

namespace Assignment2.Pages.ProductManager
{
    public class CreateModel : PageModel
    {
        private readonly Assignment2.Context.ShoppingContext _context;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public CreateModel(Assignment2.Context.ShoppingContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID");
        ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID");
            return Page();
        }

        [BindProperty]
        public Products Products { get; set; } = default!;

        [BindProperty]
        public IFormFile image { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || Products == null)
            {
                return Page();
            }


            var file = Path.Combine(_environment.WebRootPath, "Image", image.FileName);
            Products.ProductImage = file;
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
