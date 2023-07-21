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

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }
    }
}
