using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Staff> Finding(string name)
        {
            return _dbContext.Set<Staff>().Where(staff => staff.UserName.Contains(name)).ToList();
        }
    }
}
