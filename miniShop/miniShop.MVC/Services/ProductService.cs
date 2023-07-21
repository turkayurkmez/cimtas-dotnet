using miniShop.MVC.Models;

namespace miniShop.MVC.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products;
        public ProductService()
        {
            products = new List<Product>()
            {
                new(){ Id=1, Name="Falan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
                new(){ Id=2, Name="Filan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
                new(){ Id=3, Name="Felan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=2},
                new(){ Id=4, Name="Fulan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
                new(){ Id=5, Name="Fölan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=4},
                new(){ Id=6, Name="Fülan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=4},
                new(){ Id=7, Name="Fılan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=3},
                new(){ Id=8, Name="Felin", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
                new(){ Id=9, Name="Falun", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
                new(){ Id=10, Name="Felün", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=4},
            };
        }
        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Product> GetProductsByCategoryId(int id) => products.Where(p => p.CategoryId == id).ToList();
    }
}
