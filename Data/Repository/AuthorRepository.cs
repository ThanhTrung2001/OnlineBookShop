using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Author> Finding(string name)
        {
            return _dbContext.Set<Author>().Where(author => author.AuthorName.Contains(name)).ToList();
        }
    }
}
