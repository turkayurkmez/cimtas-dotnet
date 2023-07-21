using miniShop.Entities;

namespace miniShop.Application.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}
