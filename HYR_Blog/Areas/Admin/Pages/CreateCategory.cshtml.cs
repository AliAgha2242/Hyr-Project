using System.ComponentModel.DataAnnotations;
using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HYR_Blog.Areas.Admin.Pages
{
    //[Authorize(Roles = "Admin")]
    [BindProperties]
    public class CreateCategoryModel : BaseAuthorizeRoleModel
    {
        private readonly IScopeFacadPattern FacadPattern;
  

        public CreateCategoryModel(IScopeFacadPattern facadPattern)
        {
            FacadPattern = facadPattern;
        }

        //Model

        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "{0}الزامی است")]
        [MaxLength(40)]
        public string CategoryName { get; set; }
        [Display(Name = "متا تگ ها (اختیاری)")]
        public string? MetaTag { get; set; }
        [Display(Name = "توضیحات مختصر از دسته بندی (اختیاری)")]
        public string? MetaDescription { get; set; }
        [Display(Name = "کلمات کلیدی(اختیاری)")]
        public string? KeyWorld { get; set; }


        public void OnGet()
        {
            
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = FacadPattern.CreateCategoryService.CreateCategory(new CreateCategoryDto()
            {
                CategoryName = CategoryName,
                MetaDescription = MetaDescription,
                KeyWorld = KeyWorld,
                MetaTag = MetaTag
            });
            if (result.StatusCode == StatusCodeEnum.Failed)
            {
                return Failed(result, Page());
            }
            return Success(result , RedirectToPage("GetAllCategory"));
        }
    }
}
