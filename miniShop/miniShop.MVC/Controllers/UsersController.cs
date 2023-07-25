using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using miniShop.Application.Services;
using miniShop.MVC.Models;
using System.Security.Claims;

namespace miniShop.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? nereyeGideyim)
        {
            ViewBag.ReturnUrl = nereyeGideyim;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userModel, string? nereyeGideyim)
        {
            if (ModelState.IsValid)
            {
                var user = userService.ValidateUser(userModel.UserName, userModel.Password);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role, user.Role)

                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (!string.IsNullOrEmpty(nereyeGideyim) && Url.IsLocalUrl(nereyeGideyim))
                    {
                        return Redirect(nereyeGideyim);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
                ModelState.AddModelError("login", "Kullanıcı adı veya şifre yanlış");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
