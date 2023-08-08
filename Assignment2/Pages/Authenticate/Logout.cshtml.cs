using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2.Pages.Authenticate
{
    public class LogoutModel : PageModel
    {
        public async Task<ActionResult> OnPostAsync()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");
        }
    }
}
