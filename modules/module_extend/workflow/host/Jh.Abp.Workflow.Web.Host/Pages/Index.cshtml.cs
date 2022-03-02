using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Jh.Abp.Workflow.Pages;

public class IndexModel : WorkflowPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
