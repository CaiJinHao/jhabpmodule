using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    [NotShowStep]
    public class WorkflowEndStep : StepBody
    {
        public string Remark { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Outcome(Remark);
        }
    }
}
