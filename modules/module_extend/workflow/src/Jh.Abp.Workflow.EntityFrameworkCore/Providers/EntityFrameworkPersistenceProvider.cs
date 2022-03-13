using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using System.Threading;
using Jh.Abp.Workflow.EntityFrameworkCore;
using Volo.Abp.ObjectMapping;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Guids;
using Microsoft.Extensions.Logging;

namespace Jh.Abp.Workflow
{
    [UnitOfWork]
    public class EntityFrameworkPersistenceProvider : IPersistenceProvider, ITransientDependency
    {
        public ILogger<EntityFrameworkPersistenceProvider> Logger { get; set; }
        public IAbpLazyServiceProvider LazyServiceProvider { get; set; }
        public bool SupportsScheduledCommands => true;
        public IGuidGenerator GuidGenerator => LazyServiceProvider.LazyGetService<IGuidGenerator>(SimpleGuidGenerator.Instance);

        private IUnitOfWorkManager unitOfWorkManager => LazyServiceProvider.LazyGetRequiredService<IUnitOfWorkManager>();
        private IWorkflowScheduledCommandRepository workflowScheduledCommandRepository => LazyServiceProvider.LazyGetRequiredService<IWorkflowScheduledCommandRepository>();
        public IWorkflowExecutionErrorRepository workflowExecutionErrorRepository => LazyServiceProvider.LazyGetRequiredService<IWorkflowExecutionErrorRepository>();
        public IWorkflowEventRepository workflowEventRepository => LazyServiceProvider.LazyGetRequiredService<IWorkflowEventRepository>();
        public IWorkflowEventSubscriptionRepository workflowEventSubscriptionRepository => LazyServiceProvider.LazyGetRequiredService<IWorkflowEventSubscriptionRepository>();
        public IWorkflowInstanceRepository workflowInstanceRepository => LazyServiceProvider.LazyGetRequiredService<IWorkflowInstanceRepository>();

        private async Task SaveChangesAsync()
        {
            await unitOfWorkManager.Current.SaveChangesAsync();
        }


        public async Task<string> CreateEventSubscription(EventSubscription subscription, CancellationToken cancellationToken = default)
        {
            subscription.Id = GuidGenerator.Create().ToString();
            var entity = await workflowEventSubscriptionRepository.CreateAsync(subscription.ToPersistable(),true);
            return entity.Id.ToString();
        }


        public async Task<string> CreateNewWorkflow(WorkflowCore.Models.WorkflowInstance workflow, CancellationToken cancellationToken = default)
        {
            workflow.Id = GuidGenerator.Create().ToString();
            var entity = await workflowInstanceRepository.CreateAsync(workflow.ToPersistable(), true);
            return entity.Id.ToString();
        }

        public async Task<IEnumerable<string>> GetRunnableInstances(DateTime asAt, CancellationToken cancellationToken = default)
        {
            //var now = asAt.ToUniversalTime().Ticks;
            var now=asAt.Ticks;
            var raw = await (await workflowInstanceRepository.GetQueryableAsync())
                .AsNoTracking()
                .Where(x => x.NextExecution.HasValue && (x.NextExecution <= now) && (x.Status == WorkflowStatus.Runnable))
                .Select(x => x.Id)
                .ToListAsync(cancellationToken);

            return raw.Select(s => s.ToString()).ToList();
        }

        public async Task<IEnumerable<WorkflowCore.Models.WorkflowInstance>> GetWorkflowInstances(WorkflowStatus? status, string type, DateTime? createdFrom, DateTime? createdTo, int skip, int take)
        {
            return await workflowInstanceRepository.GetWorkflowInstances(status, type, createdFrom, createdTo, skip, take);
        }

        public async Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstance(string Id, CancellationToken cancellationToken = default)
        {
            return await workflowInstanceRepository.GetWorkflowInstance(Id, cancellationToken);
        }

        public async Task<IEnumerable<WorkflowCore.Models.WorkflowInstance>> GetWorkflowInstances(IEnumerable<string> ids, CancellationToken cancellationToken = default)
        {
            return await workflowInstanceRepository.GetWorkflowInstances(ids, cancellationToken);
        }


        public async Task PersistWorkflow(WorkflowCore.Models.WorkflowInstance workflow, CancellationToken cancellationToken = default)
        {
            await workflowInstanceRepository.PersistWorkflow(workflow, cancellationToken);
        }


        public async Task TerminateSubscription(string eventSubscriptionId, CancellationToken cancellationToken = default)
        {
            var uid = new Guid(eventSubscriptionId);
            var existing = await (await workflowEventSubscriptionRepository.GetQueryableAsync()).AsNoTracking().FirstAsync(x => x.Id == uid, cancellationToken);
            await workflowEventSubscriptionRepository.DeleteAsync(existing, true);
        }

        public async Task<IEnumerable<EventSubscription>> GetSubscriptions(string eventName, string eventKey, DateTime asOf, CancellationToken cancellationToken = default)
        {
            //asOf = asOf.ToUniversalTime();
            var entitys = await (await workflowEventSubscriptionRepository.GetQueryableAsync())
                .AsNoTracking()
                .Where(x => x.EventName == eventName && x.EventKey == eventKey && x.SubscribeAsOf <= asOf)
                .ToListAsync(cancellationToken);
            return entitys.Select(item => item.ToEventSubscription()).ToList();
        }


        public async Task<string> CreateEvent(Event newEvent, CancellationToken cancellationToken = default)
        {
            newEvent.Id = GuidGenerator.Create().ToString();
            var result = await workflowEventRepository.CreateAsync(newEvent.ToPersistable(), true);
            return result.Id.ToString();
        }

