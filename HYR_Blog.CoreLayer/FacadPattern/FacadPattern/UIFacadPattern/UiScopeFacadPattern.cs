using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Services.CategoryServices.Commands;
using HYR_Blog.CoreLayer.Services.CategoryServices.Queries;
using HYR_Blog.CoreLayer.Services.ProductServices.Queries;
using HYR_Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.CoreLayer.Services.CommentServices.Commands;
using HYR_Blog.CoreLayer.Services.CartService.Common;
using HYR_Blog.CoreLayer.Services.CartService.Queries;
using HYR_Blog.CoreLayer.Services.OrderService.Command;
using HYR_Blog.CoreLayer.Services.OrderService.Queries;
using HYR_Blog.CoreLayer.Services.OrderService;

namespace HYR_Blog.CoreLayer.FacadPattern.FacadPattern.UIFacadPattern
{
    public class UiScopeFacadPattern : IUiScopeFacadPattern
    {
        private readonly HyrDbContext _dbContext;
        public UiScopeFacadPattern(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        private IGetShortAllCategoryService _getShortAllCategoryService;
        public IGetShortAllCategoryService GetShortAllCategoryService
        {
            get
            {
                return _getShortAllCategoryService = _getShortAllCategoryService ?? new GetShortAllCategoryService(_dbContext);
            }
        }




        private IGetNewestProductService _getNewestProductService;
        public IGetNewestProductService GetNewestProductService
        {
            get
            {
                return _getNewestProductService = _getNewestProductService ?? new GetNewestProductService(_dbContext);
            }
        }


        private IGetIndexCategoryService _getIndexCategoryService;
        public IGetIndexCategoryService GetIndexCategoryService
        {
            get
            {
                return _getIndexCategoryService = _getIndexCategoryService ?? new GetIndexCategoryService(_dbContext);
            }
        }


        private IGetNewesProductByCatIdService _getNewesProductByCatIdService;
        public IGetNewesProductByCatIdService GetNewesProductByCatIdService
        {
            get
            {
                return _getNewesProductByCatIdService = _getNewesProductByCatIdService ?? new GetNewesProductByCatIdService(_dbContext);
            }
        }



        private IUpdateSpecialCategoryService _updateSpecialCategoryService;
        public IUpdateSpecialCategoryService UpdateSpecialCategoryService
        {
            get
            {
                return _updateSpecialCategoryService = _updateSpecialCategoryService ?? new UpdateSpecialCategoryService(_dbContext);
            }
        }


        private IGetProductIsSpecialService _getProductIsSpecialService;
        public IGetProductIsSpecialService GetProductIsSpecialService
        {
            get
            {
                return _getProductIsSpecialService = _getProductIsSpecialService ?? new GetProductIsSpecialService(_dbContext);
            }
        }



        private IGetMostDiscountProductService _getMostDiscountProductService;
        public IGetMostDiscountProductService GetMostDiscountProductService
        {
            get
            {
                return _getMostDiscountProductService = _getMostDiscountProductService ?? new GetMostDiscountProductService(_dbContext);
            }
        }


        private IGetProductByDiscountService _getProductByDiscountService;
        public IGetProductByDiscountService GetProductByDiscountService
        {
            get
            {
                return _getProductByDiscountService = _getProductByDiscountService ?? new GetProductByDiscountService(_dbContext);
            }
        }



        private IGetSingleProductService _getSingleProductService;
        public IGetSingleProductService GetSingleProductService
        {
            get
            {
                return _getSingleProductService = _getSingleProductService ?? new GetSingleProductService(_dbContext);
            }
        }



        private ICreateCommentService _createCommentService;

        public ICreateCommentService CreateCommentService
        {
            get
            {
                return _createCommentService = _createCommentService ?? new CreateCommentService(_dbContext);
            }
        }


        private ICreateCartService _createCartService;
        public ICreateCartService CreateCartService
        {
            get
            {
                return _createCartService = _createCartService ?? new CreateCartService(_dbContext);
            }
        }



        private IGetCartAndCartItemService _getCartAndCartItemService;
        public IGetCartAndCartItemService GetCartAndCartItemService
        {
            get
            {
                return _getCartAndCartItemService = _getCartAndCartItemService ?? new GetCartAndCartItemService(_dbContext);
            }
        }


        private IGetCartItemDetailService _getCartItemDetailService;
        public IGetCartItemDetailService GetCartItemDetailService
        {
            get
            {
                return _getCartItemDetailService = _getCartItemDetailService ?? new GetCartItemDetailService(_dbContext);
            }
        }


        private IAddCartItemInCartService _addCartItemInCartService;
        public IAddCartItemInCartService AddCartItemInCartService
        {
            get
            {
                return _addCartItemInCartService = _addCartItemInCartService ?? new AddCartItemInCartService(_dbContext);
            }
        }



        private IRemoveCartItemFromCartService _removeCartItemFromCartService;
        public IRemoveCartItemFromCartService RemoveCartItemFromCartService
        {
            get
            {
                return _removeCartItemFromCartService = _removeCartItemFromCartService ?? new RemoveCartItemFromCartService(_dbContext);
            }
        }


        private IGetCartDetailIncludeTransportationService _getCartDetailIncludeTransportationService;
        public IGetCartDetailIncludeTransportationService GetCartDetailIncludeTransportationService
        {
            get
            {
                return _getCartDetailIncludeTransportationService = _getCartDetailIncludeTransportationService ?? new GetCartDetailIncludeTransportationService(_dbContext);
            }
        }


        private IUpdateCartDetailTotalPriseService _updateCartDetailTotalPriseService;
        public IUpdateCartDetailTotalPriseService UpdateCartDetailTotalPriseService
        {
            get
            {
                return _updateCartDetailTotalPriseService = _updateCartDetailTotalPriseService ?? new UpdateCartDetailTotalPriseService(_dbContext);
            }
        }




        private IGetProductsByFilterService _getProductsByFilterService;
        public IGetProductsByFilterService GetProductsByFilterService
        {
            get
            {
                return _getProductsByFilterService = _getProductsByFilterService ?? new GetProductsByFilterService(_dbContext);
            }
        }


        private IRemoveAllCartItemInCartService _removeAllCartItemInCartService;
        public IRemoveAllCartItemInCartService RemoveAllCartItemInCartService
        {
            get
            {
                return _removeAllCartItemInCartService = _removeAllCartItemInCartService ?? new RemoveAllCartItemInCartService(_dbContext); 
            }
        }



        private IEditUserIdInCartService _editUserIdInCartService;
        public IEditUserIdInCartService EditUserIdInCartService
        {
            get
            {
                return _editUserIdInCartService = _editUserIdInCartService ?? new EditUserIdInCartService(_dbContext);
            }
        }

        private ISaveOrderConfirmationService _saveOrderConfirmationService;
        public ISaveOrderConfirmationService SaveOrderConfirmationService
        {
            get
            {
                return _saveOrderConfirmationService = _saveOrderConfirmationService ?? new SaveOrderConfirmationService(_dbContext);
            }
        }

       private ICreateNewPayService _createNewPayService;
        public ICreateNewPayService CreateNewPayService
        {
            get
            {
                return _createNewPayService = _createNewPayService ?? new CreateNewPayService(_dbContext);
            }
        }

        private IGetAllUserOrderService _getAllUserOrderService;
        public IGetAllUserOrderService GetAllUserOrderService
        {
            get
            {
                return _getAllUserOrderService = _getAllUserOrderService ?? new GetAllUserOrderService(_dbContext);
            }
        }

    }
}
