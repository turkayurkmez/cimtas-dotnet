using AutoMapper;
using miniShop.Application.DataTransferObjects.Requests;
using miniShop.Application.DataTransferObjects.Responses;
using miniShop.Entities;
using miniShop.Infrastructure.Repositories;

namespace miniShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public int CreateNewProduct(Product product)
        {
            productRepository.Create(product);
            return product.Id;
        }

        public int CreateNewProduct(CreateNewProductRequest createNewProductRequest)
        {
            //var product = new Product
            //{
            //    CategoryId = createNewProductRequest.CategoryId,
            //    Description = createNewProductRequest.Description,
            //    Discount = createNewProductRequest.Discount,
            //    ImageUrl = createNewProductRequest.ImageUrl,
            //    Name = createNewProductRequest.Name,
            //    Price = createNewProductRequest.Price
            //};

            var product = mapper.Map<Product>(createNewProductRequest);

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

        public IEnumerable<ProductListDisplayResponse> GetProductsDisplayResponse()
        {
            var products = productRepository.GetProductsWithCategory();
            return products.Select(p => new ProductListDisplayResponse
            {
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Description = p.Description,
                Discount = p.Discount,
                ImageUrl = p.ImageUrl,
                Id = p.Id,
                Name = p.Name,
                Price = p.Price

            });


        }

        public bool IsProductExists(int id)
        {
            return productRepository.IsExists(id);
        }

        public List<Product> SearchByName(string name)
        {
            return productRepository.GetProductsByName(name).ToList();
        }

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

        public void UpdateProduct(UpdateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            productRepository.Update(product);

        }
    }
}
