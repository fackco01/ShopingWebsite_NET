using Assignment2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Assignment2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Assignment2.Context.ShoppingContext _context;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public IndexModel(Assignment2.Context.ShoppingContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public IList<Products> Products { get; set; } = default!;

        //public ActionResult OnGet()
        //{
        //}

        public async Task<JsonResult> OnGetGenerate(string search)
        {
            System.Diagnostics.Debug.WriteLine("search " + search);
            if (search != null && _context!=null)
            {
                IList<Products> result = null;
                if (Regex.IsMatch(search, @"\d+"))
                {
                    result = await _context.Products
                             .Where (p => p.ProductID == Convert.ToInt32(search))
                             .Include(p => p.Category)
                             .Include(p => p.Supplier).ToListAsync();
                }
                else
                {
                    result = await _context.Products
                             .Where(p => p.ProductName.Contains(search))
                             .Include(p => p.Category)
                             .Include(p => p.Supplier).ToListAsync();
                }
                System.Diagnostics.Debug.WriteLine(result);
                Products = result;
                System.Diagnostics.Debug.WriteLine(new JsonResult(Products));
                return new JsonResult(Products);
            }
            return new JsonResult("");
        }
    }
}