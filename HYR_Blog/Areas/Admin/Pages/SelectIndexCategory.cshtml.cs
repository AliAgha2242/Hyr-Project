using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;


namespace HYR_Blog.Areas.Admin.Pages
{
    public class SelectIndexCategoryModel : BaseAuthorizeRoleModel
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        public SelectIndexCategoryModel(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }
        public List<IndexCategoryDto> indexCategoryDtos { get; set; }
        public void OnGet()
        {
            indexCategoryDtos = _scopeFacadPattern.GetIndexCategoryService.GetCategory().data;
        }

        public void OnPost(List<int> categoriesId)
        {
            indexCategoryDtos = _scopeFacadPattern.GetIndexCategoryService.GetCategory().data;

            MyResultWithoutData result = _scopeFacadPattern.UpdateSpecialCategoryService.UpdateCategorySpecial(categoriesId);
            if(result.StatusCode == StatusCodeEnum.NotFound)
            {
                NotFound(result);
            }
            Success(result,RedirectUrlForAfter:"/");
        }
    }
}
