using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;


namespace Jh.Abp.Workflow
{
    public class WorkflowDefinitionDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        public IWorkflowDefinitionDataSeeder workflowDefinitionDataSeeder { get; set; }
        public async Task SeedAsync(DataSeedContext context)
        {
            await workflowDefinitionDataSeeder.SeedAsync();
        }
    }
}
