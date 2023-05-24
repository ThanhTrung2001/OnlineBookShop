using OnlineBookShop.Data.Repository;

namespace OnlineBookShop.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
