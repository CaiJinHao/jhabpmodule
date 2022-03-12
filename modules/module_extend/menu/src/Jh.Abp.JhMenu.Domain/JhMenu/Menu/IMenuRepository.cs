using Jh.Abp.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jh.Abp.JhMenu
{
    public interface IMenuRepository: ICrudRepository<Menu, System.Guid>
	{
        Task<IQueryable<Menu>> GetAllChildren(string code,bool includeDetails = false,CancellationToken cancellationToken = default);
        Task<string> GetMaxMenuCodeAsync(string parentCode);
    }
}
