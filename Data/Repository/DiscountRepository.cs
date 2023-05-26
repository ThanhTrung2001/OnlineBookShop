using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Data.Repository.Interface;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class DiscountRepository : GenericRepository<DiscountCode>, IDiscountRepository
    {
        public DiscountRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<DiscountCode> Finding(float percent)
        {
            throw new NotImplementedException();
        }
    }
}
