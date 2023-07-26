using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using miniShop.API.Filters;
using miniShop.Application.DataTransferObjects.Requests;
using miniShop.Application.Services;

namespace miniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }


        //REST: REpserentational State Tranfer
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = productService.GetProductsDisplayResponse();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [IsExists]
        public IActionResult Get(int id)
        {
            var product = productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("[action]/{name}")]
        public IActionResult SearchProductByName(string name)
        {
            var products = productService.SearchByName(name);
            return Ok(products);

        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateNewProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                int lastProductId = productService.CreateNewProduct(productRequest);
                return CreatedAtAction(nameof(Get), routeValues: new { id = lastProductId }, value: null);
            }

            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        [IsExists]
        public IActionResult Update(int id, UpdateProductRequest productRequest)
        {


            //1. id'si verilen ürün var mı?
            // if (productService.IsProductExists(id))
            // {
            //2. varsa productRequest Valid mi?
            if (ModelState.IsValid)
            {
                //3. uygunsa güncelle
                productService.UpdateProduct(productRequest);
                return Ok();
            }
            //değilse hata döndür
            return BadRequest(ModelState);
            //}

            //   id'si verilen ürün yoksa 404 döndür.
            //return NotFound();
        }

        [HttpDelete("{id}")]
        //[RangeExceptionFilter]
        [IsExists]
        public IActionResult Delete(int id)
        {
            //var number = 1;
            //var test = number / 0;
            //if (productService.IsProductExists(id))
            //{
            productService.DeleteProduct(id);
            return Ok();
            //}
            //return NotFound();
        }
    }
}
