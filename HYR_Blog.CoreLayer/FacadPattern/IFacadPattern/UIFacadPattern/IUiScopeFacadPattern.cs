using HYR_Blog.CoreLayer.Services.CartService.Common;
using HYR_Blog.CoreLayer.Services.CartService.Queries;
using HYR_Blog.CoreLayer.Services.CategoryServices.Commands;
using HYR_Blog.CoreLayer.Services.CategoryServices.Queries;
using HYR_Blog.CoreLayer.Services.CommentServices.Commands;
using HYR_Blog.CoreLayer.Services.OrderService;
using HYR_Blog.CoreLayer.Services.OrderService.Command;
using HYR_Blog.CoreLayer.Services.OrderService.Queries;
using HYR_Blog.CoreLayer.Services.ProductServices.Queries;


namespace HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern
{
    public interface IUiScopeFacadPattern
    {
        IGetShortAllCategoryService GetShortAllCategoryService { get; }
        IGetNewestProductService GetNewestProductService { get; }
        IGetIndexCategoryService GetIndexCategoryService { get; }
        IGetNewesProductByCatIdService GetNewesProductByCatIdService { get; }
        IUpdateSpecialCategoryService UpdateSpecialCategoryService { get; }
        IGetProductIsSpecialService GetProductIsSpecialService { get; }
        IGetMostDiscountProductService GetMostDiscountProductService { get; }
        IGetProductByDiscountService GetProductByDiscountService { get; }
        IGetSingleProductService GetSingleProductService { get; }
        ICreateCommentService CreateCommentService { get; }
        ICreateCartService CreateCartService { get; }
        IGetCartAndCartItemService GetCartAndCartItemService { get; }
        IGetCartItemDetailService GetCartItemDetailService { get; }
        IAddCartItemInCartService AddCartItemInCartService { get; }
        IRemoveCartItemFromCartService RemoveCartItemFromCartService { get; }
        IGetCartDetailIncludeTransportationService GetCartDetailIncludeTransportationService { get; }
        IUpdateCartDetailTotalPriseService UpdateCartDetailTotalPriseService { get; }
        IGetProductsByFilterService GetProductsByFilterService { get; }

        IRemoveAllCartItemInCartService RemoveAllCartItemInCartService { get; }
        IEditUserIdInCartService EditUserIdInCartService { get; }
        ISaveOrderConfirmationService SaveOrderConfirmationService { get; }
        ICreateNewPayService CreateNewPayService { get; }
        IGetAllUserOrderService GetAllUserOrderService { get; }
    }
}
