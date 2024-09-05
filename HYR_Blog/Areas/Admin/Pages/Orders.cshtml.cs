using HYR_Blog.CoreLayer.Dtos.OrderDto;
using HYR_Blog.CoreLayer.Dtos.OrderStatusDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HYR_Blog.Areas.Admin.Pages
{
    public class OrdersModel : BaseAuthorizeRoleModel
    {
        private readonly IScopeFacadPattern _scopeFacadPattern;
        public OrdersModel(IScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }

        public List<ShowOrderDto> Orders { get; set; }
        public void OnGet()
        {
            MyResult<List<ShowOrderDto>> result = _scopeFacadPattern.GetAllOrderService.GetAllOrders();
            if (result.StatusCode != StatusCodeEnum.Success)
            {
                Failed(result, "", false);
            }

            Orders = result.data;
        }
        public IActionResult OnPostGetNextStatus(int priority)
        {
            MyResult<OrderStatusDto> result = _scopeFacadPattern.GetNextOrderStatusService.GetNextStatus(priority);
            if (result.StatusCode == StatusCodeEnum.Failed)
                return Failed(result, RedirectToPage("Orders"));

            return new JsonResult(result.data);
        }

        public IActionResult OnPostChangeOrderStatus(int priority , string? sendCode , int OrderId)
        {
            
            MyResultWithoutData result = _scopeFacadPattern.chengeOrderStatusService.ChangeOrderStatus(priority , OrderId , sendCode);
           return new JsonResult(result);

        }
    }
}
