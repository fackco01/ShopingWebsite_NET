using Assignment2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Pages.Authenticate
{
    public class RegisterModel : PageModel
    {
        private readonly Assignment2.Context.ShoppingContext _context;

        public RegisterModel(Assignment2.Context.ShoppingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Account account { get; set; } = default!;
        [ViewData]
        public string msg { get; set; }

        public void OnGet()
        {
            this.msg = msg;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || account == null)
            {
                return Page();
            }

            account.Type = (account.Type == "Staff" ? "1" : "2");

            var duplicate = _context.Account.Where(acc => acc.UserName == account.UserName).FirstOrDefault();
            if (duplicate == null) {
                _context.Account.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Login");
            }
            else
            {
                msg = "Duplicate User Name";
            }
            return Page();

        }
    }
}
