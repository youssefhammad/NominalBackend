using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.WebSiteStaticInfo.StaticData.Repositories
{
    public interface IStaticDataRepository : ICrudRepository<StaticData.Models.StaticData>
    {

    }

    public class StaticDataRepository : CrudRepository<StaticData.Models.StaticData>, IStaticDataRepository
    {
        public StaticDataRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
