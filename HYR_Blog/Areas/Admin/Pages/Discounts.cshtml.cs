using HYR_Blog.CoreLayer.Dtos.DiscountDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Utilities.FilterResult;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HYR_Blog.Areas.Admin.Pages
{
    public class DiscountsModel : BaseAuthorizeRoleModel
    {
        private readonly IScopeFacadPattern _scopeFacadPattern;
        public DiscountsModel(IScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }
        public List<DiscountDto> DiscountDtos { get; set; }
        public void OnGet(string? discountCode,bool? IsActive)
        {
            MyResult<List<DiscountDto>> result = _scopeFacadPattern.GetAllDiscountCodeService.GetAllDiscount(new FilterResult()
            {
                IsActive = IsActive,
                Name = discountCode
            });
            DiscountDtos = result.data;
        }
    }
}
