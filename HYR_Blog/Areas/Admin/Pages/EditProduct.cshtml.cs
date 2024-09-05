using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.Dtos.ProductPropertyDto;
using HYR_Blog.CoreLayer.FacadPattern.FacadPattern;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using HYR_Blog.CoreLayer.Dtos.ImageProductDto;
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.Other.Directories;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.Extensions.Primitives;
using System.ComponentModel;
using HYR_Blog.CoreLayer.Services.FileManageServices;

namespace HYR_Blog.Areas.Admin.Pages
{
    public class EditProductModel : BaseAuthorizeRoleModel
    {
        public readonly List<CategoryDto> categories;
        private readonly IScopeFacadPattern _scopeFacadPattern;
        private static List<ProductPropertyDto> productPropertyDtos = new List<ProductPropertyDto>();
        private ProductDto _product;
        private static int StaticProductId;

        public EditProductModel(IScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
            categories = new List<CategoryDto>();
            categories.AddRange(_scopeFacadPattern.AllCategoryService.GetAllCategory().data);
            _product = new ProductDto();
        }
        #region BindProperties

        [BindProperty]
        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "{0} اجباری است ")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر")]
        public string ProductName { get; set; }



        [BindProperty]
        [Required(ErrorMessage = "{0} اجباری است ")]
        [MinLength(100, ErrorMessage = "حداقل 100 کاراکتر")]
        [Display(Name = "توضیحات محصول")]
        public string Description { get; set; }


        [Display(Name = "قیمت (بر اساس تومان)")]
        [BindProperty]
        [Required(ErrorMessage = "{0} اجباری است ")]
        [Range(1000, int.MaxValue)]
        public int Prise { get; set; }



        [Display(Name = "قیمت با تخفیف(اختیاری)")]
        [BindProperty]
        public int? PriseByDiscount { get; set; }



        [Display(Name = "وزن(پیشفرض 500 گرم)")]
        [BindProperty]
        [Range(100, 10000, ErrorMessage = "باید بین 100 تا 10000 گرم باشد")]
        public int? Weight { get; set; }



        [Display(Name = "پست ویژه؟")]
        [BindProperty]
        public bool IsSpecial { get; set; } = false;


        [BindProperty]
        [Display(Name = "تگ های متا(اختیاری)")]
        public string? MetaTag { get; set; }


        [BindProperty]
        [Display(Name = "عناوین مختلف(اختیاری)")]
        public string? MetaTitle { get; set; }


        [BindProperty]
        [Display(Name = "توضیح مختصر(اختیاری)")]
        public string? MetaDescription { get; set; }


        [BindProperty]
        [Display(Name = "کلمات کلیدی (اختیاری)")]
        public string? KeyWorld { get; set; }


        [BindProperty]
        [Display(Name = "محصولات مرتبط(اختیاری)")]
        public string? RelationKey { get; set; }



        [Display(Name = "اضافه کردن ویژگی ها")]
        public List<ProductPropertyDto> ProductPropertyDtos { get; set; }



        [Display(Name = "دسته بندی")]
        [BindProperty]
        [Required(ErrorMessage = "{0}اجباری است ")]

        public int CategoryId { get; set; }



        [BindProperty]
        [Display(Name = "موجودی(پیشفرض 10)")]
        public int? Inventory { get; set; }




        [Display(Name = "تصاویر")]
        [BindProperty]
        [Required(ErrorMessage = "{0}اجباری است ")]
        [MinLength(1, ErrorMessage = "لطفا حداقل یک تصویر وارد کنید")]
        public List<IFormFile> Files { get; set; }

        #endregion



        #region Properties for read
        public List<ImageProductDto> ImageProductDtos { get; set; }
        #endregion





