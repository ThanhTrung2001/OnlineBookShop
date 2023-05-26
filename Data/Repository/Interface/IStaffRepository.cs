using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        public IEnumerable<Staff> Finding(string name);
    }
}
