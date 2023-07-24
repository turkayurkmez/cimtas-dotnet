using miniShop.Entities;

namespace miniShop.MVC.Models
{
    public class ProductItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; } = 1;
    }
    public class ProductItemCollection
    {

        public List<ProductItem> Products { get; set; } = new List<ProductItem>();

        public void Add(ProductItem productItem)
        {
            var existingProductItem = Products.SingleOrDefault(p => p.Product.Id == productItem.Product.Id);
            if (existingProductItem != null)
            {
                existingProductItem.Quantity += productItem.Quantity;
            }
            else
            {
                Products.Add(productItem);
            }
        }

        public decimal? GetTotalPrice() => Products.Sum(p => p.Product.Price.Value * (1 - p.Product.Discount) * p.Quantity);

        public void Clear() => Products.Clear();

    }
}
