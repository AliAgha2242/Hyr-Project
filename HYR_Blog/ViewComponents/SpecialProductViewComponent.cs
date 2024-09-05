using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace HYR_Blog.ViewComponents
{
    public class SpecialProductViewComponent : ViewComponent
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        public SpecialProductViewComponent(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }
        public IViewComponentResult Invoke()
        {
            return View("_SpecialProduct",_scopeFacadPattern.GetProductIsSpecialService.GetProductIsSpecial().data);
        }
    }
}
