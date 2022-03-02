using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 发起休假申请
    /// </summary>
    [Description("发起休假申请")]
    public class LeaveStartStep : StepBody
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

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            //插入休假申请数据
            Log.Information($"插入休假表数据记录中:{JsonConvert.SerializeObject(this)}");
            return ExecutionResult.Next();
        }
    }
}
