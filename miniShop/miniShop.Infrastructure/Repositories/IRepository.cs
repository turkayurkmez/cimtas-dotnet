using miniShop.Entities;

namespace miniShop.Infrastructure.Repositories
{
    //Bütün db varlıklarının ortak eylemleri:
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T GetEntityById(int id);

        void Create(T entity);
        void Update(T entity);
        void Delete(int id);

        bool IsExists(int id);

    }
}
