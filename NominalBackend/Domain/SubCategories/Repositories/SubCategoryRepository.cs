using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.SubCategories.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.SubCategories.Repositories
{
    public interface ISubCategoryRepository : ICrudRepository<SubCategory>
    {
        Task<SubCategory> GetSubCategoryBycategoryId(int subCategoryId, int categoryId);
        Task<IEnumerable<SubCategory>> GetAllSubCategoriesbyCategoryId(int categoryId);
    }
    public class SubCategoryRepository : CrudRepository<SubCategory>, ISubCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SubCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesbyCategoryId(int categoryId)
        {
            var subCategories = await _dbContext.SubCategories.Where(a => a.CategoryId == categoryId).ToListAsync();
            return subCategories;
        }

        public async Task<SubCategory> GetSubCategoryBycategoryId(int subCategoryId, int categoryId)
        {
            var result = await _dbContext.SubCategories.
                Where(a=> a.Id == subCategoryId && a.CategoryId == categoryId).FirstOrDefaultAsync();
            return result ?? null;
        }
    }
}
