using Jh.Abp.Application;
using Jh.Abp.Application.Contracts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Jh.Abp.Workflow
{
    public class WorkflowBacklogAppService
		: CrudApplicationService<WorkflowBacklog, WorkflowBacklogDto, WorkflowBacklogDto, System.Guid, WorkflowBacklogRetrieveInputDto, WorkflowBacklogCreateInputDto, WorkflowBacklogUpdateInputDto, WorkflowBacklogDeleteInputDto>,
		IWorkflowBacklogAppService
	{
        protected IWorkflowInstanceAppService workflowInstanceAppService=>LazyServiceProvider.LazyGetRequiredService<IWorkflowInstanceAppService>();
        protected IWorkflowExecutionPointerAppService workflowExecutionPointerAppService => LazyServiceProvider.LazyGetRequiredService<IWorkflowExecutionPointerAppService>();
        private readonly IWorkflowBacklogRepository BacklogRepository;
		private readonly IWorkflowBacklogDapperRepository BacklogDapperRepository;
		public WorkflowBacklogAppService(IWorkflowBacklogRepository repository, IWorkflowBacklogDapperRepository backlogDapperRepository) : base(repository)
		{
		    BacklogRepository = repository;
		    BacklogDapperRepository = backlogDapperRepository;
            CreatePolicyName = WorkflowPermissions.WorkflowBacklogs.Create;
            UpdatePolicyName = WorkflowPermissions.WorkflowBacklogs.Update;
            DeletePolicyName = WorkflowPermissions.WorkflowBacklogs.Delete;
            GetPolicyName = WorkflowPermissions.WorkflowBacklogs.Detail;
            GetListPolicyName = WorkflowPermissions.WorkflowBacklogs.Default;
            BatchDeletePolicyName = WorkflowPermissions.WorkflowBacklogs.BatchDelete;
        }

        public override async Task<WorkflowBacklogDto> GetAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            await CheckGetPolicyAsync();
            var item = await base.GetAsync(id, includeDetails, cancellationToken);
            var _pointEntity = await workflowExecutionPointerAppService.GetAsync(item.Id);
            item.EventKey = _pointEntity.EventKey;
            item.EventName = _pointEntity.EventName;
            return item;
        }

        public override async Task<PagedResultDto<WorkflowBacklogDto>> GetListAsync(WorkflowBacklogRetrieveInputDto input, string methodStringType = "Contains", bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            await CheckGetListPolicyAsync();
            if (input.BusinessType.HasValue)
            {
                //筛选业务类型
                input.MethodInput = new MethodDto<WorkflowBacklog>()
                {
                    QueryAction = (query) => {
                        var joinTable = BacklogRepository.GetQueryableAsync<WorkflowInstance>().Result;
                        var resultQuery = from a in query
                                          join b in joinTable on a.WorkflowInstanceId equals b.Id
                                          where b.BusinessType == input.BusinessType
                                          select a;
                        return resultQuery;
                    }
                };
            }
            var pageData = await base.GetListAsync(input, methodStringType, includeDetails, cancellationToken);
            foreach (var item in pageData.Items)
            {
                var _pointEntity = await workflowExecutionPointerAppService.GetAsync(item.Id);
                var _instance = await workflowInstanceAppService.GetAsync((Guid)item.WorkflowInstanceId);
                item.EventKey = _pointEntity.EventKey;
                item.EventName= _pointEntity.EventName;
                item.BusinessDataId=_instance.BusinessDataId;
                item.BusinessType= _instance.BusinessType;
            }
            return pageData;
        }
    }
}
