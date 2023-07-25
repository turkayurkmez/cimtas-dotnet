namespace miniShop.Application.DataTransferObjects.Responses
{

    public class ProductListDisplayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

}
