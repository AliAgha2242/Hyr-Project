using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using  HYR_Blog.CoreLayer.Dtos.DiscountDto;

namespace HYR_Blog.Areas.Admin.Pages
{
    public class CreateDiscountModel : BaseAuthorizeRoleModel
    {
        private readonly IScopeFacadPattern _scopeFacadPattern;
        public CreateDiscountModel(IScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }



        [Display(Name ="کد تخفیف")]
        [Required(ErrorMessage ="{0} اجباری است")]
        [BindProperty]
        public string DisCountCodeText { get; set; }
        [BindProperty]
        [Display(Name ="تاریخ شروع")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [BindProperty]
        [Display(Name ="مدت اعتبار(به روز)")]
        public byte LifeTimeDay { get; set; } = 1 ;
        [BindProperty]
        [Display(Name ="دفعات مجاز استفاده")]
        public byte UseCountAllowed { get; set; } = 1;
        [BindProperty]
        [Display(Name ="مقدار تخفیف(به تومان)")]
        [Required(ErrorMessage ="{0} اجباری است")]
        public int DisCountAmount { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
             MyResultWithoutData result = _scopeFacadPattern.CreateDiscountService.CreateDiscount(new CreateDiscountDto()
             {
                 DisCountAmount = DisCountAmount,
                 StartDate = StartDate,
                 DisCountCodeText = DisCountCodeText,
                 LifeTimeDay = LifeTimeDay,
                 UseCountAllowed = UseCountAllowed
             });
            if (result.StatusCode == StatusCodeEnum.Failed)
            {
                return Failed(result,Page());
            }
            return Success(result , RedirectToPage("Discounts"));
        }

        public IActionResult OnPostDiscountCodeGenerate()
        {
            return new JsonResult(DiscountCodeGenerate.GenerateCode());
        }
    }
}
