using NominalBackend.Domain.SubCategories.Models;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.SubCategories.Services
{
    public interface ISubCategoryService : ICrudService<SubCategory>
    {

    }
    public class SubCategoryService : CrudService<SubCategory>, ISubCategoryService
    {
        public SubCategoryService(IUnitOfWork unitOfWork, ICrudRepository<SubCategory> repository) : base(unitOfWork, repository)
        {
        }
    }
}
