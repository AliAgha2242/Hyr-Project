using HYR_Blog.CoreLayer.Dtos.CartDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace HYR_Blog.Pages
{
    public class CartDetailModel : PageModel
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        public CartDetailModel(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;

        }



        public void OnGet()
        {
            //OutUserIdAndCookieValue("HyrCart", out int? UserId, out string? CookieValue);

            //MyResult<CartDetailDto> result = _scopeFacadPattern.GetCartDetailService.GetCartDetail(UserId, CookieValue);
            //CartDetailDto = result.data;
            //TotalPrise = result.data.TotalPrise;
        }

        public IActionResult OnPostRemoveItems(int CartItemId)
        {
            OutUserIdAndCookieValue("HyrCart", out int? UserId, out string? CookieValue);
            MyResultWithoutData result = _scopeFacadPattern.RemoveAllCartItemInCartService
                .RemoveAllCartItem(CookieValue, UserId, CartItemId);
            if (result.StatusCode == StatusCodeEnum.NotFound)
            {
                return NotFound();
            }
            return new EmptyResult();
        }
        public PartialViewResult OnPostGetCartItems()
        {
            OutUserIdAndCookieValue("HyrCart", out int? UserId, out string? CookieValue);

            MyResult<List<CartItemDetailDto>> result = _scopeFacadPattern.GetCartItemDetailService.GetCartItemDetail(UserId, CookieValue);
            return Partial("_CartItemInCartDetial", result.data);
        }


        public JsonResult OnPostAddCartItemInCart(int ProductId)
        {
            OutUserIdAndCookieValue("HyrCart", out int? UserId, out string? CookieValue);

            MyResultWithoutData result = _scopeFacadPattern.AddCartItemInCartService.AddCart(UserId, CookieValue, ProductId);
            return new JsonResult(result.StatusCode);
        }



        public JsonResult OnPostRemoveOneCartItemFromCart(int ProductId)
        {
            OutUserIdAndCookieValue("HyrCart", out int? UserId, out string? CookieValue);

            MyResultWithoutData result = _scopeFacadPattern.RemoveCartItemFromCartService.RemoveCartItem(UserId, CookieValue, ProductId);

            return new JsonResult(result.StatusCode);
        }

        public PartialViewResult OnPostGetCartTranportation()
        {
            OutUserIdAndCookieValue("HyrCart", out int? UserId, out string? CookieValue);

            MyResult<CartDetailDto> result = _scopeFacadPattern.GetCartDetailIncludeTransportationService.
                GetCartDetailIncludeTransportation(UserId, CookieValue);
            return Partial("_TotalCartDetailInCart", model: result.data);
        }



        public IActionResult OnPostUpdateTotalPriseWith(string? DiscountText, int TransportationId)
        {
            OutUserIdAndCookieValue("HyrCart", out int? UserId, out string? CookieValue);

            MyResult<UpdateCartDetailDto> result =
                _scopeFacadPattern.UpdateCartDetailTotalPriseService.
                UpdateCartDetailTotalPrise(new UpdateCartDetailDto()
                {
                    CartCode = CookieValue,
                    DiscountCode = DiscountText,
                    UserId = UserId,
                    TransportationId = TransportationId,
                });
            var datapost = new
            {
                StatusCode = result.StatusCode,
                data = result.data.TotalPriseWithTransportationPriseAndDiscount.ToString("n0"),
                StatusMessage = result.StatusMessage
            };
            return new JsonResult(datapost);

        }

        private void OutUserIdAndCookieValue(string CookieName, out int? UserId, out string? CookieValue)
        {
            int? UserIdResult = null;


            if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier) != null)
                UserIdResult = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);


            string? CartCodeCookie = Request.Cookies[CookieName];

            UserId = UserIdResult;
            CookieValue = CartCodeCookie;
        }

    }
}
