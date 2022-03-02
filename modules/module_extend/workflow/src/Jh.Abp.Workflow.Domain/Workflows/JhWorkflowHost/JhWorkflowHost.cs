using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Services;

namespace Jh.Abp.Workflow
{
    public class JhWorkflowHost : WorkflowHost, IJhWorkflowHost, ITransientDependency
    {
        private readonly IEnumerable<IBackgroundTask> _backgroundTasks;
        private readonly IWorkflowController _workflowController;
        private readonly IActivityController _activityController;
        public JhWorkflowHost(IPersistenceProvider persistenceStore, IQueueProvider queueProvider, WorkflowOptions options, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IWorkflowRegistry registry, IDistributedLockProvider lockProvider, IEnumerable<IBackgroundTask> backgroundTasks, IWorkflowController workflowController, ILifeCycleEventHub lifeCycleEventHub, ISearchIndex searchIndex, IActivityController activityController) : base(persistenceStore, queueProvider, options, loggerFactory, serviceProvider, registry, lockProvider, backgroundTasks, workflowController, lifeCycleEventHub, searchIndex, activityController)
        {
            _backgroundTasks = backgroundTasks;
            _workflowController = workflowController;
            _activityController = activityController;
        }

        public bool IsRegistered(string workflowId, int version)
        {
            return Registry.IsRegistered(workflowId, version);
        }

        public async Task WaitForWorkflowToCompleteAsync(string workflowId, TimeSpan timeOut)
        {
            var status = await GetStatusAsync(workflowId);
            var counter = 0;
            while ((status == WorkflowStatus.Runnable) && (counter < (timeOut.TotalMilliseconds / 100)))
            {
                Thread.Sleep(100);
                counter++;
                status = await GetStatusAsync(workflowId);
            }
        }

        public async Task<WorkflowStatus> GetStatusAsync(string workflowId)
        {
            var instance = await GetWorkflowInstanceAsync(workflowId);
            return instance.Status;
        }

        public async Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceAsync(string workflowId)
        {
            return await PersistenceStore.GetWorkflowInstance(workflowId);
        }
    }
}
