using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HYR_Blog.ViewComponents
{
    public class CategoryIndexViewComponent:ViewComponent
    {
        private readonly IUiScopeFacadPattern _facetPattern;
        public CategoryIndexViewComponent(IUiScopeFacadPattern facadPattern)
        {
            _facetPattern = facadPattern;
        }
        public IViewComponentResult Invoke()
        {
            return View("_CategoryIndex",_facetPattern.GetIndexCategoryService.GetCategory().data);
        }
    }
}
