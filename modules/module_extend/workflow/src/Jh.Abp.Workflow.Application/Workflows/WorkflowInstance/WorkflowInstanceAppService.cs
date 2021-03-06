using Jh.Abp.Application;
using Jh.Abp.JhIdentity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Jh.Abp.Workflow
{
    public class WorkflowInstanceAppService
        : CrudApplicationService<WorkflowInstance, WorkflowInstanceDto, WorkflowInstanceDto, System.Guid, WorkflowInstanceRetrieveInputDto, WorkflowInstanceCreateInputDto, WorkflowInstanceUpdateInputDto, WorkflowInstanceDeleteInputDto>,
        IWorkflowInstanceAppService
    {
        protected IWorkflowDefinitionRepository WorkflowDefinitionRepository=>LazyServiceProvider.LazyGetRequiredService<IWorkflowDefinitionRepository>();
        protected IIdentityUserAppService identityUserAppService => LazyServiceProvider.LazyGetRequiredService<IIdentityUserAppService>();
        protected IWorkflowBacklogAppService backlogAppService => LazyServiceProvider.LazyGetRequiredService<IWorkflowBacklogAppService>();
        protected IJhWorkflowHost workflowHost => LazyServiceProvider.LazyGetRequiredService<IJhWorkflowHost>();
        protected IWorkflowRegistry WorkflowRegistry => LazyServiceProvider.LazyGetRequiredService<IWorkflowRegistry>();
        protected IWorkflowDefinitionAppService workflowDefinitionAppService => LazyServiceProvider.LazyGetRequiredService<IWorkflowDefinitionAppService>();
        protected IJhWorkflowHost jhWorkflowHost => LazyServiceProvider.LazyGetRequiredService<IJhWorkflowHost>();
        private readonly IWorkflowInstanceRepository WorkflowInstanceRepository;
        public WorkflowInstanceAppService(IWorkflowInstanceRepository repository) : base(repository)
        {
            WorkflowInstanceRepository = repository;
            CreatePolicyName = WorkflowPermissions.WorkflowInstances.Create;
            UpdatePolicyName = WorkflowPermissions.WorkflowInstances.Update;
            DeletePolicyName = WorkflowPermissions.WorkflowInstances.Delete;
            GetPolicyName = WorkflowPermissions.WorkflowInstances.Detail;
            GetListPolicyName = WorkflowPermissions.WorkflowInstances.Default;
            BatchDeletePolicyName = WorkflowPermissions.WorkflowInstances.BatchDelete;
        }

        /// <summary>
        /// ????????JSON????????????
        /// </summary>
        /// <param name="workflowStartDto"></param>
        /// <returns></returns>
        public async Task<string> StartWorkflowAsync(WorkflowStartDto workflowStartDto)
        {
            var workflowData = new WorkflowDynamicData();
            if (workflowStartDto.Data != null)
            {
                foreach (var item in workflowStartDto.Data)
                {
                    workflowData[item.Name] = item.Value;
                }
            }

            var def = await WorkflowDefinitionRepository.GetAsync(new Guid(workflowStartDto.Id));
            if (def != null)
            {
                if (!string.IsNullOrEmpty(def.InputData))
                {
                    var inputs = JsonConvert.DeserializeObject<dynamic>(def.InputData);
                    foreach (var item in inputs)
                    {
                        workflowData[item.Name] = item.Value;
                    }
                }
                workflowStartDto.Version = def.Version;

                if (!WorkflowRegistry.IsRegistered(def.Id.ToString(), def.Version))
                {
                    await WorkflowDefinitionRepository.LoadWorkflowDefinitionAsync(def);
                }
            }
            //????????????????????????????????????
            return await workflowHost.StartWorkflow(workflowStartDto.Id.ToString(), workflowStartDto.Version, workflowData);
        }

        public async Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceDeatilAsync(string workflowId)
        {
            return await workflowHost.GetWorkflowInstanceAsync(workflowId);
        }

        public async Task WorkflowPublishEventAsync(WorkflowPublishEventDto workflowPublishEventDto)
        {
            //??????????????????????????????,??????????????????
            var backlog = await backlogAppService.GetAsync(workflowPublishEventDto.BacklogId);
            if (backlog != null && backlog.BacklogUserId.Equals(CurrentUser.Id))
            {
                var eventData = new JObject();
                eventData.Add("CurrentUserId", CurrentUser.Id);
                eventData.Merge(workflowPublishEventDto.EventData);
                var approvalResult = (BacklogResultType)eventData["ApprovalResult"].Value<int>();
                if (approvalResult!= BacklogResultType.Untreated)
                {
                    await workflowHost.PublishEvent(backlog.EventName, backlog.EventKey, eventData);
                }
                else
                {
                    throw new InvalidOperationException($"??????????????????ApprovalResult:{approvalResult}");
                }
            }
            else
            {
                throw new Exception("????????????????????????!");
            }
        }

        public async Task PendingActivityAsync(string activityName, string workflowId, object result)
        {
            var activity = await workflowHost.GetPendingActivity(activityName, workflowId);//??????????????????????
            if (activity != null)
            {
                await workflowHost.SubmitActivitySuccess(activity.Token, result);
            }
            await workflowHost.WaitForWorkflowToCompleteAsync(workflowId, TimeSpan.FromSeconds(5));
        }
    }
}
