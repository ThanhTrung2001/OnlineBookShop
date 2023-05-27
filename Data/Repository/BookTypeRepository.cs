using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class BookTypeRepository : GenericRepository<BookType>, IBookTypeRepository
    {
        public BookTypeRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<BookType> Finding(string name)
        {
            return _dbContext.Set<BookType>().Where(bookType => bookType.TypeName.Contains(name)).ToList();
        }
    }
}
