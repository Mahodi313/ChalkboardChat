using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChalkboardChat.UI.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        public string? Username { get; set; }

        public string? Password { get; set; }


        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            IdentityUser newUset = new()
            {
                UserName = Username,
            };

            var createUserResult = await _userManager.CreateAsync(newUset, Password);

            if (createUserResult.Succeeded)
            {
                IdentityUser? userToLogin = await _userManager.FindByNameAsync(Username);

                var signedInResult = await _signInManager.PasswordSignInAsync(userToLogin, Password, false, false);

                if (signedInResult.Succeeded)
                {
                    return RedirectToPage("/Account/Login");
                }
                else
                {
                    // wrong password
                }
            }
            else
            {

            }
            return Page();

        }

    }
}
