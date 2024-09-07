using Azure.Core;
using GameStore.DAL.Models;
using GameStore.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace GameStore.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVM model)
        {
            if (ModelState.IsValid)
            {
                var hasUser = await _userManager.FindByEmailAsync(model.Email);
                if (hasUser == null)
                {
                    ModelState.AddModelError("", "Istifadeci adi ve sifre sehfdir");
                }
                var signInResult = await _signInManager.PasswordSignInAsync(hasUser, model.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }

            }

            return View(model);

        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM model)
        {
            if (ModelState.IsValid)
            {
                var remoteIpAddress = "127.0.0.1";
                var identityResult = await _userManager.CreateAsync(new()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    LastLoginIpAdr = remoteIpAddress,
                }, model.Password); ;
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("SignIn");

                }
                else
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                }

            }

            return View(model);
        }
    }
}
