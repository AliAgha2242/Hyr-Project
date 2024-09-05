using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HYR_Blog.Areas.Admin
{
    [Authorize(policy: "AdminPolicy")]
    public class BaseAuthorizeRoleModel : BaseRazorModel
    {
    }
}
