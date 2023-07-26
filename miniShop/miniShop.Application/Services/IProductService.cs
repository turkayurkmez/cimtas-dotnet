using miniShop.Application.DataTransferObjects.Requests;
using miniShop.Application.DataTransferObjects.Responses;
using miniShop.Entities;

namespace miniShop.Application.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        IEnumerable<ProductListDisplayResponse> GetProductsDisplayResponse();
        List<Product> GetProductsByCategoryId(int id);
        List<Product> SearchByName(string name);
        Product GetProductById(int productId);

        int CreateNewProduct(Product product);
        int CreateNewProduct(CreateNewProductRequest createNewProductRequest);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);

        void UpdateProduct(UpdateProductRequest request);
        bool IsProductExists(int id);

    }
}