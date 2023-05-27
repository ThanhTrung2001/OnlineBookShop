using OnlineBookShop.Data.Repository;

namespace OnlineBookShop.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        UserAddressRepository GetUserAddressRepository();
        AccountRepository GetAccountRepository();
        AuthorRepository GetAuthorRepository();
        BookRepository GetBookRepository();
        BookTypeRepository GetBookTypeRepository();
        DiscountRepository GetDiscountRepository();
        OrderRepository GetOrderRepository();
        StaffRepository GetStaffRepository();
        UserRepository GetUserRepository();
        CartRepository GetCartRepository();
        int SaveChanges();
    }
}
