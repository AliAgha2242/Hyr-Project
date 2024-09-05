using HYR_Blog.Areas;
using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Services.ProductServices.Queries;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace HYR_Blog.Pages
{
    [AutoValidateAntiforgeryToken]


    public class IndexModel : BaseRazorModel
    {

        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        public IndexModel(IUiScopeFacadPattern scopeFacadPattern, HyrDbContext hyr)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }



        public List<IndexCategoryDto> categoryDtos { get; set; }

        public void OnGet()
        {
            categoryDtos = _scopeFacadPattern.GetIndexCategoryService.GetCategory().data.Where(c => c.IsSpecial == true).ToList();
        }

        public IActionResult OnPostGetOrUpdateCart()
        {
            OutUserIdAndCookieValue("HyrCart", out int? UserId, out string? CookieValue);
            var model = _scopeFacadPattern.GetCartAndCartItemService.GetCart(CookieValue, UserId).data;
            return Partial("_Cart", model: model);
        }



        public IActionResult OnPostRemoveCartItem(int CartItemId)
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

        private void OutUserIdAndCookieValue(string CookieName, out int? UserId, out string? CookieValue)
        {

            if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier) != null)
                UserId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            else
                UserId = null;

            string? CartCodeCookie = Request.Cookies[CookieName];

            CookieValue = CartCodeCookie;
        }


    }
}
