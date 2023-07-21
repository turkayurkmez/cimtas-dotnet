using Microsoft.AspNetCore.Mvc;
using miniShop.Application.Services;

namespace miniShop.MVC.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {

        private readonly ICategoryService categoryService;

        public MenuViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = this.categoryService.GetCategories();
            return View(categories);
        }

    }
}
