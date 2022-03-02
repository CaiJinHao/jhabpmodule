using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    [Description("再见")]
    public class GoodbyeWorldStep : StepBody
    {
        [InputProperty]
        public string Name { get; set; }

        [Description("输出再见")]
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine($"{Name} Goodbye world");
            return ExecutionResult.Next();
        }
    }
}
