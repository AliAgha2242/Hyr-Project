using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Utilities;
using HYR_Blog.CoreLayer.Utilities.FilterResult;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HYR_Blog.Areas.Admin.Pages
{
    public class GetAllProductModel : BaseAuthorizeRoleModel
    {
        private readonly IScopeFacadPattern _scopeFacadPattern;

        public GetAllProductModel(IScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
            Products = new List<ShortProductDto>();
        }
        public List<ShortProductDto> Products { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty] public string? ProductName { get; set; }

        [BindProperty]
        public int? CategoryId { get; set; }
        

        public void OnGet(int? CategoryId , int? Prise , string? ProductName)
        {
           

            Categories = new SelectList(_scopeFacadPattern.AllCategoryService.GetAllCategory().data,
                dataTextField:"CategoryName",dataValueField:"CategoryId");

            MyResult<List<ShortProductDto>> result = _scopeFacadPattern.ShortGetAllProduct
                .GetAllProduct(CategoryId,Prise,ProductName);


            if (result.StatusCode == StatusCodeEnum.NotFound)
                NotFound(result);

            Products = result.data;
        }

        public IActionResult OnPost()
        {
             Categories = new SelectList(_scopeFacadPattern.AllCategoryService.GetAllCategory().data,
                dataTextField:"CategoryName",dataValueField:"CategoryId");

            MyResult<List<ShortProductDto>> result = _scopeFacadPattern.ShortGetAllProduct.GetAllProduct();
            if (result.StatusCode == StatusCodeEnum.NotFound)
                return NotFound(result, RedirectToPage("CreateProduct"));

            Products = result.data;
            return Page();
        }


        public IActionResult OnPostDeleteProduct(int productId)
        {
             Categories = new SelectList(_scopeFacadPattern.AllCategoryService.GetAllCategory().data,
                dataTextField:"CategoryName",dataValueField:"CategoryId");

            MyResultWithoutData result = _scopeFacadPattern.DeleteProductService.DeleteProduct(productId);

            if (result.StatusCode == StatusCodeEnum.NotFound)
                return NotFound(result, Page());

            return Success(result, Page());
        }
    }
}
