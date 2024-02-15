using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkboardChat.UI.Pages.Account
{

    [BindProperties]

    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInUser)
        {
            _signInManager = signInUser;
            _userManager = userManager;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            IdentityUser? userToLogin = await _userManager.FindByNameAsync(Username);

            if (userToLogin != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(userToLogin, Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToPage("/Member/Posts");
                }
            }

            return Page();
        }
    }
}
