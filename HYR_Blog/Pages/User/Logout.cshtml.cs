using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HYR_Blog.Pages.User
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            Response.Cookies.Delete("HyrUser");
            return Redirect("/");
        }
    }
}
