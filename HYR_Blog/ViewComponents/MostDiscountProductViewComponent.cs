using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace HYR_Blog.ViewComponents
{
    public class MostDiscountProductViewComponent:ViewComponent
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        public MostDiscountProductViewComponent(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }
        public IViewComponentResult Invoke()
        {
            
            return View("_MostDiscountProduct",_scopeFacadPattern.GetMostDiscountProductService.GetMostDiscountProduct().data);
        }
    }
}
