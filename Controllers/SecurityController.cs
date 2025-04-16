using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppTollCollection.Data;
using WebAppTollCollection.ViewModel;

namespace WebAppTollCollection.Controllers
{
    public class SecurityController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public SecurityController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }




        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUser user, string? redirect)
        {
            var appUser = new AppUser()
            {
                UserName = user.UserEmail,
                Email = user.UserEmail
            };

            var result = await userManager.CreateAsync(appUser, user.Password);

            if (result.Succeeded)
            {


                if (redirect == null)
                {
                    return RedirectToAction( "Login");
                }
                else
                {
                    return LocalRedirect(redirect);
                }

            }
            return View(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginUser user, string? redirect)
        {
            var appUser = await userManager.FindByEmailAsync(user.UserEmail);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Invalid credential!, try again...");
                return View(user);
            }


            var result = await signInManager.CheckPasswordSignInAsync(appUser, user.Password, false);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(appUser, user.RememberMe);

                if (redirect == null)
                {
                    return RedirectToAction("Index","TollPlazas");
                }
                else
                {
                    return LocalRedirect(redirect);
                }
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Index","TollPlazas");

        }



    }
}