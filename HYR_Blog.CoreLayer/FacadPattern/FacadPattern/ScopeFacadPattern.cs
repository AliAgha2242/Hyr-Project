using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
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
using HYR_Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.FacadPattern.FacadPattern;

public class ScopeFacadPattern : IScopeFacadPattern
{
    private readonly HyrDbContext _dbContext;
    private readonly IFileManageService _fileManageService;

    public ScopeFacadPattern(HyrDbContext dbContext, IFileManageService fileManageService)
    {
        _dbContext = dbContext;
        _fileManageService = fileManageService;
    }




    private ICreateCategoryService _categoryService;
    public ICreateCategoryService CreateCategoryService
    {
        get
        {
            return _categoryService = _categoryService ?? new CreateCategoryService(_dbContext);
        }
    }


    private IGetAllCategoryService _allCategoryService;
    public IGetAllCategoryService AllCategoryService
    {
        get
        {
            return _allCategoryService = _allCategoryService ?? new GetAllCategoryService(dbContext: _dbContext);
        }
    }


    private IDeleteCategoryService _deleteCategoryService;
    public IDeleteCategoryService DeleteCategoryService
    {
        get
        {
            return _deleteCategoryService = _deleteCategoryService ?? new DeleteCategoryService(_dbContext);
        }
    }


    private IEditCategoryService _editCategoryService;

    public IEditCategoryService EditCategoryService
    {
        get
        {
            return _editCategoryService = _editCategoryService ?? new EditCategoryService(_dbContext);
        }
    }


    //private IFileManageService _fileManageService;

    //public IFileManageService FileManageService
    //{
    //    get
    //    {
    //        return _fileManageService = _fileManageService ?? new FileManageService();
    //    }
    //}


    private ICreateProductService _createProductService;

    public ICreateProductService CreateProductService
    {
        get
        {
            return _createProductService = _createProductService ?? new CreateProductService(_dbContext, _fileManageService);
        }
    }


    private IGetAllProductPropertyService _getAllProductPropertyService;

    public IGetAllProductPropertyService GetAllProductPropertyService
    {
        get
        {
            return _getAllProductPropertyService =
                _getAllProductPropertyService ?? new GetAllProductPropertyService(_dbContext);
        }
    }


    private IShortGetAllProduct _shortGetAllProduct;

    public IShortGetAllProduct ShortGetAllProduct
    {
        get
        {
            return _shortGetAllProduct = _shortGetAllProduct ?? new ShortGetAllProduct(_dbContext);
        }
    }

    private IDeleteProductService _deleteProductService;

    public IDeleteProductService DeleteProductService
    {
        get
        {
            return _deleteProductService = _deleteProductService ?? new DeleteProductService(_dbContext);
        }
    }


    private IGetProductService _getProductService;

    public IGetProductService GetProductService
    {

        get
        {
            return _getProductService = _getProductService ?? new GetProductService(_dbContext);
        }
    }

    private IEditProductService _editProductService;

    public IEditProductService EditProductService
    {
        get
        {
            return _editProductService = _editProductService ?? new EditProductService(_dbContext, _fileManageService);
        }
    }


    private IGetProductPropertyService _getProductPropertyService;

    public IGetProductPropertyService GetProductPropertyService
    {
        get
        {
            return _getProductPropertyService = _getProductPropertyService ?? new GetProductPropertyService(_dbContext);
        }
    }

    private ICreateProductPropertyService _createProductPropertyService;

    public ICreateProductPropertyService CreateProductPropertyService
    {
        get
        {
            return _createProductPropertyService =
                _createProductPropertyService ?? new CreateProductPropertyService(_dbContext);

        }
    }


    private IDeleteProductPropertyService _deleteProductPropertyService;

    public IDeleteProductPropertyService DeleteProductPropertyService
    {
        get
        {
            return _deleteProductPropertyService =
                _deleteProductPropertyService ?? new DeleteProductPropertyService(_dbContext);
        }
    }


    private IDeleteImageService _deleteImageService;

