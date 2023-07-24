using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using miniShop.Application.Services;
using miniShop.Entities;

namespace miniShop.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.CreateNewProduct(product);
                return RedirectToAction("Index");

            }
            ViewBag.Categories = GetCategories();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var product = productService.GetProductById(id);
            ViewBag.Categories = GetCategories();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(product);
                return RedirectToAction("Index");

            }
            ViewBag.Categories = GetCategories();
            return View();
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            var selectList = categoryService.GetCategories().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            return selectList;
        }
    }
}
