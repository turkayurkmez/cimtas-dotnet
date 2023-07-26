using Microsoft.AspNetCore.Mvc;

namespace miniShop.API.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        public IsExistsAttribute() : base(typeof(IsExistsFilter))
        {

        }
    }
}
