using NominalBackend.Domain.Images.Models;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Images.Services
{
    public interface IColorService :ICrudService<Color>
    {

    }

    public class ColorService : CrudService<Color>, IColorService
    {
        public ColorService(IUnitOfWork unitOfWork, ICrudRepository<Color> repository) : base(unitOfWork, repository)
        {
        }
    }
}
