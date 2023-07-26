using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace miniShop.API.Filters
{
    public class RangeExceptionFilter : ExceptionFilterAttribute
    {
        //Bu filtrenin kullanılıdığı Action içinde bir hata olursa, bu filtre devreye girsin.

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is DivideByZeroException)
            {
                context.Result = new BadRequestObjectResult(new { message = "Tam sayılar, 0'a bölünemez!" });
            }
        }
    }
}
