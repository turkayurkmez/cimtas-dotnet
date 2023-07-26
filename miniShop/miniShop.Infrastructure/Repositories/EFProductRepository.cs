using Microsoft.EntityFrameworkCore;
using miniShop.Entities;
using miniShop.Infrastructure.Data;

namespace miniShop.Infrastructure.Repositories
{
    public class EFProductRepository : IProductRepository
    {

        private readonly MiniShopDbContext dbContext;

        public EFProductRepository(MiniShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Product entity)
        {
            dbContext.Products.Add(entity);
            dbContext.SaveChanges(); //persistent api
        }

        public void Delete(int id)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }

        public Product GetEntityById(int id)
        {
            return dbContext.Products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return dbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public IEnumerable<Product> GetProductsByName(string productName)
        {
            return dbContext.Products.Where(p => p.Name.Contains(productName));
        }

        public IEnumerable<Product> GetProductsWithCategory()
        {
            return dbContext.Products.Include(p => p.Category).ToList();

        }

        public bool IsExists(int id)
        {
            return dbContext.Products.Any(p => p.Id == id);
        }

        public void Update(Product entity)
        {
            //dbContext.Entry<Product>(entity).State = Microsoft.EntityFrameworkCore.EntityState.;
            dbContext.Products.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
