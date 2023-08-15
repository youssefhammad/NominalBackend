using NominalBackend.Domain.WebSiteStaticInfo.StaticData.Models;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.WebSiteStaticInfo.StaticData.Services
{
    public interface IStaticDataService : ICrudService<Models.StaticData>
    {

    }
    public class StaticDataService : CrudService<StaticData.Models.StaticData>, IStaticDataService
    {
        public StaticDataService(IUnitOfWork unitOfWork, ICrudRepository<Models.StaticData> repository) : base(unitOfWork, repository)
        {
        }
    }
}
