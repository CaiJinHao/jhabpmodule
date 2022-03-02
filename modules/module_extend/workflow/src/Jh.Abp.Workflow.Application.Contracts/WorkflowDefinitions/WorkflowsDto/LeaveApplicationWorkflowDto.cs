using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 定义的是整个流程要用得字段   
    /// </summary>
    public class LeaveApplicationWorkflowDto
    {
        public LeaveStartStepDto leaveStartStepDto { get; set; }
        public LeaveApprovalStepDto leaveApprovalStepDto { get; set; }
    }

    public class LeaveStartStepDto
    {
        /// <summary>
        /// 假期类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 几天
        /// </summary>
        public int Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        /// <summary>
        /// 请假事由
        /// </summary>
        public string Remark { get; set; }
    }

    public class LeaveApprovalStepDto
    {
        /// <summary>
        /// 审批人
        /// </summary>
        public string ApprovalUser { get; set; }
        /// <summary>
        /// 审批ID
        /// </summary>
        public Guid ApprovalId { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        public bool IsApproved { get; set; }
    }
}
