using Jh.Abp.Common.Utils;
using Jh.Abp.JhIdentity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.Users;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using System.Linq;

namespace Jh.Abp.Workflow
{
    public abstract class StepBase : StepBody
    {
        protected Guid workflowExecutionPointerId { get; set; }
        protected Guid workflowInstanceId { get; set; }
        protected Guid workflowDefinitionId { get; set; }

        public IAbpLazyServiceProvider LazyServiceProvider { get; set; }
        protected IWorkflowDefinitionRepository workflowDefinitionRepository => LazyServiceProvider.LazyGetRequiredService<IWorkflowDefinitionRepository>();
        protected IWorkflowInstanceRepository workflowInstanceRepository => LazyServiceProvider.LazyGetRequiredService<IWorkflowInstanceRepository>();
        protected IWorkflowBacklogRepository backlogRepository => LazyServiceProvider.LazyGetRequiredService<IWorkflowBacklogRepository>();
        protected IIdentityUserAppService identityUserAppService => LazyServiceProvider.LazyGetRequiredService<IIdentityUserAppService>();
        protected IDateTimeProvider _datetimeProvider => LazyServiceProvider.LazyGetRequiredService<IDateTimeProvider>();
        protected IWorkflowRegistry workflowRegistry => LazyServiceProvider.LazyGetRequiredService<IWorkflowRegistry>();
        protected IPersistenceProvider persistenceProvider => LazyServiceProvider.LazyGetRequiredService<IPersistenceProvider>();
        protected Volo.Abp.Identity.IdentityUserManager identityUserManager =>LazyServiceProvider.LazyGetRequiredService<Volo.Abp.Identity.IdentityUserManager>();
        public abstract ExecutionResult ExecutionRun(IStepExecutionContext context);

        [UnitOfWork]
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            workflowInstanceId = new Guid(context.Workflow.Id);
            workflowExecutionPointerId = new Guid(context.ExecutionPointer.Id);
            workflowDefinitionId = new Guid(context.Workflow.WorkflowDefinitionId);
            return ExecutionRun(context);
        }
    }
}
