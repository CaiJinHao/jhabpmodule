using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.Workflow.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.ObjectMapping;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
	public class WorkflowInstanceRepository : CrudRepository<WorkflowDbContext, WorkflowInstance, System.Guid>, IWorkflowInstanceRepository
	{

        public WorkflowInstanceRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}


        public async Task<IEnumerable<WorkflowCore.Models.WorkflowInstance>> GetWorkflowInstances(WorkflowStatus? status, string type, DateTime? createdFrom, DateTime? createdTo, int skip, int take)
        {
            var query = (await GetDbSetAsync())
                  .AsNoTracking()
                  .Include(wf => wf.ExecutionPointers)
                  .ThenInclude(ep => ep.ExtensionAttributes)
                  .Include(wf => wf.ExecutionPointers)
                  .AsQueryable();

            if (status.HasValue)
                query = query.Where(x => x.Status == status.Value);

            if (!String.IsNullOrEmpty(type))
                query = query.Where(x => x.WorkflowDefinitionId == type);

            if (createdFrom.HasValue)
                query = query.Where(x => x.CreationTime >= createdFrom.Value);

            if (createdTo.HasValue)
                query = query.Where(x => x.CreationTime <= createdTo.Value);

            var entitys = await query.Skip(skip).Take(take).ToListAsync();
            List<WorkflowCore.Models.WorkflowInstance> result = new List<WorkflowCore.Models.WorkflowInstance>();

            foreach (var item in entitys)
            {
                result.Add(item.ToWorkflowInstance());
            }
            return result;
        }

         public async Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstance(string Id, CancellationToken cancellationToken = default)
        {
            var uid = new Guid(Id);
            var entity = await (await GetDbSetAsync())
                  .AsNoTracking()
                .Include(wf => wf.ExecutionPointers)
                .ThenInclude(ep => ep.ExtensionAttributes)
                .Include(wf => wf.ExecutionPointers)
                .FirstAsync(x => x.Id == uid, cancellationToken);

            if (entity == null)
                return null;

            return entity.ToWorkflowInstance();
        }

        public async Task<IEnumerable<WorkflowCore.Models.WorkflowInstance>> GetWorkflowInstances(IEnumerable<string> ids, CancellationToken cancellationToken = default)
        {
            if (ids == null)
            {
                return new List<WorkflowCore.Models.WorkflowInstance>();
            }
            var uids = ids.Select(i => new Guid(i));
            var entitys = (await GetDbSetAsync())
                  .AsNoTracking()
                .Include(wf => wf.ExecutionPointers)
                .ThenInclude(ep => ep.ExtensionAttributes)
                .Include(wf => wf.ExecutionPointers)
                .Where(x => uids.Contains(x.Id));

            return entitys.Select(i => i.ToWorkflowInstance());
        }

        public async Task PersistWorkflow(WorkflowCore.Models.WorkflowInstance workflow, CancellationToken cancellationToken = default)
        {
            var uid = new Guid(workflow.Id);
            var existingEntity = await (await GetDbSetAsync())
                .AsTracking()
                .Where(x => x.Id == uid)
                .Include(wf => wf.ExecutionPointers)
                .ThenInclude(ep => ep.ExtensionAttributes)
                .Include(wf => wf.ExecutionPointers)
                .AsTracking()
                .FirstAsync(cancellationToken);

            workflow.ToPersistable(existingEntity);
            await SaveChangesAsync(cancellationToken);
        }
    }
}
