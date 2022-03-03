using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Jh.Abp.JhPermission.Pages;

public class IndexModel : JhPermissionPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
