using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using miniShop.Application.Services;

namespace miniShop.API.Filters
{
    /*
     * Attribute, constructor parametresi olarak dependency enjekte edemeyeceği için Filtreyi interface'den implemente ediyoruz.
     */
    public class IsExistsFilter : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public IsExistsFilter(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Id'si verilen ürün var mı?
            //1. action id alıyor mu?
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult(new { message = "id parametresi eksik" });
                return;
            }

            //2. id tipi int mi (Pattern matching)?
            if (!(context.ActionArguments["id"] is int id))
            {
                context.Result = new BadRequestObjectResult(new { message = "id parametresi int tipinde olmalı" });
                return;
            }

            var isExists = productService.IsProductExists(id);
            if (!isExists)
            {
                context.Result = new NotFoundObjectResult(new { message = $"{id} id'li ürün yok" });
                return;
            }

            await next();

        }
    }
}
