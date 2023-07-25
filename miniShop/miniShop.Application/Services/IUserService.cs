using miniShop.Entities;

namespace miniShop.Application.Services
{
    public interface IUserService
    {
        User? ValidateUser(string username, string password);
    }
}