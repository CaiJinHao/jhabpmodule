using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Uow;
using Jh.Abp.Common.Utils;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    public abstract class ApprovalStepBase : StepBase
    {
        /// <summary>
        /// 审批备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 审批结果枚举
        /// </summary>
        public int ApprovalResult { get; set; }
        /// <summary>
        /// 上一步骤审批人自动赋值
        /// </summary>
        public string ParentApprovalUserId { get; set; }
        /// <summary>
        /// 当前登录用户，由事件传递存储在EventData
        /// </summary>
        protected Guid currentUserId { get; set; }

        protected WorkflowDefinition currentWorkflowDefinition { get; set; }
        protected WorkflowInstance currentWorkflowInstance { get; set; }

        [UnitOfWork]
        public override ExecutionResult ExecutionRun(IStepExecutionContext context)
        {
            currentWorkflowDefinition = workflowDefinitionRepository.FindAsync(workflowDefinitionId).Result;
            currentWorkflowInstance = workflowInstanceRepository.FindAsync(workflowInstanceId).Result;

            if (!context.ExecutionPointer.EventPublished)
            {
                #region 当要跳过当前步骤，需要将这两个值向下传递

                var data = context.Workflow.Data as WorkflowDynamicData;
                ApprovalResult = Convert.ToInt32(data["ApprovalResult"] ?? 0);
                Remark = data["Remark"];

                #endregion

                return CreateBacklogAsync().Result;
            }
            //已发布事件
            var eventData = (JObject)context.ExecutionPointer.EventData;
            ApprovalResult = eventData["ApprovalResult"].Value<int>();
            Remark = eventData["Remark"].Value<string>();
            currentUserId = new Guid(eventData["CurrentUserId"].Value<string>());
            var backlog = UpdateBacklogAsync(workflowExecutionPointerId).Result;
            return EventPublishdHandler(context,backlog);
        }

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        protected virtual ExecutionResult EventPublishdHandler(IStepExecutionContext context, WorkflowBacklog backlog)
        {
            return ExecutionResult.Outcome(UtilEnums.GetEnumValueDescription((BacklogResultType)ApprovalResult));
        }

        /// <summary>
        /// 更新待办事项状态
        /// </summary>
        /// <param name="WorkflowExecutionPointerId"></param>
        /// <returns></returns>
        protected virtual async Task<WorkflowBacklog> UpdateBacklogAsync(Guid WorkflowExecutionPointerId)
        {
            var backlog = await backlogRepository.FindAsync(WorkflowExecutionPointerId);
            //比对审批人和待办人
            if (Guid.Equals(currentUserId, backlog.BacklogUserId))
            {
                backlog.BacklogResult = (BacklogResultType)ApprovalResult;
                backlog.BacklogRemark = Remark;
                backlog.BacklogHandleTime = DateTime.Now;
                return backlog;
            }
            else
            {
                throw new InvalidOperationException("审批人不一致");
            }
        }

        protected abstract Task<ExecutionResult> CreateBacklogAsync();

        /// <summary>
        /// 创建待办事项
        /// </summary>
        /// <returns></returns>
        protected async Task<ExecutionResult> CreateBacklogAsync(Volo.Abp.Identity.IdentityUser backlogUser)
        {
            //发送通知INotificationPublisher
            //添加待办事项
            await backlogRepository.CreateAsync(new WorkflowBacklog(workflowExecutionPointerId, currentWorkflowInstance.CreatorId)
            {
                WorkflowInstanceId = workflowInstanceId,
                BacklogResult = BacklogResultType.Untreated,
                BacklogUserId = backlogUser.Id,
                BacklogUserName = backlogUser.Name,
                TenantId = currentWorkflowDefinition?.TenantId,
            });
            return ExecutionResult.WaitForEvent(Guid.NewGuid().ToString(), workflowInstanceId.ToString(), DateTime.MinValue);
        }
    }
}
