using miniShop.Entities;
using miniShop.Infrastructure.Repositories;

namespace miniShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public int CreateNewCategory(Category category)
        {
            categoryRepository.Create(category);
            return category.Id;
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }

        public void UpdateExistingCategory(Category category)
        {
            if (category.Id != 0)
            {
                categoryRepository.Update(category);
            }
            else
            {
                throw new ArgumentException("Kategori id'si bilinmiyor...");
            }
        }
    }
}
