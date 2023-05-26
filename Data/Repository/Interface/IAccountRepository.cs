using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface IAccountRepository : IGenericRepository<User>
    {
        public IEnumerable<User> Finding(string name);

    }
}
