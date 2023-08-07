using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Generics;
using NominalBackend.Helpers.Enums;
using NominalBackend.Helpers.Filters;
using NominalBackend.Persistence;
using System.Text;

namespace NominalBackend.Domain.Items.Repositories
{
    public interface IItemRepository : ICrudRepository<Item>
    {
        Task<IEnumerable<Item>> FilterItems(ItemFilter filter);
        Task<int> CountItemsNumberWithActiveState();
        Task<IEnumerable<Item>> GetItemsByIds(List<int> itemIds);
    }
    public class ItemRepository : CrudRepository<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountItemsNumberWithActiveState()
        {
            var count = await _dbContext.Items.Where(a=> a.State == State.Active).CountAsync();
            return count;
        }

        public async Task<IEnumerable<Item>> FilterItems(ItemFilter filter)
        {
            var query = $"SELECT * FROM [Items] AS item";
            var parameters = new List<SqlParameter>();
            var firstFilter = true;
            foreach (var property in typeof(ItemFilter).GetProperties()
                     .Where(property => property.Name.StartsWith("CategoryId") || property.Name.StartsWith("SubCategoryId")))
            {
                var propertyFilterValue = property.GetValue(filter);
                if (propertyFilterValue != null)
                {
                    var filterString = $"item.{property.Name} = {propertyFilterValue}";
                    query += firstFilter ? $" WHERE {filterString}" : $" AND {filterString}";
                    firstFilter = false;
                    parameters.Add(new SqlParameter(property.Name, propertyFilterValue));
                }
            }
            var priceFromParameter = filter.PriceFrom != null
                ? new SqlParameter("@priceFrom", filter.PriceFrom)
                : null;
            parameters.Add(priceFromParameter);
            var priceToParameter = filter.PriceTo != null
                ? new SqlParameter("@priceTo", filter.PriceTo)
                : null;
            parameters.Add(priceToParameter);

            if (filter.PriceFrom != null && filter.PriceTo != null)
            {
                query += firstFilter ? " WHERE" : " AND";
                query += $" item.Price BETWEEN @priceFrom AND @priceTo";
            }
            else if (filter.PriceFrom != null)
            {
                query += firstFilter ? " WHERE" : " AND";
                query += $" item.Price >= @priceFrom";
            }
            else if (filter.PriceTo != null)
            {
                query += firstFilter ? " WHERE" : " AND";
                query += $" item.Price <= @priceTo";
            }
            var sortedBy = filter.SortedBy;
            if (sortedBy.HasValue && sortedBy != null)
            {
                query += $" \nORDER BY {filter.SortedBy.Value} ";
                switch (filter.PriceBySorting)
                {
                    case Sorting.Ascending:
                        query += "ASC";
                        break;
                    case Sorting.Descending:
                        query += "DESC";
                        break;
                }
            }

            return await _dbContext.Items.FromSqlRaw(query, parameters.ToArray()).ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByIds(List<int> itemIds)
        {
            var items = await _dbContext.Items
                    .Where(item => itemIds.Contains(item.Id))
                    .ToListAsync();
            return items;
        }
    }
}
