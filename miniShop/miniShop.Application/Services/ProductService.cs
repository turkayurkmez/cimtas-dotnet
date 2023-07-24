using miniShop.Entities;
using miniShop.Infrastructure.Repositories;

namespace miniShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product GetProductById(int productId)
        {
            return productRepository.GetEntityById(productId);
        }

        public List<Product> GetProducts()
        {
            return productRepository.GetAll().ToList();
        }

        public List<Product> GetProductsByCategoryId(int id) => productRepository.GetProductsByCategoryId(id).ToList();

    }
}
