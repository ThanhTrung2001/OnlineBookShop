using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface IUserAddressRepository : IGenericRepository<UserAddress>
    {
        public IEnumerable<UserAddress> Finding(int userID);
    }
}
