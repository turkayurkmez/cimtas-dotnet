using introduceDotnetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace introduceDotnetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Türkay Ürkmez";
            ViewBag.Hour = DateTime.Now.Hour;
            return View();
        }


        public IActionResult Davet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Davet(UserResponse userResponse)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View();
        }

    }
}
