using NominalBackend.Domain.Categories.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Categories.Repositories
{
    public interface ICategoryRepository : ICrudRepository<Category>
    {

    }
    public class CategoryRepository : CrudRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
