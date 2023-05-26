using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Book> Finding(string name, int type, int author)
        {
            throw new NotImplementedException();
        }
    }
}
