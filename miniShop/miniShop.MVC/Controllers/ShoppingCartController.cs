using Microsoft.AspNetCore.Mvc;
using miniShop.Application.Services;
using miniShop.MVC.Extensions;
using miniShop.MVC.Models;

namespace miniShop.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IProductService productService;

        public ShoppingCartController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var products = getCollectionFromSession();
            return View(products);
        }

        public IActionResult AddCart(int id)
        {
            //1. id'si verilen ürünü bul
            var product = productService.GetProductById(id);

            //2. bu ürünü koleksiyona ekle
            ProductItem productItem = new ProductItem { Product = product, Quantity = 1 };
            ProductItemCollection productItemCollection = getCollectionFromSession();
            productItemCollection.Add(productItem);
            //3. koleksiyonu da session'a ekle
            saveCollectionToSession(productItemCollection);

            return Json(new { message = $"{id} numaralı ürün sepete eklendi" });
        }



        ProductItemCollection getCollectionFromSession()
        {

            //var json = HttpContext.Session.GetString("basket");
            //if (string.IsNullOrEmpty(json))
            //{               
            //    return new ProductItemCollection();
            //}

            //var deserialized = JsonConvert.DeserializeObject<ProductItemCollection>(json);
            //return deserialized;
            return HttpContext.Session.GetJson<ProductItemCollection>("basket") ?? new ProductItemCollection();
        }

        private void saveCollectionToSession(ProductItemCollection productItemCollection)
        {
            HttpContext.Session.SetJson("basket", productItemCollection);
        }
    }
}
