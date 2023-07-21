using Microsoft.AspNetCore.Mvc;
using miniShop.Entities;

namespace miniShop.MVC.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new List<Category>()
            {
                new(){ Id=1, Name="Tişört"},
                new(){ Id=2, Name="Ayakkabı"},
                new(){ Id=3, Name="Mont"},
                new(){ Id=4, Name="Çanta"}

            };
            return View(categories);
        }

    }
}
