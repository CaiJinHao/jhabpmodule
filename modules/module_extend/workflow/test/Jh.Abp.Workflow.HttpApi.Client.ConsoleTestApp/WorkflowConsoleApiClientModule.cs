using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WorkflowHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class WorkflowConsoleApiClientModule : AbpModule
{

}
