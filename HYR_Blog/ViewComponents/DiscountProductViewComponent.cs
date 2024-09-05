using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HYR_Blog.ViewComponents
{
    public class DiscountProductViewComponent:ViewComponent
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        public DiscountProductViewComponent(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }
        public IViewComponentResult Invoke()
        {
            return View("_DiscountProduct",model:_scopeFacadPattern.GetProductByDiscountService.GetProductByDiscount().data);
        }
    }
}
