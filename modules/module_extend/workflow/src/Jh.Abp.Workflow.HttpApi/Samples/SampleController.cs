using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Jh.Abp.Workflow.Samples;

[Area(WorkflowRemoteServiceConsts.ModuleName)]
[RemoteService(Name = WorkflowRemoteServiceConsts.RemoteServiceName)]
[Route("api/Workflow/sample")]
public class SampleController : WorkflowController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;
    protected Volo.Abp.Identity.IdentityUserManager identityUserManager => LazyServiceProvider.LazyGetRequiredService<Volo.Abp.Identity.IdentityUserManager>();

    public SampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        var data= await identityUserManager.GetByIdAsync(new System.Guid("3a02751d-396f-d768-9f76-ab89edf150d4"));
        return await _sampleAppService.GetAsync();
    }
}
