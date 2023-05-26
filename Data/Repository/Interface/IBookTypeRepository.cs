using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface IBookTypeRepository : IGenericRepository<BookType>
    {
        public IEnumerable<BookType> Finding(string name);
    }
}
