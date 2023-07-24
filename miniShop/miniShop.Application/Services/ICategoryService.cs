using miniShop.Entities;

namespace miniShop.Application.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        int CreateNewCategory(Category category);
        void UpdateExistingCategory(Category category);
        void DeleteCategory(int id);

    }
}
