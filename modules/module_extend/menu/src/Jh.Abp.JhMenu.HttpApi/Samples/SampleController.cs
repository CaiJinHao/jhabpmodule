using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Jh.Abp.JhMenu.Samples;

[Area(JhMenuRemoteServiceConsts.ModuleName)]
[RemoteService(Name = JhMenuRemoteServiceConsts.RemoteServiceName)]
[Route("api/JhMenu/sample")]
public class SampleController : JhMenuController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

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
}
