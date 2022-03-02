using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;


namespace Jh.Abp.Workflow
{

    /*// 测试使用
    /// <summary>
    /// 休假申请工作流
    /// </summary>
    public class LeaveApplicationWorkflow : IWorkflow<LeaveApplicationWorkflowDto>
    {
        public string Id => "LeaveApplicationWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<LeaveApplicationWorkflowDto> builder)
        {
            builder
               .UseDefaultErrorBehavior(WorkflowErrorHandling.Suspend)
               .StartWith<LeaveStartStep>()
                    .Input(step => step.Type, data => data.leaveStartStepDto.Type)
                    .Input(step => step.Day, data => data.leaveStartStepDto.Day)
                    .Input(step => step.Start, data => data.leaveStartStepDto.Start)
                    .Input(step => step.End, data => data.leaveStartStepDto.End)
                    .Input(step => step.Remark, data => data.leaveStartStepDto.Remark)
               .WaitFor("ShenPi", (data, context) => context.Workflow.Id)
                .Output(data => data.leaveApprovalStepDto, step => step.EventData)
               .Then<LeaveApprovalStep>()
               .Input(step => step.IsApproved, data => data.leaveApprovalStepDto.IsApproved)
               .Input(step => step.ApprovalUser, data => data.leaveApprovalStepDto.ApprovalUser)
               .Output(data => data.leaveApprovalStepDto.IsApproved, step => step.IsApproved)
               ;
        }
    }*/
}
