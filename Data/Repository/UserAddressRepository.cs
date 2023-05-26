using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class UserAddressRepository : GenericRepository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<UserAddress> Finding(int userID)
        {
            return _dbContext.Set<UserAddress>().Where(address => address.UserID == userID).ToList();
        }
    }
}
