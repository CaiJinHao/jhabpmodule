using System.Threading.Tasks;

namespace Jh.Abp.JhIdentity
{
	public interface IIdentityUserBaseAppService
	{
		//用于添加与RemoteService公共的方法
		Task RecoverAsync(System.Guid id,bool isDelete);
	}
}
