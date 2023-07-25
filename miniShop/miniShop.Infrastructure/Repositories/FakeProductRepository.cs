//using miniShop.Entities;

//namespace miniShop.Infrastructure.Repositories
//{
//    public class FakeProductRepository : IProductRepository
//    {
//        private List<Product> products;
//        public FakeProductRepository()
//        {
//            products = new List<Product>()
//            {
//                new(){ Id=1, Name="Falan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
//                new(){ Id=2, Name="Filan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
//                new(){ Id=3, Name="Felan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=2},
//                new(){ Id=4, Name="Fulan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
//                new(){ Id=5, Name="Fölan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=4},
//                new(){ Id=6, Name="Fülan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=4},
//                new(){ Id=7, Name="Fılan", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=3},
//                new(){ Id=8, Name="Felin", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
//                new(){ Id=9, Name="Falun", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=1},
//                new(){ Id=10, Name="Felün", Description="Bla bbla", Price=100, Discount=0.15m, CategoryId=4},
//            };

//        }
//        public void Create(Product entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Product> GetAll()
//        {
//            return products;
//        }

//        public Product GetEntityById(int id)
//        {
//            return products.SingleOrDefault(p => p.Id == id);
//        }

//        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
//        {
//            return products.Where(p => p.CategoryId == categoryId);
//        }

//        public IEnumerable<Product> GetProductsByName(string productName)
//        {
//            return products.Where(p => p.Name.Contains(productName));
//        }

//        public void Update(Product entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
