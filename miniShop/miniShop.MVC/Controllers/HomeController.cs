using Microsoft.AspNetCore.Mvc;
using miniShop.Application.Services;
using miniShop.MVC.Models;

using System.Diagnostics;

namespace miniShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index(int pageNo = 1, int? catId = null)
        {
            //Bu metot, ProductService instance'ı olmadan ÇALIŞMAZ
            //var productService = new ProductService();


            var productsResult = catId.HasValue ? productService.GetProductsByCategoryId(catId.Value)
                                                   :
                                                  productService.GetProducts();

            _logger.LogInformation($" {DateTime.Now} Index action'u üzerinde Veri servis aracılığı ile çekildi");

            var totalProducts = productsResult.Count;
            var pageSize = 4;
            var totalPages = Math.Ceiling((decimal)totalProducts / pageSize);

            /*
             * 1. Sayfa, 0 atla 4 al
             * 2. .....  4 atla 4 al
             * 3 ......  8 atla 4 al
             */
            var paginatedProducts = productsResult.OrderBy(p => p.Id)
                                            .Skip((pageNo - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();

            ViewBag.TotalPages = totalPages;
            ViewBag.ActiveCategory = catId;
            return View(paginatedProducts);
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

        public IActionResult Test()
        {
            return PartialView();
        }
    }
}