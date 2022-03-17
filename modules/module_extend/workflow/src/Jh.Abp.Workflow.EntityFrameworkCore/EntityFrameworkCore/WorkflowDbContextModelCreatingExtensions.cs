using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Jh.Abp.Workflow.EntityFrameworkCore;

public static class WorkflowDbContextModelCreatingExtensions
{
    public static void ConfigureWorkflow(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));


        builder.Entity<WorkflowDefinition>(b =>
        {
            b.ToTable(WorkflowDbProperties.DbTablePrefix + "WorkflowDefinition", WorkflowDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Version).HasComment("工作流版本");
            b.Property(p => p.Description).HasMaxLength(200).HasComment("工作流描述");
            b.Property(p => p.JsonDefinition).HasComment("流程JSON定义");
            b.Property(p => p.InputData).HasComment("流程输入数据");
            b.Property(p => p.FormDefinition).HasComment("流程表单定义HTML");
            b.Property(p => p.BusinessType).HasComment("业务类型");

            b.HasIndex(x => x.Version);
            b.ApplyObjectExtensionMappings();
        });

        builder.Entity<WorkflowInstance>(b =>
        {
            b.ToTable(WorkflowDbProperties.DbTablePrefix + "WorkflowInstance", WorkflowDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.Property(p => p.WorkflowDefinitionId).HasMaxLength(36).HasComment("工作流定义ID");
            b.Property(p => p.Version).HasComment("实例版本");
            b.Property(p => p.Description).HasMaxLength(200).HasComment("实例描述");
            b.Property(p => p.Reference).HasMaxLength(200).HasComment("实例引用");
            b.Property(p => p.NextExecution).HasComment("NextExecution");
            b.Property(p => p.Data).HasComment("Data");
            b.Property(p => p.CompleteTime).HasComment("CompleteTime");
            b.Property(p => p.Status).HasComment("实例状态");
            b.Property(p => p.BusinessType).HasComment("业务类型");
            b.Property(p => p.BusinessDataId).HasMaxLength(60).HasComment("业务数据ID");


            //Properties
            b.HasIndex(x => x.WorkflowDefinitionId);
            b.HasIndex(x => x.NextExecution);
            b.HasIndex(q => q.CreationTime);
        });


        builder.Entity<WorkflowExecutionPointer>(b =>
        {
            //Configure table & schema name
            b.ToTable(WorkflowDbProperties.DbTablePrefix + "WorkflowExecutionPointer", WorkflowDbProperties.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<WorkflowEvent>(b =>
        {
            //Configure table & schema name
            b.ToTable(WorkflowDbProperties.DbTablePrefix + "WorkflowEvent", WorkflowDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.HasIndex(x => new { x.EventName, x.EventKey });
            b.HasIndex(x => x.CreationTime);
            b.HasIndex(x => x.IsProcessed);
        });

        builder.Entity<WorkflowEventSubscription>(b =>
        {
            //Configure table & schema name
            b.ToTable(WorkflowDbProperties.DbTablePrefix + "WorkflowEventSubscription", WorkflowDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.HasIndex(x => x.EventName);
            b.HasIndex(x => x.EventKey);
        });

        builder.Entity<WorkflowExecutionError>(b =>
        {
            //Configure table & schema name
            b.ToTable(WorkflowDbProperties.DbTablePrefix + "WorkflowExecutionError", WorkflowDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id).ValueGeneratedOnAdd();

        });

        builder.Entity<WorkflowExtensionAttribute>(b =>
        {
            //Configure table & schema name
            b.ToTable(WorkflowDbProperties.DbTablePrefix + "WorkflowExtensionAttribute", WorkflowDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id).ValueGeneratedOnAdd();

        });

        builder.Entity<WorkflowScheduledCommand>(b =>
        {
            //Configure table & schema name
            b.ToTable(WorkflowDbProperties.DbTablePrefix + "WorkflowScheduledCommand", WorkflowDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id).ValueGeneratedOnAdd();

        });

        builder.Entity<WorkflowBacklog>(b => {
            b.ToTable(WorkflowDbProperties.DbTablePrefix + "WorkflowBacklog", WorkflowDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.Property(p => p.WorkflowInstanceId).HasComment("WorkflowInstanceId");
            b.Property(p => p.BacklogUserId).HasComment("待办人");
            b.Property(p => p.BacklogUserName).HasMaxLength(100).HasComment("待办人名称");
            b.Property(p => p.BacklogHandleTime).HasComment("办理时间");
            b.Property(p => p.BacklogResult).HasComment("办理结果");
            b.Property(p => p.BacklogRemark).HasMaxLength(200).HasComment("办理结果备注");

            b.HasIndex(p => p.WorkflowInstanceId);
            b.HasIndex(p => p.BacklogUserId);
        });
    }
}
