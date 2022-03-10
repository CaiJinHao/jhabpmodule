using Jh.Abp.Application;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
    public class WorkflowDefinitionAppService
        : CrudApplicationService<WorkflowDefinition, WorkflowDefinitionDto, WorkflowDefinitionDto, System.Guid, WorkflowDefinitionRetrieveInputDto, WorkflowDefinitionCreateInputDto, WorkflowDefinitionUpdateInputDto, WorkflowDefinitionDeleteInputDto>,
        IWorkflowDefinitionAppService
    {
        private readonly WorkflowOptions _workflowOptions;
        public const string WorkflowStepsCacheKey = "ApplicationWorkflowSteps";
        public IDistributedCache<List<WorkflowStepDto>> distributedCache { get; set; }
        private readonly IWorkflowDefinitionRepository WorkflowDefinitionRepository;
        public WorkflowDefinitionAppService(IWorkflowDefinitionRepository repository, IOptions<WorkflowOptions> workflowOptions) : base(repository)
        {
            WorkflowDefinitionRepository = repository;
            _workflowOptions = workflowOptions.Value;
        }

        public virtual async Task<List<WorkflowStepDto>> GetApplicationStepsAsync()
        {
            distributedCache.Remove(WorkflowStepsCacheKey);
            return await distributedCache.GetOrAddAsync(WorkflowStepsCacheKey, () => Task.FromResult(GetApplicationSteps()));
        }

        public virtual List<WorkflowStepDto> GetApplicationSteps()
        {
            var dataTypes = new List<Type>();
            foreach (var item in _workflowOptions.Assemblies)
            {
                dataTypes.AddRange(GetApplicationStepsByAssembly(item));
            }
            var stepDtos = new List<WorkflowStepDto>();
            foreach (var item in dataTypes)
            {
                stepDtos.Add(ConvertToWorkflowStepDto(item));
            }
            return stepDtos;
        }

        public virtual WorkflowStepDto ConvertToWorkflowStepDto(Type type)
        {
            var propertys = type.GetProperties().Where(a => a.CanWrite);
            var inputObject = new JObject();
            foreach (var item in propertys.Where(a => a.GetCustomAttribute<InputPropertyAttribute>() != null))
            {
                inputObject.Add(item.Name, $"data[\"{item.Name}\"]");
            }
            var outputObject = new JObject();
            foreach (var item in propertys.Where(a => a.GetCustomAttribute<OutputPropertyAttribute>() != null))
            {
                outputObject.Add(item.Name, $"step.{item.Name}");
            }

            var typeDescription = type.GetCustomAttribute<DescriptionAttribute>();
            var runDescription = type.GetMethod("Run").GetCustomAttribute<DescriptionAttribute>();
            return new WorkflowStepDto()
            {
                Id = type.Name,
                Name = typeDescription?.Description,
                Description = runDescription?.Description,
                ClassName = type.FullName,
                AssemblyName = type.Assembly.GetName().Name,
                Inputs = inputObject,
                Outputs = outputObject
            };
        }

        public virtual IEnumerable<Type> GetApplicationStepsByAssembly(Assembly assembly)
        {
            return assembly.GetTypes().Where(a => a.IsClass && a.IsAssignableTo(typeof(StepBody)) && a.GetCustomAttribute<NotShowStepAttribute>() == null);
        }
    }
}
