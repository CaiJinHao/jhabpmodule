using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jh.Abp.Workflow.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowBacklog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkflowInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "WorkflowInstanceId"),
                    BacklogUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "待办人"),
                    BacklogUserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "待办人名称"),
                    BacklogHandleTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "办理时间"),
                    BacklogResult = table.Column<int>(type: "int", nullable: false, comment: "办理结果"),
                    BacklogRemark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "办理结果备注"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowBacklog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowDefinition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false, comment: "工作流版本"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "工作流描述"),
                    JsonDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "流程JSON定义"),
                    InputData = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "流程输入数据"),
                    FormDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "流程表单定义HTML"),
                    BusinessType = table.Column<int>(type: "int", nullable: false, comment: "业务类型"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EventKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EventData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowEventSubscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkflowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    ExecutionPointerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EventKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SubscribeAsOf = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalToken = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExternalWorkerId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExternalTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowEventSubscription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowExecutionError",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkflowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutionPointerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowExecutionError", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowInstance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkflowDefinitionId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "工作流定义ID"),
                    Version = table.Column<int>(type: "int", nullable: false, comment: "实例版本"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "实例描述"),
                    Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "实例引用"),
                    NextExecution = table.Column<long>(type: "bigint", nullable: true, comment: "NextExecution"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Data"),
                    CompleteTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "CompleteTime"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "实例状态"),
                    BusinessType = table.Column<int>(type: "int", nullable: true, comment: "业务类型"),
                    BusinessDataId = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "业务数据ID"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowInstance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowScheduledCommand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommandName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecuteTime = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowScheduledCommand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowExecutionPointer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkflowInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    SleepUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersistenceData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EventKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EventPublished = table.Column<bool>(type: "bit", nullable: false),
                    EventData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    Children = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContextItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredecessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowExecutionPointer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_WorkflowExecutionPointer_Workflow_WorkflowInstance_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "Workflow_WorkflowInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowExtensionAttribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExecutionPointerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowExtensionAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_WorkflowExtensionAttribute_Workflow_WorkflowExecutionPointer_ExecutionPointerId",
                        column: x => x.ExecutionPointerId,
                        principalTable: "Workflow_WorkflowExecutionPointer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowBacklog_BacklogUserId",
                table: "Workflow_WorkflowBacklog",
                column: "BacklogUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowBacklog_WorkflowInstanceId",
                table: "Workflow_WorkflowBacklog",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowDefinition_Version",
                table: "Workflow_WorkflowDefinition",
                column: "Version");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowEvent_CreationTime",
                table: "Workflow_WorkflowEvent",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowEvent_EventName_EventKey",
                table: "Workflow_WorkflowEvent",
                columns: new[] { "EventName", "EventKey" });

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowEvent_IsProcessed",
                table: "Workflow_WorkflowEvent",
                column: "IsProcessed");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowEventSubscription_EventKey",
                table: "Workflow_WorkflowEventSubscription",
                column: "EventKey");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowEventSubscription_EventName",
                table: "Workflow_WorkflowEventSubscription",
                column: "EventName");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowExecutionPointer_WorkflowInstanceId",
                table: "Workflow_WorkflowExecutionPointer",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowExtensionAttribute_ExecutionPointerId",
                table: "Workflow_WorkflowExtensionAttribute",
                column: "ExecutionPointerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowInstance_CreationTime",
                table: "Workflow_WorkflowInstance",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowInstance_NextExecution",
                table: "Workflow_WorkflowInstance",
                column: "NextExecution");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_WorkflowInstance_WorkflowDefinitionId",
                table: "Workflow_WorkflowInstance",
                column: "WorkflowDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workflow_WorkflowBacklog");

            migrationBuilder.DropTable(
                name: "Workflow_WorkflowDefinition");

            migrationBuilder.DropTable(
                name: "Workflow_WorkflowEvent");

            migrationBuilder.DropTable(
                name: "Workflow_WorkflowEventSubscription");

            migrationBuilder.DropTable(
                name: "Workflow_WorkflowExecutionError");

            migrationBuilder.DropTable(
                name: "Workflow_WorkflowExtensionAttribute");

            migrationBuilder.DropTable(
                name: "Workflow_WorkflowScheduledCommand");

            migrationBuilder.DropTable(
                name: "Workflow_WorkflowExecutionPointer");

            migrationBuilder.DropTable(
                name: "Workflow_WorkflowInstance");
        }
    }
}
