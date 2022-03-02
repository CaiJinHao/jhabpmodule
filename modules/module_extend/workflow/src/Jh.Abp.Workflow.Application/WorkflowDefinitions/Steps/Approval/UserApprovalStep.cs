﻿using Jh.Abp.Common.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using System.Linq;

namespace Jh.Abp.Workflow
{
    [Description("用户审批")]
    /// <summary>
    /// 用户审批，指定人员
    /// </summary>
    public class UserApprovalStep : ApprovalStepBase, ITransientDependency
    {
        /// <summary>
        /// 审批人 定义在流程中的值
        /// </summary>
        [InputProperty]
        public string UserId { get; set; }

        /// <summary>
        /// 创建待办事项
        /// </summary>
        /// <returns></returns>
        protected override async Task<ExecutionResult> CreateBacklogAsync()
        {
            var _approvalUserId = new Guid(UserId);
            if (_approvalUserId == Guid.Empty)
            {
                throw new InvalidOperationException("流程未定义审批人");
            }
            var approvalUser = await identityUserAppService.GetEntityAsync(_approvalUserId);
            var createUser = await identityUserAppService.GetEntityAsync((Guid)currentWorkflowInstance.CreatorId);
            var _parentApprovalUserId = ParentApprovalUserId == null ? Guid.Empty : new Guid(ParentApprovalUserId);
            if (_approvalUserId.Equals(currentWorkflowInstance.CreatorId)//判断审批人和创建人是否为同一人
                || _approvalUserId.Equals(_parentApprovalUserId)//当前审批人是否和上一步骤审批人相同
                || approvalUser.OrganizationUnits.Any(a=>createUser.OrganizationUnits.Any(b=>b.OrganizationUnitId==a.OrganizationUnitId))//审批人和创建人是不是同一组织
                )
            {
                return ExecutionResult.Next();//跳过当前步骤，因为提交人与当前步骤审批人是同一人
            }
            return await base.CreateBacklogAsync(approvalUser);
        }
    }
}
