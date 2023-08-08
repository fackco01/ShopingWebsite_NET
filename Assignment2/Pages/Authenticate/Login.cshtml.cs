using Assignment2.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Assignment2.Pages.Authenticate
{
    public class LoginModel : PageModel
    {
        private readonly Context.ShoppingContext _context;
        public LoginModel(Context.ShoppingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Crenditial crenditial { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _context.Products == null || crenditial == null)
            {
                return Page();
            }
            var acc = _context.Account.Where(a => a.UserName == crenditial.username && a.Password == crenditial.password).FirstOrDefault();
            if (!(acc == null))
            {
                //var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, acc.UserName),
                //    new Claim(ClaimTypes.Role, acc.Type)
                //};
                //var identity = new ClaimsIdentity(claims, "account");
                //ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                //var opt = new CookieOptions
                //{
                //    Expires = DateTime.UtcNow.AddDays(1)
                //};
                //Response.Cookies.Append("Account", Convert.ToString(claimsPrincipal), opt);

                HttpContext.Session.SetString("username", acc.UserName);
                HttpContext.Session.SetString("type", acc.Type);
                return RedirectToPage("../Index");
            }
            return Page();
        }
    }

    public class Crenditial
    {
        public string username { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
