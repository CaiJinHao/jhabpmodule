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
                //���˵�ֻ��Urlû��ִ�����ݵ����ݣ����������Controller��Service,���ǻ�洢�����Url
                await base.SaveAsync(saveHandle);
            }
        }
    }
}
