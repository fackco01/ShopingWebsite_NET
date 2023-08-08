using Assignment2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment2.Pages.Authenticate
{
    public class UpdateModel : PageModel
    {
        private readonly Assignment2.Context.ShoppingContext _context;

        public UpdateModel(Assignment2.Context.ShoppingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Account account { get; set; } = default!;

        public async Task<ActionResult> OnGetAsync(string? id)
        {
            Debug.WriteLine("name" + id);

            if (id == null || _context.Account == null)
            {
                return NotFound();
            }
            var acc = await _context.Account.FirstOrDefaultAsync(a => a.UserName == id);
            if(acc == null) return NotFound();

            account = acc;

            return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(account).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExisits(account.UserName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index"); ;
        }

        private bool AccountExisits(string name)
        {
            return (_context.Account?.Any(e => e.UserName == name)).GetValueOrDefault();
        }
    }
}