        public async Task<Event> GetEvent(string id, CancellationToken cancellationToken = default)
        {
            start:
            var raw = await (await workflowEventRepository.GetQueryableAsync())
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == new Guid(id), cancellationToken);
            if (raw == null)
            {
                Thread.Sleep(100);
                goto start;
            }
            return raw.ToEvent();
        }

        public async Task<IEnumerable<string>> GetRunnableEvents(DateTime asAt, CancellationToken cancellationToken = default)
        {
            var now = DateTime.Now;
            var raw = await (await workflowEventRepository.GetQueryableAsync())
                .AsNoTracking()
                .Where(x => !x.IsProcessed)
                .Where(x => x.CreationTime <= now)
                .Select(x => x.Id)
                .ToListAsync(cancellationToken);

            return raw.Select(s => s.ToString()).ToList();
        }


        public async Task MarkEventProcessed(string id, CancellationToken cancellationToken = default)
        {
            var uid = new Guid(id);
            var existingEntity = await (await workflowEventRepository.GetQueryableAsync())
                .AsTracking()
                .Where(x => x.Id == uid)
                .FirstAsync(cancellationToken);

            existingEntity.IsProcessed = true;
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetEvents(string eventName, string eventKey, DateTime asOf, CancellationToken cancellationToken)
        {
            var raw = await (await workflowEventRepository.GetQueryableAsync())
                    .AsNoTracking()
                    .Where(x => x.EventName == eventName && x.EventKey == eventKey)
                    .Where(x => x.CreationTime >= asOf)
                    .Select(x => x.Id)
                    .ToListAsync(cancellationToken);

            var result = new List<string>();

            foreach (var s in raw)
                result.Add(s.ToString());

            return result;
        }


        public async Task MarkEventUnprocessed(string id, CancellationToken cancellationToken = default)
        {
            var uid = new Guid(id);
            var existingEntity = await (await workflowEventRepository.GetQueryableAsync())
                .Where(x => x.Id == uid)
                .AsTracking()
                .FirstAsync(cancellationToken);

            existingEntity.IsProcessed = false;
            await SaveChangesAsync();
        }


        public async Task PersistErrors(IEnumerable<ExecutionError> errors, CancellationToken cancellationToken = default)
        {
            var executionErrors = errors as ExecutionError[] ?? errors.ToArray();
            if (executionErrors.Any())
            {
                foreach (var error in executionErrors)
                {
                    await workflowExecutionErrorRepository.CreateAsync(error.ToPersistable(), true);
                }
            }
        }

        public async Task<EventSubscription> GetSubscription(string eventSubscriptionId, CancellationToken cancellationToken = default)
        {
            var uid = new Guid(eventSubscriptionId);
            var raw = await (await workflowEventSubscriptionRepository.GetQueryableAsync()).AsNoTracking().FirstOrDefaultAsync(x => x.Id == uid, cancellationToken);
            return raw.ToEventSubscription();
        }

        public async Task<EventSubscription> GetFirstOpenSubscription(string eventName, string eventKey, DateTime asOf, CancellationToken cancellationToken = default)
        {
            var raw = await (await workflowEventSubscriptionRepository.GetQueryableAsync()).AsNoTracking().FirstOrDefaultAsync(x => x.EventName == eventName && x.EventKey == eventKey && x.SubscribeAsOf <= asOf && x.ExternalToken == null, cancellationToken);
            return raw.ToEventSubscription();
        }


        public async Task<bool> SetSubscriptionToken(string eventSubscriptionId, string token, string workerId, DateTime expiry, CancellationToken cancellationToken = default)
        {
            var existingEntity = await (await workflowEventSubscriptionRepository.GetQueryableAsync())
                .AsTracking()
                .Where(x => x.Id == new Guid(eventSubscriptionId))
                .FirstAsync(cancellationToken);

            existingEntity.ExternalToken = token;
            existingEntity.ExternalWorkerId = workerId;
            existingEntity.ExternalTokenExpiry = expiry;
            await SaveChangesAsync();
            return true;
        }


        public async Task ClearSubscriptionToken(string eventSubscriptionId, string token, CancellationToken cancellationToken = default)
        {
            var existingEntity = await (await workflowEventSubscriptionRepository.GetQueryableAsync())
                .AsTracking()
                .Where(x => x.Id == new Guid(eventSubscriptionId))
                .FirstAsync(cancellationToken);

            if (existingEntity.ExternalToken != token)
                throw new InvalidOperationException();

            existingEntity.ExternalToken = null;
            existingEntity.ExternalWorkerId = null;
            existingEntity.ExternalTokenExpiry = null;
            await SaveChangesAsync();
        }


        public async Task ScheduleCommand(ScheduledCommand command)
        {
            await workflowScheduledCommandRepository.CreateAsync(command.ToPersistable(), true);
        }


        public virtual async Task ProcessCommands(DateTimeOffset asOf, Func<ScheduledCommand, Task> action, CancellationToken cancellationToken = default)
        {
            var cursor = (await workflowScheduledCommandRepository.GetQueryableAsync()).AsNoTracking()
                     .Where(x => x.ExecuteTime < asOf.Ticks)//asOf.UtcDateTime.Ticks
                     .AsAsyncEnumerable();

            await foreach (var command in cursor)
            {
                try
                {
                    await action(command.ToScheduledCommand());
                    await workflowScheduledCommandRepository.DeleteAsync(command, true);
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                }
            }
        }

        public virtual void EnsureStoreExists()
        {

        }
    }
}
