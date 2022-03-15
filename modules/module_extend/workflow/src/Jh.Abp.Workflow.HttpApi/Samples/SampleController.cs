using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Volo.Abp;
using Volo.Abp.VirtualFileSystem;

namespace Jh.Abp.Workflow.Samples;

[Area(WorkflowRemoteServiceConsts.ModuleName)]
[RemoteService(Name = WorkflowRemoteServiceConsts.RemoteServiceName)]
[Route("api/Workflow/sample")]
public class SampleController : WorkflowController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;
    protected IWorkflowDefinitionRepository  WorkflowDefinitionRepository=>LazyServiceProvider.LazyGetRequiredService<IWorkflowDefinitionRepository>();
    protected IVirtualFileProvider VirtualFileProvider => LazyServiceProvider.LazyGetRequiredService<IVirtualFileProvider>();

    public SampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet("Claims")]
    [Authorize]
    public dynamic GetAllClaims()
    {
        var u = CurrentUser;
        var t = CurrentTenant;
        var data = CurrentUser.GetAllClaims().Select(a => new { a.Value, a.ValueType, a.Type }).ToList();
        return data;
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        var virtualFilePath = "/Localization/WorkflowDefinitions/LeaveApprovalWorkflow.json";
        //var virtualFilePath = "/Jh/Abp/Workflow/Domain/Shared/Localization/Workflow/zh-Hans.json";
        var d = VirtualFileProvider.GetDirectoryContents("/Localization/WorkflowDefinitions");
        var file = VirtualFileProvider.GetFileInfo(virtualFilePath);
        var workflowDefinition = await file.ReadAsStringAsync();
        return await _sampleAppService.GetAsync();
    }
}
