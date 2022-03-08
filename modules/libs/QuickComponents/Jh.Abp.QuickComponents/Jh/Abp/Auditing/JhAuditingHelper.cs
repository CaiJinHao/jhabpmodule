using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Clients;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Timing;
using Volo.Abp.Tracing;
using Volo.Abp.Users;

namespace Jh.Abp.QuickComponents.Jh.Abp.Auditing
{
#if DEBUG
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IAuditingHelper))]
    public class JhAuditingHelper : AuditingHelper, IAuditingHelper, ITransientDependency
    {
        public JhAuditingHelper(IAuditSerializer auditSerializer, IOptions<AbpAuditingOptions> options, ICurrentUser currentUser, ICurrentTenant currentTenant, ICurrentClient currentClient, IClock clock, IAuditingStore auditingStore, ILogger<AuditingHelper> logger, IServiceProvider serviceProvider, ICorrelationIdProvider correlationIdProvider) : base(auditSerializer, options, currentUser, currentTenant, currentClient, clock, auditingStore, logger, serviceProvider, correlationIdProvider)
        {
        }

        public override bool ShouldSaveAudit(MethodInfo methodInfo, bool defaultValue = false)
        {
            var data = base.ShouldSaveAudit(methodInfo, defaultValue);
            return data;
        }
    }
#endif
}
