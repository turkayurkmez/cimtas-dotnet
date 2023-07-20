using Microsoft.AspNetCore.Mvc;
using miniShop.MVC.Models;
using System.Diagnostics;

namespace miniShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = new List<Product>()
            {
                new(){ Id=1, Name="Falan", Description="Bla bbla", Price=100, Discount=0.15m},
                new(){ Id=2, Name="Filan", Description="Bla bbla", Price=100, Discount=0.15m},
                new(){ Id=3, Name="Felan", Description="Bla bbla", Price=100, Discount=0.15m},
                new(){ Id=4, Name="Fulan", Description="Bla bbla", Price=100, Discount=0.15m},
                new(){ Id=5, Name="Fölan", Description="Bla bbla", Price=100, Discount=0.15m},
                new(){ Id=6, Name="Fülan", Description="Bla bbla", Price=100, Discount=0.15m},
                new(){ Id=7, Name="Fılan", Description="Bla bbla", Price=100, Discount=0.15m},
                new(){ Id=8, Name="Felin", Description="Bla bbla", Price=100, Discount=0.15m},
                new(){ Id=9, Name="Falun", Description="Bla bbla", Price=100, Discount=0.15m},
                new(){ Id=10, Name="Felün", Description="Bla bbla", Price=100, Discount=0.15m},
            };

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}