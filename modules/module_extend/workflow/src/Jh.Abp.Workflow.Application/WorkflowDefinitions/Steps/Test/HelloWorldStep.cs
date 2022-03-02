using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    [Description("你好")]
    public class HelloWorldStep : StepBody
    {
        [OutputProperty]
        [InputProperty]
        public string Name { get;set; }

        [Description("输出问好文本，并改变输入内容")]
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine($"{Name} Hello world");
            Name += "change Name";
            return ExecutionResult.Next();
        }
    }
}
