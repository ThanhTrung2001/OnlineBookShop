using OnlineBookShop.Data.Repository;

namespace OnlineBookShop.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(context);
        }

        public UserAddressRepository GetUserAddressRepository()
        {
            return new UserAddressRepository(context);
        }

        public AccountRepository GetAccountRepository()
        {
            return new AccountRepository(context);
        }

        public AuthorRepository GetAuthorRepository()
        {
            return new AuthorRepository(context);
        }

        public BookRepository GetBookRepository()
        {
            return new BookRepository(context);
        }

        public BookTypeRepository GetBookTypeRepository()
        {
            return new BookTypeRepository(context);
        }

        public DiscountRepository GetDiscountRepository()
        {
            return new DiscountRepository(context);
        }

        public OrderRepository GetOrderRepository()
        {
            return new OrderRepository(context);
        }

        public StaffRepository GetStaffRepository()
        {
            return new StaffRepository(context);
        }

        public UserRepository GetUserRepository()
        {
            return new UserRepository(context);
        }

        public CartRepository GetCartRepository()
        {
            return new CartRepository(context);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }


    }
}
