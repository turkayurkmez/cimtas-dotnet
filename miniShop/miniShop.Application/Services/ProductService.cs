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

        public int CreateNewProduct(Product product)
        {
            productRepository.Create(product);
            return product.Id;
        }

        public void DeleteProduct(int id)
        {
            productRepository.Delete(id);
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

        public void UpdateProduct(Product product)
        {
            if (product.Id != default(int))
            {
                productRepository.Update(product);
            }
            else
            {
                throw new ArgumentException("Ürün id'si bilinmiyor...");
            }

        }
    }
}
