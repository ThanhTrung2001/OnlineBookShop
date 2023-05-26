using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
        public AccountRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<User> Finding(string name)
        {
            return _dbContext.Set<User>().Where(user => user.UserName.Contains(name)).ToList();
        }
    }
}
