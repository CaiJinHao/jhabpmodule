using Jh.Abp.Common.Utils;
using Newtonsoft.Json;
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

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 直接上级审批，部门负责人审批
    /// </summary>
    public class SuperiorApprovalStep : ApprovalStepBase, ITransientDependency
    {
        protected override async Task<WorkflowBacklog> UpdateBacklogAsync(Guid WorkflowExecutionPointerId)
        {
            var backlog = await base.UpdateBacklogAsync(WorkflowExecutionPointerId);
            ParentApprovalUserId = backlog.BacklogUserId.ToString();//审批人
            return backlog;
        }

        protected override async Task<ExecutionResult> CreateBacklogAsync()
        {
            var _userId = Guid.Empty;//获取此人的上级
            if (string.IsNullOrEmpty(ParentApprovalUserId))
            {
                _userId = (Guid)currentWorkflowInstance.CreatorId;//没有上一步骤审批人时，使用创建工作流的人
            }
            else
            {
                _userId = new Guid(ParentApprovalUserId);//当循环执行当前步骤时，需要获取上个步骤的审批人的上级
            }
            var superiorUser = await identityUserAppService.GetSuperiorUserAsync(_userId);
            if (superiorUser == null)
            {
                //跳过当前步骤情况：提交人与所属部门负责人是同一人，提交人所属部门没有负责人(提交人级别高)
                return ExecutionResult.Next();//跳过当前步骤，因为提交人比当前步骤等级高
            }
            return await base.CreateBacklogAsync(superiorUser);
        }
    }

    /*
发布事件data
{
  "eventData": {
    "Remark": "同意",
    "ApprovalResult": 1
  },
  "backlogId": "ef96ab17-e959-41c2-8e1c-6d9494e128c7"
}
     */
}