        public void OnGet(int ProductId)
        {
            productPropertyDtos.Clear();
            MyResult<ProductDto> result = _scopeFacadPattern.GetProductService.GetProductBy(ProductId);
            _product = result.data;

            if (result.StatusCode == StatusCodeEnum.NotFound)
            {
                NotFound(result, "/admin/GetAllProduct");
                return;
            }


            CategoryId = _product.CategoryId;
            Description = _product.Description;
            ImageProductDtos = _product.Images;
            Inventory = _product.Inventory;
            IsSpecial = _product.IsSpecial;
            KeyWorld = _product.KeyWorld;
            MetaDescription = _product.MetaDescription;
            MetaTag = _product.MetaTag;
            MetaTitle = _product.MetaTitle;
            Prise = _product.Prise;
            PriseByDiscount = _product.PriseByDiscount;
            RelationKey = _product.RelationKey;
            Weight = _product.Weight;
            ProductName = _product.ProductName;
            StaticProductId = ProductId;

            TempData["productId"] = ProductId;
        }


        public IActionResult OnPost()
        {
            MyResultWithoutData result = _scopeFacadPattern.EditProductService.EditProduct(new EditProductDto()
            {
                CategoryId = CategoryId,
                Description = Description,
                Inventory = Inventory,
                IsSpecial = IsSpecial,
                KeyWorld = KeyWorld,
                MetaDescription = MetaDescription,
                MetaTag = MetaTag,
                MetaTitle = MetaTitle,
                ProductName = ProductName,
                Prise = Prise,
                PriseByDiscount = PriseByDiscount == 0 ?Prise: PriseByDiscount,
                RelationKey = RelationKey,
                Weight = Weight,
                ProductId = StaticProductId
            });

            if (result.StatusCode == StatusCodeEnum.Failed)
                return Failed(result, Page());
            if (result.StatusCode == StatusCodeEnum.NotFound)
                return NotFound(result, RedirectToPage("GetAllProduct"));

            return RedirectToPage("GetAllProduct");
        }

        public IActionResult OnPostAddProperty(ProductPropertyDto propertyDto)
        {
            MyResultWithoutData result = _scopeFacadPattern.CreateProductPropertyService.CreateProperty(propertyDto);
            return new JsonResult(result);
        }

        public IActionResult OnPostDeleteProductProperty(int propertyId)
        {
            if (_scopeFacadPattern.GetProductPropertyCountService.ProductPropertyCount(StaticProductId).data < 3)
            {
                return new JsonResult(new MyResultWithoutData()
                {
                    StatusMessage = "محصول نمی تواند کمتر از دو ویژگی داشته باشد",
                    BeReload = false,
                    RedirectUrlForAfter = null,
                    StatusCode = StatusCodeEnum.Failed,
                    Title = "ناموفق"
                });

            }

            MyResultWithoutData result = _scopeFacadPattern.DeleteProductPropertyService.DeleteProperty(propertyId);

            return new JsonResult(result);
        }

        public IActionResult OnGetShowProductProperty()
        {
            return new JsonResult(_scopeFacadPattern.GetProductPropertyService.GetProductPropertyBy(StaticProductId).data);
        }


        public IActionResult OnPostRemoveImage(int imageId)
        {

            if (_scopeFacadPattern.GetProductImageCountService.ProductImageCount(StaticProductId).data < 2)
            {

                return new JsonResult(new MyResultWithoutData()
                {
                    StatusMessage = "تصاویر نمیتواند خالی باشد",
                    BeReload = false,
                    RedirectUrlForAfter = null,
                    StatusCode = StatusCodeEnum.Failed,
                    Title = "ناموفق"

                });
            }
            MyResultWithoutData result = _scopeFacadPattern.DeleteImageService.DeleteImage(imageId);
            return new JsonResult(result);
        }

        public IActionResult OnGetShowImages()
        {
            MyResult<List<ImageProductDto>> result =
                _scopeFacadPattern.GetProductImagesService.GetProductImagesBy(StaticProductId);

            foreach (var VARIABLE in result.data)
            {
                VARIABLE.ImageName = FileManage.GetProductImageByName(VARIABLE.ImageName);
            }
            return new JsonResult(result.data);
        }


        public IActionResult OnPostAddImage(List<IFormFile> files)
        {
            MyResultWithoutData result = new MyResultWithoutData();
            foreach (var VARIABLE in files)
            {
                var res = _scopeFacadPattern.AddProductImageService.AddProductImage(new CreateProductImageDto()
                {
                    ProductId = StaticProductId,
                    File = VARIABLE
                });

                result = res;
            }

            return new JsonResult(result);
        }


    }
}
