using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    /*public class PushNotificationsWorkflow : IWorkflow<PushNtificationsWorkflowDto>
    {
        public void Build(IWorkflowBuilder<PushNtificationsWorkflowDto> builder)
        {
            builder
               .UseDefaultErrorBehavior(WorkflowErrorHandling.Suspend)
               .StartWith<PushNotificationsStep>()
               .Input(step => step.UserId, dto => dto.PushNotificationsEventDto.UserId)
               .Input(step => step.Text, dto => dto.PushNotificationsEventDto.Text)
               .Input(step => step.PushNotificationsEventDto, dto => dto.PushNotificationsEventDto)

               //.Output(step => step.PushNotificationsEventDto.UserId, step => step.UserId)//输出更改后得内容
               //.Output(step => step.PushNotificationsEventDto.Text, step => step.Text) //输出更改后得内容
               //外部事件
               .WaitFor("MyEvent", (data, context) => context.Workflow.Id)
                             .Output(step => step.PushNotificationsEventDto, dto => dto.EventData)//后者为外部传入数据

               .Then<PushNotificationsStep>()
               .Input(step => step.UserId, dto => dto.PushNotificationsEventDto.UserId)
               .Input(step => step.Text, dto => dto.PushNotificationsEventDto.Text)
               .Input(step => step.PushNotificationsEventDto, dto => dto.PushNotificationsEventDto)
               //         .Activity("act-1", data => data.PushNotificationsEventDto)
               //         .Output(data => data.PushNotificationsEventDto, step => step.Result)
               //                    .Then<PushNotificationsStep>()
               //.Input(step => step.UserId, dto => dto.PushNotificationsEventDto.UserId)
               //.Input(step => step.Text, dto => dto.PushNotificationsEventDto.Text)
               //.Input(step => step.PushNotificationsEventDto, dto => dto.PushNotificationsEventDto)
            ;
        }

        public string Id => "PushNotifications";

        public int Version => 1;

    }*/
}
