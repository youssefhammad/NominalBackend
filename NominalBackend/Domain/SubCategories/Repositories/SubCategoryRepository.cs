using NominalBackend.Domain.SubCategories.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.SubCategories.Repositories
{
    public interface ISubCategoryRepository : ICrudRepository<SubCategory>
    {

    }
    public class SubCategoryRepository : CrudRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
