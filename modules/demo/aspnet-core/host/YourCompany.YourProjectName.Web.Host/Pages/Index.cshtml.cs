using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace YourCompany.YourProjectName.Pages;

public class IndexModel : YourProjectNamePageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
