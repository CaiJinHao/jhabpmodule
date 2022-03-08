using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;

namespace Jh.Abp.Workflow
{
    public static class ApplicationBuilderExtention
    {
        /// <summary>
        /// 初始化工作流定义
        /// </summary>
        public static IServiceProvider InitWorkflowDefinition(this IServiceProvider serviceProvider, Action<IWorkflowHost> registerWorkflowAction = null)
        {
            var workflowHost = serviceProvider.GetService<IWorkflowHost>();
            registerWorkflowAction?.Invoke(workflowHost);
            workflowHost.Start();

            var workflowDefinitionRepository = serviceProvider.GetRequiredService<IWorkflowDefinitionRepository>();
            //workflowDefinitionRepository.LoadWorkflowDefinitionAsync().Wait();
            workflowDefinitionRepository.LoadWorkflowDefinitionAsync("/Localization/WorkflowDefinitions/LeaveApprovalWorkflow.json").Wait();

            var appLifetime = serviceProvider.GetService<IHostApplicationLifetime>();
            appLifetime.ApplicationStopping.Register(() =>
            {
                workflowHost.Stop();
            });
            return serviceProvider;
        }
    }
}
