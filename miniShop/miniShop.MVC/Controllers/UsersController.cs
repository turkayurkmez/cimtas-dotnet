using Microsoft.AspNetCore.Mvc;
using miniShop.MVC.Models;

namespace miniShop.MVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel user)
        {
            return View();
        }

    }
}
