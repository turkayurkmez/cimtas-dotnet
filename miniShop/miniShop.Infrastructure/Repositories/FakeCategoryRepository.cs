//using miniShop.Entities;

//namespace miniShop.Infrastructure.Repositories
//{
//    public class FakeCategoryRepository : ICategoryRepository
//    {
//        private List<Category> _categories;
//        public FakeCategoryRepository()
//        {
//            _categories = new List<Category>()
//            {
//                new(){ Id=1, Name="Tişört"},
//                new(){ Id=2, Name="Ayakkabı"},
//                new(){ Id=3, Name="Mont"},
//                new(){ Id=4, Name="Çanta"}

//            };
//        }
//        public void Create(Category entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Category> GetAll()
//        {
//            return _categories;
//        }

//        public Category GetEntityById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Category entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
