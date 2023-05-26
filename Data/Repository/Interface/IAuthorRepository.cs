using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Repository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        public IEnumerable<Author> Finding(string name);
    }
}
