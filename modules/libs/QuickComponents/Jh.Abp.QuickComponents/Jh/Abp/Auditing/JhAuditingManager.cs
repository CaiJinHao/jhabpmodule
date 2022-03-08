using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace Jh.Abp.QuickComponents
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IAuditingManager))]
    public class JhAuditingManager : AuditingManager, IAuditingManager, ITransientDependency
    {
        public JhAuditingManager(IAmbientScopeProvider<IAuditLogScope> ambientScopeProvider, IAuditingHelper auditingHelper, IAuditingStore auditingStore, IServiceProvider serviceProvider, IOptions<AbpAuditingOptions> options) : base(ambientScopeProvider, auditingHelper, auditingStore, serviceProvider, options)
        {
        }

        protected override async Task SaveAsync(DisposableSaveHandle saveHandle)
        {
            if (saveHandle.AuditLog.Actions.Any())
            {
                //过滤掉只有Url没有执行内容的数据，比如禁用了Controller和Service,还是会存储请求的Url
                await base.SaveAsync(saveHandle);
            }
        }
    }
}
