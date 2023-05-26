using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public IEnumerable<Book> Finding(string name, int type, int author);
    }
}
