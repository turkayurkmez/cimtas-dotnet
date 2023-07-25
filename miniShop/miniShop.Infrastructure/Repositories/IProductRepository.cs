using miniShop.Entities;

namespace miniShop.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {

        IEnumerable<Product> GetProductsByName(string productName);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);

        IEnumerable<Product> GetProductsWithCategory();

    }
}
