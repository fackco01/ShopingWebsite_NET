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
    public class IndexModel : PageModel
    {
        private readonly Assignment2.Context.ShoppingContext _context;

        public IndexModel(Assignment2.Context.ShoppingContext context)
        {
            _context = context;
        }

        public IList<Categories> Categories { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Categories = await _context.Categories.ToListAsync();
            }
        }
    }
}
