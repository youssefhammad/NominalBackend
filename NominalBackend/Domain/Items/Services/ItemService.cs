using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Items.Repositories;
using NominalBackend.Generics;
using NominalBackend.Helpers.Filters;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Items.Services
{
    public interface IItemService : ICrudService<Item>
    {
        Task<IEnumerable<Item>> FilterItems(ItemFilter filter);
    }
    public class ItemService : CrudService<Item>, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IUnitOfWork unitOfWork, ICrudRepository<Item> repository, IItemRepository itemRepository) : base(unitOfWork, repository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Item>> FilterItems(ItemFilter filter)
        {
            var items = await _itemRepository.FilterItems(filter);
            return items;
        }
    }
}
