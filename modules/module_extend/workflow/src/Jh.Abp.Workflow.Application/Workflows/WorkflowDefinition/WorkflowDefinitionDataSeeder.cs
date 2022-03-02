
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using System.Linq;
using Volo.Abp.Application.Dtos;


namespace Jh.Abp.Workflow.Workflows.WorkflowDefinition
{
    public class WorkflowDefinitionDataSeeder : ITransientDependency, IWorkflowDefinitionDataSeeder
    {
        public IWorkflowDefinitionRepository workflowDefinitionRepository { get; set; }

        public async Task SeedAsync()
        {
            var datas = await workflowDefinitionRepository.GetListAsync();
            if (!datas.Any())
            {
                await workflowDefinitionRepository.CreateAsync(new Workflow.WorkflowDefinition()
                {
                    BusinessType = 1,
                    Version = 1,
                    Description = "休假审批",
                    JsonDefinition = "[ { \"id\": \"WorkflowStartStep\", \"name\": \"发起流程\", \"stepType\": \"Jh.Abp.Workflow.WorkflowStartStep, Jh.Abp.Workflow.Application\", \"className\": \"Jh.Abp.Workflow.WorkflowStartStep\", \"assemblyName\": \"Jh.Abp.JhWebApp.Application\", \"nextStepId\": \"jingli\", \"sourceEndpointId\": null, \"targetEndpointId\": null, \"Inputs\": { \"BusinessDataId\": \"data[\\\"BusinessDataId\\\"]\" } }, { \"id\": \"jingli\", \"name\": \"经理审批\", \"stepType\": \"Jh.Abp.Workflow.SuperiorApprovalStep,Jh.Abp.Workflow.Application\", \"className\": \"Jh.Abp.Workflow.SuperiorApprovalStep\", \"assemblyName\": \"Jh.Abp.Workflow.Application\", \"nextStepId\": \"decide_zhuguan\", \"Outputs\": { \"Remark\": \"step.Remark\", \"ApprovalResult\": \"step.ApprovalResult\", \"ParentApprovalUserId\": \"step.ParentApprovalUserId\" }, \"x\": 242, \"y\": 331 }, { \"Id\": \"decide_zhuguan\", \"StepType\": \"WorkflowCore.Primitives.Decide, WorkflowCore\", \"SelectNextStep\": { \"zhuguan\": \"Convert.ToInt32(data[\\\"Day\\\"])>1&&Convert.ToInt32(data.ApprovalResult)!=2\", \"WorkflowEndStep\": \"!(Convert.ToInt32(data[\\\"Day\\\"])>1&&Convert.ToInt32(data.ApprovalResult)!=2)\" } }, { \"id\": \"zhuguan\", \"name\": \"主管审批\", \"stepType\": \"Jh.Abp.Workflow.SuperiorApprovalStep,Jh.Abp.Workflow.Application\", \"className\": \"Jh.Abp.Workflow.SuperiorApprovalStep\", \"assemblyName\": \"Jh.Abp.Workflow.Application\", \"nextStepId\": \"decide_fuzong\", \"Inputs\": { \"ParentApprovalUserId\": \"data.ParentApprovalUserId\" }, \"Outputs\": { \"Remark\": \"step.Remark\", \"ApprovalResult\": \"step.ApprovalResult\", \"ParentApprovalUserId\": \"step.ParentApprovalUserId\" }, \"x\": 242, \"y\": 331 }, { \"Id\": \"decide_fuzong\", \"StepType\": \"WorkflowCore.Primitives.Decide, WorkflowCore\", \"SelectNextStep\": { \"fuzong\": \"Convert.ToInt32(data[\\\"Day\\\"])>=3&&Convert.ToInt32(data.ApprovalResult)!=2\", \"WorkflowEndStep\": \"!(Convert.ToInt32(data[\\\"Day\\\"])>=3&&Convert.ToInt32(data.ApprovalResult)!=2)\" } }, { \"id\": \"fuzong\", \"name\": \"副总审批\", \"stepType\": \"Jh.Abp.Workflow.UserApprovalStep,Jh.Abp.Workflow.Application\", \"className\": \"Jh.Abp.Workflow.UserApprovalStep\", \"assemblyName\": \"Jh.Abp.Workflow.Application\", \"nextStepId\": \"decide_zongjingli\", \"Inputs\": { \"Remark\": \"data.Remark\", \"ApprovalResult\": \"data.ApprovalResult\", \"ParentApprovalUserId\": \"data.ParentApprovalUserId\", \"UserId\": \"\\\"3a022d2e-ce4b-7c45-5200-d4a9c999ff51\\\"\" }, \"Outputs\": { \"Remark\": \"step.Remark\", \"ApprovalResult\": \"step.ApprovalResult\" }, \"x\": 242, \"y\": 331 }, { \"Id\": \"decide_zongjingli\", \"StepType\": \"WorkflowCore.Primitives.Decide, WorkflowCore\", \"SelectNextStep\": { \"zongjingli\": \"Convert.ToInt32(data[\\\"Day\\\"])>=5&&Convert.ToInt32(data.ApprovalResult)!=2\", \"WorkflowEndStep\": \"!(Convert.ToInt32(data[\\\"Day\\\"])>=5&&Convert.ToInt32(data.ApprovalResult)!=2)\" } }, { \"id\": \"zongjingli\", \"name\": \"总经理审批\", \"stepType\": \"Jh.Abp.Workflow.UserApprovalStep,Jh.Abp.Workflow.Application\", \"className\": \"Jh.Abp.Workflow.UserApprovalStep\", \"assemblyName\": \"Jh.Abp.Workflow.Application\", \"nextStepId\": \"WorkflowEndStep\", \"Inputs\": { \"ParentApprovalUserId\": \"data.ParentApprovalUserId\", \"UserId\": \"\\\"3a022d30-c609-4ae4-b887-a33df79fb687\\\"\" }, \"Outputs\": { \"Remark\": \"step.Remark\" }, \"x\": 242, \"y\": 331 }, { \"id\": \"WorkflowEndStep\", \"name\": \"流程结束\", \"stepType\": \"Jh.Abp.Workflow.WorkflowEndStep,Jh.Abp.Workflow.Application\", \"className\": \"Jh.Abp.Workflow.WorkflowEndStep\", \"assemblyName\": \"Jh.Abp.Workflow.Application\", \"Inputs\": { \"Remark\": \"data.Remark\" }, \"x\": 242, \"y\": 331 } ]\n"
                });
            }
        }
    }
}
