using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jh.Abp.Workflow.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowBacklog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    WorkflowInstanceId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "WorkflowInstanceId", collation: "ascii_general_ci"),
                    BacklogUserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "待办人", collation: "ascii_general_ci"),
                    BacklogUserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "待办人名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BacklogHandleTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "办理时间"),
                    BacklogResult = table.Column<int>(type: "int", nullable: false, comment: "办理结果"),
                    BacklogRemark = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, comment: "办理结果备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowBacklog", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowDefinition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Version = table.Column<int>(type: "int", nullable: false, comment: "工作流版本"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, comment: "工作流描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JsonDefinition = table.Column<string>(type: "longtext", nullable: true, comment: "流程JSON定义")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InputData = table.Column<string>(type: "longtext", nullable: true, comment: "流程输入数据")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormDefinition = table.Column<string>(type: "longtext", nullable: true, comment: "流程表单定义HTML")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BusinessType = table.Column<int>(type: "int", nullable: false, comment: "业务类型"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowDefinition", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EventName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventKey = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventData = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsProcessed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EventTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowEvent", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowEventSubscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    WorkflowId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    ExecutionPointerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EventName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventKey = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubscribeAsOf = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SubscriptionData = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExternalToken = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExternalWorkerId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExternalTokenExpiry = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowEventSubscription", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowExecutionError",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    WorkflowId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ExecutionPointerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowExecutionError", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowInstance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    WorkflowDefinitionId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true, comment: "工作流定义ID")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<int>(type: "int", nullable: false, comment: "实例版本"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, comment: "实例描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reference = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, comment: "实例引用")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NextExecution = table.Column<long>(type: "bigint", nullable: true, comment: "NextExecution"),
                    Data = table.Column<string>(type: "longtext", nullable: true, comment: "Data")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CompleteTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "CompleteTime"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "实例状态"),
                    BusinessType = table.Column<int>(type: "int", nullable: true, comment: "业务类型"),
                    BusinessDataId = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true, comment: "业务数据ID")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowInstance", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowScheduledCommand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CommandName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecuteTime = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowScheduledCommand", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowExecutionPointer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    WorkflowInstanceId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SleepUntil = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PersistenceData = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EventName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventKey = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventPublished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EventData = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StepName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    Children = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContextItem = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PredecessorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Outcome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Scope = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowExecutionPointer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_WorkflowExecutionPointer_Workflow_WorkflowInstance_~",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "Workflow_WorkflowInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workflow_WorkflowExtensionAttribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ExecutionPointerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AttributeKey = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AttributeValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow_WorkflowExtensionAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_WorkflowExtensionAttribute_Workflow_WorkflowExecuti~",
                        column: x => x.ExecutionPointerId,
                        principalTable: "Workflow_WorkflowExecutionPointer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
