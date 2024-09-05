﻿using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using Microsoft.AspNetCore.Mvc;

namespace HYR_Blog.ViewComponents
{
    public class ProductCategoryFirstViewComponent:ViewComponent
    {
        private readonly IUiScopeFacadPattern _scopeFacadPattern;
        public ProductCategoryFirstViewComponent(IUiScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }
        public IViewComponentResult Invoke(int categoryId)
        {
            return View("_ProductCategoryFirst",model:_scopeFacadPattern.GetNewesProductByCatIdService.GetNewestProductBy(categoryId).data);
        }
    }
}