using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public IEnumerable<Book> FindingByName(string name);
        public IEnumerable<Book> FindingByBookType(int bookType);
        public IEnumerable<Book> FindingByAuthor(int author);
    }
}
