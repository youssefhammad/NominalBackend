using NominalBackend.Domain.SubCategories.Models;
using NominalBackend.Domain.SubCategories.Repositories;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.SubCategories.Services
{
    public interface ISubCategoryService : ICrudService<SubCategory>
    {
        Task<bool> IsSubCategoryRelatesToCategoty(int subCategoryId, int categoryId);
    }
    public class SubCategoryService : CrudService<SubCategory>, ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(IUnitOfWork unitOfWork, ICrudRepository<SubCategory> repository,
            ISubCategoryRepository subCategoryRepository) : base(unitOfWork, repository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<bool> IsSubCategoryRelatesToCategoty(int subCategoryId, int categoryId)
        {
            var result = await _subCategoryRepository.GetSubCategoryBycategoryId(subCategoryId, categoryId);
            return result != null ? true : false;
        }
    }
}
