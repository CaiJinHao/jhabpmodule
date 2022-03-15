using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.Workflow.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.VirtualFileSystem;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Services.DefinitionStorage;

namespace Jh.Abp.Workflow
{
    public class WorkflowDefinitionRepository : CrudRepository<WorkflowDbContext, WorkflowDefinition, System.Guid>, IWorkflowDefinitionRepository
    {
        /// <summary>
        /// 工作流通用数据传输类型
        /// </summary>
        private string WorkflowDataType { get; set; }
        protected IDefinitionLoader DefinitionLoader => LazyServiceProvider.LazyGetRequiredService<IDefinitionLoader>();
        protected IVirtualFileProvider VirtualFileProvider => LazyServiceProvider.LazyGetRequiredService<IVirtualFileProvider>();
        public WorkflowDefinitionRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
        {
            var _workflowDataType = typeof(WorkflowDynamicData);
            var _assemblyName = _workflowDataType.Assembly.GetName().Name;
            WorkflowDataType = $"{_workflowDataType.FullName},{_assemblyName}";
        }

        public override async Task<WorkflowDefinition> CreateAsync(WorkflowDefinition entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var data = await base.CreateAsync(entity, autoSave, cancellationToken);
            await LoadWorkflowDefinitionAsync(data);
            return data;
        }

        public async Task LoadWorkflowDefinitionByIdAsync(Guid id)
        {
            var data = await GetAsync(id);
            await LoadWorkflowDefinitionAsync(data);
        }

        public async Task LoadWorkflowDefinitionAllAsync()
        {
            var datas = await GetListAsync();
            foreach (var data in datas)
            {
               await LoadWorkflowDefinitionAsync(data);
            }
        }

        public virtual async Task<WorkflowCore.Models.WorkflowDefinition> LoadWorkflowDefinitionByFileAsync(string virtualFilePath)
        {
            var file= VirtualFileProvider.GetFileInfo(virtualFilePath);
            var workflowDefinitionJson = await file.ReadAsStringAsync();
            return DefinitionLoader.LoadDefinition(workflowDefinitionJson, Deserializers.Json);
        }

        public virtual Task<WorkflowCore.Models.WorkflowDefinition> LoadWorkflowDefinitionAsync(WorkflowDefinition data)
        {
            var steps = JsonConvert.DeserializeObject<dynamic>(data.JsonDefinition);
            var workflowDefinition = new
            {
                data.Id,
                data.Version,
                data.Description,
                Steps = steps,
                DataType = WorkflowDataType,
                DefaultErrorBehavior = WorkflowErrorHandling.Compensate
            };
            var def= DefinitionLoader.LoadDefinition(JsonConvert.SerializeObject(workflowDefinition), Deserializers.Json);
            return Task.FromResult(def);
        }
    }
}