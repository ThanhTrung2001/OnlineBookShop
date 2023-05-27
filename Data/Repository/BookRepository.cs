using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Book> FindingByAuthor(int authorID)
        {
            return _dbContext.Set<Book>().Where(book => book.AuthorID == authorID).ToList();
        }

        public IEnumerable<Book> FindingByBookType(int bookTypeID)
        {
            return _dbContext.Set<Book>().Where(book => book.BookTypeID == bookTypeID).ToList();
        }

        public IEnumerable<Book> FindingByName(string name)
        {
            return _dbContext.Set<Book>().Where(book => book.Title.Contains(name)).ToList();
        }
    }
}
