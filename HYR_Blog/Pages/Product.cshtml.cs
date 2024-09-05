using System.Security.Claims;
using HYR_Blog.Areas;
using HYR_Blog.CoreLayer.Dtos.CartDto;
using HYR_Blog.CoreLayer.Dtos.CommentDtos;
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.UIUtilities;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HYR_Blog.Pages
{
    public class ProductModel : BaseRazorModel
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        public static string? Staticslug { get; set; }

        public ProductModel(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
            //ProductDto = _scopeFacadPattern.GetSingleProductService.GetSingleProduct(Staticslug).data;
        }


        public SingleProductDto ProductDto { get; set; }
        public IActionResult OnGet(string? slug)
        {
            Staticslug = slug;
            ProductDto = _scopeFacadPattern.GetSingleProductService.GetSingleProduct(slug).data;

            if (ProductDto == null)
            {

                return RedirectToPage("index");
            }
            return Page();

        }

        public IActionResult OnPost(int ProductId,int HowCount)
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
                ProductId = ProductId
            },HowCount);

            return Content(result.StatusMessage);
        }

        public IActionResult OnPostGiveScore(IFormCollection form)
        {
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            MyResultWithoutData result = _scopeFacadPattern.CreateCommentService.CreateComment(new CreateCommentDto()
            {
                Description = form["Description"],
                ProductId = int.Parse(form["productId"]),
                UserId = int.Parse(UserId),
                Score = int.Parse(form["score"]),
                Title = form["Title"]
            });
            return Redirect("/product?slug=" + Staticslug);
        }

    }
}