    public IDeleteImageService DeleteImageService
    {
        get
        {
            return _deleteImageService = _deleteImageService ?? new DeleteImageService(_dbContext, _fileManageService);
        }
    }



    private IGetProductImagesService _getProductImagesService;

    public IGetProductImagesService GetProductImagesService
    {
        get
        {
            return _getProductImagesService = _getProductImagesService ?? new GetProductImagesService(_dbContext);
        }
    }

    private IAddProductImageService _addProductImageService;

    public IAddProductImageService AddProductImageService
    {
        get
        {
            return _addProductImageService =
                _addProductImageService ?? new AddProductImageService(_dbContext, _fileManageService);
        }
    }



    private IGetProductImageCountService _getProductImageCountService;

    public IGetProductImageCountService GetProductImageCountService
    {
        get
        {
            return _getProductImageCountService = _getProductImageCountService ?? new GetProductImageCountService(_dbContext);
        }
    }



    private IGetProductPropertyCountService _getProductPropertyCountService;

    public IGetProductPropertyCountService GetProductPropertyCountService
    {
        get
        {
            return _getProductPropertyCountService = _getProductPropertyCountService ?? new GetProductPropertyCountService(_dbContext);
        }
    }



    private IGetAllOrderService _getAllOrderService;

    public IGetAllOrderService GetAllOrderService
    {
        get
        {
            return _getAllOrderService = _getAllOrderService ?? new GetAllOrderService(_dbContext);
        }
    }


    private IChangeOrderStatusService _chengeOrderStatus;
    public IChangeOrderStatusService chengeOrderStatusService
    {
        get
        {
            return _chengeOrderStatus = _chengeOrderStatus ?? new ChangeOrderStatusService(_dbContext);
        }
    }


    private IGetNextOrderStatusService _GetNextOrderStatusService;
    public IGetNextOrderStatusService GetNextOrderStatusService
    {
        get
        {
            return _GetNextOrderStatusService = _GetNextOrderStatusService ?? new GetNextOrderStatusService(_dbContext);
        }
    }




    private ICreateDiscountService _createDiscountService;
    public ICreateDiscountService CreateDiscountService
    {
        get
        {
            return _createDiscountService = _createDiscountService ?? new CreateDiscountService(_dbContext);
        }
    }




    private IGetAllDiscountCodeService _getAllDiscountCodeService;
    public IGetAllDiscountCodeService GetAllDiscountCodeService
    {
        get
        {
            return _getAllDiscountCodeService = _getAllDiscountCodeService ?? new GetAllDiscountCodeService(_dbContext);
        }
    }


    private IRegisterUserService _registerUserService;
    public IRegisterUserService RegisterUserService
    {
        get
        {
            return _registerUserService = _registerUserService ?? new RegisterUserService(_dbContext);
        }
    }


    private ICheckUserNameService _checkUserNameService;
    public ICheckUserNameService CheckUserNameService
    {
        get
        {
            return _checkUserNameService = _checkUserNameService ?? new CheckUserNameService(_dbContext);
        }
    }



    private ILoginUserService _loginUserService;
    public ILoginUserService loginUserService
    {
        get
        {
            return _loginUserService = _loginUserService ?? new LoginUserService(_dbContext);
        }
    }



    private IGetAllUsersService _getAllUsersService;
    public IGetAllUsersService GetAllUsersService
    {
        get
        {
            return _getAllUsersService = _getAllUsersService ?? new GetAllUsersService(_dbContext);
        }
    }



    private IUpdateUserService _updateUserService;
    public IUpdateUserService UpdateUserService
    {
        get
        {
            return _updateUserService = _updateUserService ?? new UpdateUserService(_dbContext);
        }
    }


    private IGetAllUserRolesService _getAllUserRolesServie;
    public IGetAllUserRolesService GetAllUserRolesService
    {
        get
        {
            return _getAllUserRolesServie = _getAllUserRolesServie ?? new GetAllUserRolesService(_dbContext);
        }
    }

    
}