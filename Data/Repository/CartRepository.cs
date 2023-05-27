using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(DbContext context) : base(context)
        {
        }

        public Cart GetByUserId(int id)
        {
            return _dbContext.Set<Cart>().Where(cart => cart.UserID == id).ToList().First();
        }

        public IEnumerable<CartItem> GetItemListByCartId(int cartID)
        {
            return _dbContext.Set<CartItem>().Where(cartItem => cartItem.CartID == cartID).ToList();
        }

        public void AddProductToCart(int cartID, int bookID, CartItem cartItem)
        {
            bool isExist = false;
            var cart = _dbContext.Set<Cart>().Where(cart => cart.CartID == cartID).ToList().First();
            var exist = _dbContext.Set<CartItem>().Where(cartItem => cartItem.CartID == cartID).ToList();
            cart.Cost = 0;
            foreach (var item in exist)
            {
                if (item.BookID == bookID)
                {
                    item.Quantity = item.Quantity + cartItem.Quantity;
                    item.Price = cartItem.Price;
                    _dbContext.Set<CartItem>().Update(item);
                    isExist = true;
                }
                cart.Cost += item.Price * item.Quantity;
                _dbContext.Set<Cart>().Update(cart);
            }
            if (isExist == false)
            {
                _dbContext.Set<CartItem>().Add(cartItem);
            }
            _dbContext.SaveChanges();

        }
    }
}
