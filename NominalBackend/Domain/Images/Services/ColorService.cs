using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Images.Repositories;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Images.Services
{
    public interface IColorService :ICrudService<Color>
    {
        Task<IEnumerable<Color>> GetColorsForItemsById(int itemId);
    }

    public class ColorService : CrudService<Color>, IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IUnitOfWork unitOfWork, ICrudRepository<Color> repository, IColorRepository colorRepository) : base(unitOfWork, repository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<IEnumerable<Color>> GetColorsForItemsById(int itemId)
        {
            return await _colorRepository.GetColorsForItemsById(itemId);
        }
    }
}
