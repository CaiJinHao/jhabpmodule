using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Jh.Abp.JhIdentity.Pages;

public class IndexModel : JhIdentityPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
