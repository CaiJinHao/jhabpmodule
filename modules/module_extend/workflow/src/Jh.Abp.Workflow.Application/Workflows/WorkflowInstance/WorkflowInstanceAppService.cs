using Jh.Abp.Extensions;
using Jh.Abp.JhIdentity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jh.Abp.Workflow
{
    public class WorkflowInstanceAppService
        : CrudApplicationService<WorkflowInstance, WorkflowInstanceDto, WorkflowInstanceDto, System.Guid, WorkflowInstanceRetrieveInputDto, WorkflowInstanceCreateInputDto, WorkflowInstanceUpdateInputDto, WorkflowInstanceDeleteInputDto>,
        IWorkflowInstanceAppService
    {
        protected IIdentityUserAppService identityUserAppService => LazyServiceProvider.LazyGetRequiredService<IIdentityUserAppService>();

        protected IWorkflowBacklogAppService backlogAppService => LazyServiceProvider.LazyGetRequiredService<IWorkflowBacklogAppService>();
        protected IJhWorkflowHost workflowHost => LazyServiceProvider.LazyGetRequiredService<IJhWorkflowHost>();
        protected IWorkflowDefinitionAppService workflowDefinitionAppService => LazyServiceProvider.LazyGetRequiredService<IWorkflowDefinitionAppService>();
        protected IJhWorkflowHost jhWorkflowHost => LazyServiceProvider.LazyGetRequiredService<IJhWorkflowHost>();
        private readonly IWorkflowInstanceRepository WorkflowInstanceRepository;
        public WorkflowInstanceAppService(IWorkflowInstanceRepository repository) : base(repository)
        {
            WorkflowInstanceRepository = repository;
        }

        /// <summary>
        /// 兼容使用JSON注册的工作流
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

            var def = await workflowDefinitionAppService.GetAsync(new Guid(workflowStartDto.Id));
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
            }
            //throw new DataMisalignedException("没有定义Workflow"); 可能使用的是Json注册的

            //没有部门领导会跳过，自动执行下一步骤
            return await workflowHost.StartWorkflow(workflowStartDto.Id.ToString(), workflowStartDto.Version, workflowData);
        }

        public async Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceDeatilAsync(string workflowId)
        {
            return await workflowHost.GetWorkflowInstanceAsync(workflowId);
        }

        public async Task WorkflowPublishEventAsync(WorkflowPublishEventDto workflowPublishEventDto)
        {
            //判断发布事件人和待办人是否一致,否则不允许发布事件
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
                    throw new InvalidOperationException($"审批结果参数错误：ApprovalResult:{approvalResult}");
                }
            }
            else
            {
                throw new Exception("代办人与当前登录人不一致!");
            }
        }

        public async Task PendingActivityAsync(string activityName, string workflowId, object result)
        {
            var activity = await workflowHost.GetPendingActivity(activityName, workflowId);//必须等待时间才能获取到
            if (activity != null)
            {
                await workflowHost.SubmitActivitySuccess(activity.Token, result);
            }
            await workflowHost.WaitForWorkflowToCompleteAsync(workflowId, TimeSpan.FromSeconds(5));
        }
    }
}
