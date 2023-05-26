using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository.Interface
{
    public interface IDiscountRepository : IGenericRepository<DiscountCode>
    {
        public IEnumerable<DiscountCode> Finding(float percent);
    }
}
