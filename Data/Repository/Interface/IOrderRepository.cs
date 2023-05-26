using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public IEnumerable<Order> Finding(DateOnly date);
    }
}
