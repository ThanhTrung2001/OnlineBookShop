using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public IEnumerable<Order> Finding(DateTime date);

        public IEnumerable<Order> Finding(int id);

        public IEnumerable<OrderItem> GetItemListByOrderId(int id);

        public void AddOrderItems(OrderItem item);
    }
}
