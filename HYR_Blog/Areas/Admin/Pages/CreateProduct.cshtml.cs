using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Dtos.ProductPropertyDto;
using HYR_Blog.CoreLayer.FacadPattern.FacadPattern;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HYR_Blog.Areas.Admin.Pages
{
    public class CreateProductModel : BaseAuthorizeRoleModel
    {

        public readonly List<CategoryDto> categories;
        private readonly IScopeFacadPattern _scopeFacadPattern;
        private static List<ProductPropertyDto> productPropertyDtos = new List<ProductPropertyDto>();

        public CreateProductModel(IScopeFacadPattern scopeFacadPattern  )
        {
            _scopeFacadPattern = scopeFacadPattern;
            categories = new List<CategoryDto>();
            categories.AddRange(_scopeFacadPattern.AllCategoryService.GetAllCategory().data);


        }

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
        public int? PriseByDiscount { get; set; }

        [Display(Name = "وزن(پیشفرض 500 گرم)")]
        [BindProperty]
        [Range(100, 10000, ErrorMessage = "باید بین 100 تا 10000 گرم باشد")]
        public int? Weight { get; set; } = 500 ;

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

        [Display(Name = "انتخاب تصویر")]
        [BindProperty]
        [Required(ErrorMessage = "{0}اجباری است ")]
        [MinLength(1, ErrorMessage = "لطفا حداقل یک تصویر وارد کنید")]
        public List<IFormFile> Files { get; set; }

        public void OnGet()
        {
            ProductPropertyDtos?.Clear();
        }

        public IActionResult OnPost()
        {

            //static Product Map To ProductPropertyDto ;

           this.FillProductPropertyDto();


            if (!ModelState.IsValid)
                return Page();
            MyResultWithoutData result = _scopeFacadPattern.CreateProductService.CreateProduct(new CreateProductDto()
            {
                CategoryId = CategoryId,
                Inventory = Inventory,
                IsSpecial = IsSpecial,
                MetaDescription = MetaDescription,
                KeyWorld = KeyWorld,
                Files = Files,
                Description = Description,
                Prise = Prise,
                PriseByDiscount = PriseByDiscount == 0 ? null : PriseByDiscount,
                Weight = Weight,
                MetaTitle = MetaTitle,
                MetaTag = MetaTag,
                RelationKey = RelationKey,
                ProductName = ProductName,
                ProductPropertyDtos = ProductPropertyDtos

            });
            if (result.StatusCode == StatusCodeEnum.Duplicate)
                return Duplicate(result, Page());

            
            return Success(result, RedirectToPage("CreateProduct"));
        }

        public void OnPostCreateProductProperty(string key, string value)
        {
            if(string.IsNullOrWhiteSpace(key)){
                ModelState.AddModelError("ProductName","نام ویژگی نمیتواند خالی باشد");
                return;
                }

             if(string.IsNullOrWhiteSpace(value)){
                ModelState.AddModelError("ProductName","مقدار ویژگی نمیتواند خالی باشد");
                return ;
            }




            productPropertyDtos.Add(new ProductPropertyDto()
            {
                Key = key,
                Value = value
            });
        }


        private void FillProductPropertyDto()
        {
            ProductPropertyDtos = new List<ProductPropertyDto>();
            foreach (var item in productPropertyDtos)
            {
                ProductPropertyDtos.Add((new ProductPropertyDto()
                {
                    Key = item.Key,
                    Value = item.Value
                }));
            }
        }

    }
}
