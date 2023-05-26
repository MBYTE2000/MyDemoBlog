using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyDemoBlog.Models.ViewComponents;

namespace MyDemoBlog.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl) 
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        public UserManager<IdentityUser> GetUserManager()
        {
            return userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl, UserManager<IdentityUser> userManager)
        {
            if (ModelState.IsValid) 
            {
                IdentityUser user = await userManager.FindByNameAsync(model.Login);
                if (user != null) 
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(model.Login), "Не верный логин или пароль");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> logout() 
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
