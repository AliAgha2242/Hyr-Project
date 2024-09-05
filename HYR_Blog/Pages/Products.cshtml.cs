using HYR_Blog.CoreLayer.Dtos.CartDto;
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.UIUtilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace HYR_Blog.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;

        public ProductsModel(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }

        public SearchProductResultDto Products { get; set; }
        public void OnGet(string? ProductName, int? CategoryId , int? OrderBy , int pageId = 1)
        {
            MyResult<SearchProductResultDto> result = _scopeFacadPattern.GetProductsByFilterService.GetProductByFilter(new FilterParams()
            {
                CategoryId = CategoryId,
                Ordering = OrderBy,
                PageId = pageId,
                Productname = ProductName
            });
            Products = result.data ;
        }




        public IActionResult OnPost(int productId)
        {

            int? userid = User.Identity.IsAuthenticated ? int.Parse(User.Claims.First(p => p.Type
            == ClaimTypes.NameIdentifier).Value) : null;

            string CartCode = Request.Cookies.FirstOrDefault(c => c.Key == "HyrCart").Value;

            if (CartCode == null && userid == null)
            {
                CartCode = Guid.NewGuid().ToString();
                CookieManager.AddCookie(HttpContext, "HyrCart", CartCode);
            }

            MyResultWithoutData result = _scopeFacadPattern.CreateCartService.CreateCart(userid, CartCode, new CartItemDto()
            {
                IsDelete = false,
                ProductId = productId
            }, 1);

            return Content(result.StatusMessage);

        }
    }
}
