using HYR_Blog.Areas;
using HYR_Blog.CoreLayer.Dtos.OrderDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace HYR_Blog.Pages.User
{
    public class UserOrdersModel : BaseRazorModel
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;

        public UserOrdersModel(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }


        public List<ShowOrderDto> Orders { get; set; }
        public void OnGet()
        {
            int userid = Convert.ToInt32(User.Claims.Single(c=>c.Type == ClaimTypes.NameIdentifier).Value);

            MyResult<List<ShowOrderDto>> result = _scopeFacadPattern.GetAllUserOrderService.GetAllOrders(userid);
            if(result.StatusCode != StatusCodeEnum.Success)
            {
                Failed(result, "", false);
            }

            Orders = result.data;

        }
    }
}
