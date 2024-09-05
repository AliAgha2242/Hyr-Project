using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HYR_Blog.Areas.Admin.Pages
{

    public class IndexModel : BaseAuthorizeRoleModel
    {
        public void OnGet()
        {
           
        }
    }
}
