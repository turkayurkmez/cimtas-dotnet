using miniShop.Entities;

namespace miniShop.Application.Services
{
    public class UserService : IUserService
    {

        private List<User> _users;

        public UserService()
        {
            _users = new List<User>
          {
              new(){ UserName="yalcin", Email="y@cimtas.com.tr", Password="123", Role="Admin"},
              new(){ UserName="tugce", Email="t@cimtas.com.tr", Password="123", Role="Editor"},
              new(){ UserName="turkay", Email="t@gmail.com", Password="123", Role="Client"},

          };
        }
        public User? ValidateUser(string username, string password)
        {
            return _users.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
