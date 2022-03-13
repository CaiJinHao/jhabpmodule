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
        private string workflowDataType { get; set; }
        protected IDefinitionLoader definitionLoader => LazyServiceProvider.LazyGetRequiredService<IDefinitionLoader>();
        protected IVirtualFileProvider virtualFileProvider => LazyServiceProvider.LazyGetRequiredService<IVirtualFileProvider>();
        public WorkflowDefinitionRepository(IDbContextProvider<WorkflowDbContext> dbContextProvider) : base(dbContextProvider)
        {
            var _workflowDataType = typeof(WorkflowDynamicData);
            var _assemblyName = _workflowDataType.Assembly.GetName().Name;
            workflowDataType = $"{_workflowDataType.FullName},{_assemblyName}";
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
            var file= virtualFileProvider.GetFileInfo(virtualFilePath);
            var workflowDefinitionJson = await file.ReadAsStringAsync();
            return definitionLoader.LoadDefinition(workflowDefinitionJson, Deserializers.Json);
        }

        public virtual Task<WorkflowCore.Models.WorkflowDefinition> LoadWorkflowDefinitionAsync(WorkflowDefinition data)
        {
            var steps = JsonConvert.DeserializeObject<dynamic>(data.JsonDefinition);
            var workflowDefinition = new
            {
                Id = data.Id,
                Version = data.Version,
                Description = data.Description,
                Steps = steps,
                DataType = workflowDataType,
                DefaultErrorBehavior = WorkflowErrorHandling.Compensate
            };
            var def= definitionLoader.LoadDefinition(JsonConvert.SerializeObject(workflowDefinition), Deserializers.Json);
            return Task.FromResult(def);
        }
    }
}