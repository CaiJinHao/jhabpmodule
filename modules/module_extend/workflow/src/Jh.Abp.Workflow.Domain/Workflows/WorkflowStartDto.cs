using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.Abp.Workflow
{
    public class WorkflowStartDto
    {
        /// <summary>
        /// 工作流ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int? Version { get; set; }

        /// <summary>
        /// 工作流数据
        /// </summary>
        public dynamic Data { get; set; }
    }

    /*
     test workflow json
    {
  "Id": "35EB00F7-A6A6-1EFA-5DA3-3A00FD30EA8E",//要与数据库ID保持一致
  "Version": 1,//要与数据库Version保持一致
  "Description": "测试",
  "DataType":"Jh.Abp.Workflow.DynamicData, Jh.Abp.Workflow.Domain",//永远不会更改，且必须存在
  "Steps": [
    {
      "Id": "Hello",
      "StepType": "Jh.Abp.Workflow.HelloWorldStep, Jh.Abp.Workflow.Application",
      "ErrorBehavior": "Retry",
      "Inputs": { "Name": "data[\"Name\"]" },
      "Outputs": { "Name": "step.Name" },
      "NextStepId": "GoodbyeWorld"
    },
    {
      "Id": "GoodbyeWorld",
      "StepType": "Jh.Abp.Workflow.GoodbyeWorldStep, Jh.Abp.Workflow.Application",
      "Inputs": { "Name": "data[\"Name\"]" }
    }
  ]
}
     */
}
