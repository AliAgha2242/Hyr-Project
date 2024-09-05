using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HYR_Blog.Areas.Admin.Pages
{
    [BindProperties]
    public class GetAllCategoryModel : BaseAuthorizeRoleModel
    {
        public List<CategoryDto> categoriesModel { get; set; }
        private readonly IScopeFacadPattern _scopeFacadPattern;

        public GetAllCategoryModel(IScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }

        public void OnGet()
        {
            MyResult<List<CategoryDto>> categories = _scopeFacadPattern.AllCategoryService.GetAllCategory();
            categoriesModel = categories.data;
        }


        
        public IActionResult OnPostDeleteCategory(int CategoryId)
        {
            MyResultWithoutData result = _scopeFacadPattern.DeleteCategoryService.DeleteCategory(CategoryId);
            return new JsonResult(result);
        }

        public IActionResult OnPostEditCategory(CategoryDto editCategory)
        {
            MyResultWithoutData result = _scopeFacadPattern.EditCategoryService.EditCategory(editCategory);

            return new JsonResult(result);
                
        }
    }
}
