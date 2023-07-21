using miniShop.MVC.Models;

namespace miniShop.MVC.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductsByCategoryId(int id);
    }
}