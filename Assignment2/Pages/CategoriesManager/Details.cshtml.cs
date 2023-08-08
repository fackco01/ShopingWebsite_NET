using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment2.Context;
using Assignment2.Model;

namespace Assignment2.Pages.CategoriesManager
{
    public class DetailsModel : PageModel
    {
        private readonly Assignment2.Context.ShoppingContext _context;

        public DetailsModel(Assignment2.Context.ShoppingContext context)
        {
            _context = context;
        }

      public Categories Categories { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryID == id);
            if (categories == null)
            {
                return NotFound();
            }
            else 
            {
                Categories = categories;
            }
            return Page();
        }
    }
}
