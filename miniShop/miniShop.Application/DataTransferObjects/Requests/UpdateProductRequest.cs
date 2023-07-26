using System.ComponentModel.DataAnnotations;

namespace miniShop.Application.DataTransferObjects.Requests
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public int? Price { get; set; }
        public int? Discount { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
    }
}
