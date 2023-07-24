using System.ComponentModel.DataAnnotations;

namespace miniShop.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adını unutmayın")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; } = 0;

        public string? ImageUrl { get; set; } = "https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg";

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }


    }
}
