namespace miniShop.Application.DataTransferObjects.Requests
{


    public class CreateNewProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }

}
