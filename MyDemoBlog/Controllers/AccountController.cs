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
        public IActionResult SignUp() 
        {
            return View(new AccountViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser() { UserName = model.Login, NormalizedUserName = model.Login.ToUpper(), EmailConfirmed = true, };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors)
                {
                    await Console.Out.WriteLineAsync($"uWu {item}");
                }

                ModelState.AddModelError(nameof(model.Login), "Error");
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl) 
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new AccountViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountViewModel model, string returnUrl)
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
        public async Task<IActionResult> Logout() 
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
