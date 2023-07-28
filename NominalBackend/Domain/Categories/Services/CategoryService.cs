using NominalBackend.Domain.Categories.Models;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Categories.Services
{
    public interface ICategoryService : ICrudService<Category>
    {

    }
    public class CategoryService : CrudService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, ICrudRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
    }
}
