using NominalBackend.Domain.Items.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Items.Repositories
{
    public interface IItemRepository : ICrudRepository<Item>
    {

    }
    public class ItemRepository : CrudRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
