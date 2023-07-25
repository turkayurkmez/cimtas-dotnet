using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(CreateNewProductRequest productRequest)
        {
            if (ModelState.IsValid)
            {
                int lastProductId = productService.CreateNewProduct(productRequest);
                return CreatedAtAction(nameof(Get), routeValues: new { id = lastProductId }, value: null);
            }

            return BadRequest(ModelState);
        }
    }
}
