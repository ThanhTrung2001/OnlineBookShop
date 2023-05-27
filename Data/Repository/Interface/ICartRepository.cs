using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        public Cart GetByUserId(int id);
        public IEnumerable<CartItem> GetItemListByCartId(int id);
        public void AddProductToCart(int cartID, int bookID, CartItem cartItem);
    }
}
