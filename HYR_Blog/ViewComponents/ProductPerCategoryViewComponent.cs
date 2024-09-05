using HYR_Blog.CoreLayer.FacadPattern.FacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace HYR_Blog.ViewComponents
{
    public class ProductPerCategoryViewComponent:ViewComponent
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        public ProductPerCategoryViewComponent(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }
        public IViewComponentResult Invoke(int categoryId)
        {
            return View("_ProductPerCategory",model:_scopeFacadPattern.GetNewesProductByCatIdService.GetNewestProductBy(categoryId).data);
        }
    }
}
