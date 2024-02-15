using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkboardChat.UI.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public void OnGet()
        {
        }
    }
}
