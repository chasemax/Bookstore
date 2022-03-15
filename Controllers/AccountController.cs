using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> u, SignInManager<IdentityUser> s)
        {
            userManager = u;
            signInManager = s;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new Login { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login l)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(l.Username);

                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    if ((await signInManager.PasswordSignInAsync(user, l.Password, false, false)).Succeeded)
                    {
                        return Redirect(l?.ReturnUrl ?? "/admin");
                    }
                }
            }

            ModelState.AddModelError("", "Incorrect Username or Password");
            return View(l);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();

            return Redirect(returnUrl);
        }
    }
}
