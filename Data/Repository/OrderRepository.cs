using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        public void AddOrderItems(OrderItem item)
        {
            _dbContext.Set<OrderItem>().Add(item);
        }

        public IEnumerable<Order> Finding(DateTime date)
        {
            return _dbContext.Set<Order>().Where(order => order.OrderDate.Day == date.Day && order.OrderDate.Month == date.Month && order.OrderDate.Year == date.Year).ToList();
        }

        public IEnumerable<Order> Finding(int id)
        {
            return _dbContext.Set<Order>().Where(order => order.UserID == id).ToList();
        }

        public IEnumerable<OrderItem> GetItemListByOrderId(int id)
        {
            return _dbContext.Set<OrderItem>().Where(orderItem => orderItem.OrderID == id).ToList();
        }

    }
}
