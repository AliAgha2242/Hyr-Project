using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.CoreLayer.Services.CategoryServices.Commands;
using HYR_Blog.CoreLayer.Services.CategoryServices.Queries;
using HYR_Blog.CoreLayer.Services.DisCountService.Command;
using HYR_Blog.CoreLayer.Services.DisCountService.Queries;
using HYR_Blog.CoreLayer.Services.FileManageServices;
using HYR_Blog.CoreLayer.Services.OrderService;
using HYR_Blog.CoreLayer.Services.OrderService.Queries;
using HYR_Blog.CoreLayer.Services.OrderStatusServices.Commands;
using HYR_Blog.CoreLayer.Services.ProductImageService.Commands;
using HYR_Blog.CoreLayer.Services.ProductImageService.Queries;
using HYR_Blog.CoreLayer.Services.ProductPropertyServices.Commands;
using HYR_Blog.CoreLayer.Services.ProductPropertyServices.Queries;
using HYR_Blog.CoreLayer.Services.ProductServices.Commands;
using HYR_Blog.CoreLayer.Services.ProductServices.Queries;
using HYR_Blog.CoreLayer.Services.UserRolesService;
using HYR_Blog.CoreLayer.Services.UserService.Commands;
using HYR_Blog.CoreLayer.Services.UserService.Queries;

namespace HYR_Blog.CoreLayer.FacadPattern.IFacadPattern
{
    public interface IScopeFacadPattern
    {
        ICreateCategoryService CreateCategoryService { get; }
        IGetAllCategoryService AllCategoryService { get; }
        IDeleteCategoryService DeleteCategoryService { get; }
        IEditCategoryService EditCategoryService { get; }
        //IFileManageService FileManageService { get; }
        ICreateProductService CreateProductService { get; }
        IGetAllProductPropertyService GetAllProductPropertyService { get; }
        IShortGetAllProduct ShortGetAllProduct { get; }
        IDeleteProductService DeleteProductService { get; }
        IGetProductService GetProductService { get; }
        IEditProductService EditProductService { get; }
        IGetProductPropertyService GetProductPropertyService { get; }
        ICreateProductPropertyService CreateProductPropertyService { get; }

        IDeleteProductPropertyService DeleteProductPropertyService { get; }
        IDeleteImageService DeleteImageService { get; }
        IGetProductImagesService GetProductImagesService { get; }
        IAddProductImageService AddProductImageService { get; }

        IGetProductPropertyCountService GetProductPropertyCountService { get; }
        IGetProductImageCountService GetProductImageCountService { get; }
        IGetAllOrderService GetAllOrderService { get; }
        IChangeOrderStatusService chengeOrderStatusService { get; }
        IGetNextOrderStatusService GetNextOrderStatusService { get; }
        ICreateDiscountService CreateDiscountService { get; }
        IGetAllDiscountCodeService GetAllDiscountCodeService { get; }
        IRegisterUserService RegisterUserService { get; }
        ICheckUserNameService CheckUserNameService { get; }
        ILoginUserService loginUserService { get; }
        IGetAllUsersService GetAllUsersService { get; }
        IUpdateUserService UpdateUserService { get; }
       IGetAllUserRolesService GetAllUserRolesService{get;}
    }
}
