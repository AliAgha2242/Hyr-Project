using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace HYR_Blog.ViewComponents
{
    public class SearchIndexViewComponent:ViewComponent
    {
        private IUiScopeFacadPattern _scopeFacadPattern;
        public SearchIndexViewComponent(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }
        public IViewComponentResult Invoke()
        {
            return View("_SearchIndex" , _scopeFacadPattern.GetIndexCategoryService.GetCategory().data);
        }
    }
}
