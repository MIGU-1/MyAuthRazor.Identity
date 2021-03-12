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
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public AuthUser AuthUser { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByNameAsync(AuthUser.Email);
            if (user != null)
            {
                ModelState.AddModelError("AuthUser.Email", "Email existiert bereits");
                return Page();
            }

            var result = await _userManager.CreateAsync(new IdentityUser
            {
                UserName = AuthUser.Email,
                Email = AuthUser.Email
            }, AuthUser.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(
                    string.Empty,
                    string.Join(" ", result.Errors.Select(e => e.Description)));
            }
            else
            {
                return RedirectToPage("/Index");
            }
        
            return Page();
        }
    }
}
