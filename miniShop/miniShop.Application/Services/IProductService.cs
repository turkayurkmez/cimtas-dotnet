using miniShop.Entities;

namespace miniShop.Application.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductsByCategoryId(int id);
    }
}