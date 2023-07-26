using miniShop.Entities;
using miniShop.Infrastructure.Data;

namespace miniShop.Infrastructure.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {

        private readonly MiniShopDbContext dbContext;

        public EFCategoryRepository(MiniShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Category entity)
        {
            dbContext.Categories.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

        public Category GetEntityById(int id)
        {
            return dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            dbContext.Categories.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
