using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    /*public class HelloWorldWorkflow : IWorkflow<HelloWorldWorkflowDto>
    {
        public void Build(IWorkflowBuilder<HelloWorldWorkflowDto> builder)
        {
            builder
               .UseDefaultErrorBehavior(WorkflowErrorHandling.Suspend)
               .StartWith<HelloWorldStep>().Input(step => step.Name, dto => dto.Name)
                  .Output(step => step.Name, dto => dto.Name)   //将更改值输出
               .Then<GoodbyeWorldStep>().Input(step => step.Name, dto => dto.Name);
        }

        public string Id => "HelloWorld";

        public int Version => 1;

    }*/
}
