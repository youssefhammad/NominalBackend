using NominalBackend.Domain.Items.Models;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Items.Services
{
    public interface IItemService : ICrudService<Item>
    {

    }
    public class ItemService : CrudService<Item>, IItemService
    {
        public ItemService(IUnitOfWork unitOfWork, ICrudRepository<Item> repository) : base(unitOfWork, repository)
        {
        }
    }
}
