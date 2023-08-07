using NominalBackend.DataTransferObjects;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Items.Repositories;
using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Generics;
using NominalBackend.Helpers.Enums;
using NominalBackend.Helpers.Filters;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Items.Services
{
    public interface IItemService : ICrudService<Item>
    {
        Task<IEnumerable<Item>> FilterItems(ItemFilter filter);
        Task<bool> EnableNextButton(int totalNumberOfItems, int returnedItems);
        Task<int> CalculateTotalNumberOfFilteredItems(IEnumerable<Item> items);
        Task<IEnumerable<Item>> PagenateItems(IEnumerable<Item> filteredItems, int skip, int size);
        Task<IEnumerable<Item>> GetItemsByIds(List<int> itemIds, int skip, int size);
    }
    public class ItemService : CrudService<Item>, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IUnitOfWork unitOfWork, ICrudRepository<Item> repository, IItemRepository itemRepository) : base(unitOfWork, repository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<int> CalculateTotalNumberOfFilteredItems(IEnumerable<Item> items)
        {
            var itemsCount = items.Count();
            return itemsCount;
        }

        public async Task<bool> EnableNextButton(int totalNumberOfItems, int returnedItems)
        {
            if (totalNumberOfItems > returnedItems)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Item>> FilterItems(ItemFilter filter)
        {
            var filteredItems = await _itemRepository.FilterItems(filter);
            var Activeitems = filteredItems.Where(a => a.State == State.Active);
            return Activeitems;
        }

        public async Task<IEnumerable<Item>> GetItemsByIds(List<int> itemIds, int skip, int size)
        {
            var items = await _itemRepository.GetItemsByIds(itemIds);
            items.Where(a => a.State == State.Active);
            items.Skip(skip).Take(size);
            return items;
        }

        public async Task<IEnumerable<Item>> PagenateItems(IEnumerable<Item> filteredItems, int skip, int size)
        {
            var pagenatedItems = filteredItems.Skip(skip).Take(size);
            return pagenatedItems;
        }
    }
}
