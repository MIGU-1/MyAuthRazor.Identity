using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAuthRazor.Identity.Authentication.Models;

namespace MyAuthRazor.Identity.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;


        [BindProperty]
        public AuthUser AuthUser { get; set; }

        public LoginModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(AuthUser.Email);
                if(user == null)
                {
                    if (user != null)
                    {
                        ModelState.AddModelError("AuthUser.Email", "Email existiert nicht");
                        return Page();
                    }
                }

                var signInResult = await _signInManager.PasswordSignInAsync(
                    AuthUser.Email, AuthUser.Password, isPersistent: true, lockoutOnFailure: false);

                if(!signInResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Login fehlgeschlagen!");
                    return Page();
                }

                return RedirectToPage(Request.Query["ReturnUrl"]);
            }

            return Page();
        }
    }
}
