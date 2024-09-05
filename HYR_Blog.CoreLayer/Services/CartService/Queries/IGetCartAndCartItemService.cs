using HYR_Blog.CoreLayer.Dtos.CartDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.CartService.Queries
{
    public interface IGetCartAndCartItemService
    {
        MyResult<CartDto> GetCart(string? CartCode,int? UserId);
    }

    public class GetCartAndCartItemService : IGetCartAndCartItemService
    {
        private readonly HyrDbContext _dbContext;
        public GetCartAndCartItemService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<CartDto> GetCart(string? CartCode , int? UserId)
        {


            if (string.IsNullOrWhiteSpace(CartCode) && UserId == null)
                return MyResult<CartDto>.NotFound(null,StatusMessage:"کوکی یافت نشد");



            Cart? cart = null;

            if(UserId != null)
                cart = _dbContext.Carts.Include(c=>c.CartItems).OrderByDescending(c=>c.CreationDate).FirstOrDefault(c=>c.UserId == UserId);
            else
                cart = _dbContext.Carts.Include(c=>c.CartItems).OrderByDescending(c=>c.CreationDate).FirstOrDefault(c=>c.CartCode == CartCode);
            
            if (cart == null)
                    return  MyResult<CartDto>.NotFound(null);





            CartDto cartDto = new CartDto()
            {
                TotalPrise = cart.CartItems.Select(ci=>ci.Prise).Sum(),
                CartItems = cart.CartItems.GroupBy(ci=>ci.ProductId).Select(ci=>new CartItemDto()
                {
                    CartItemId = ci.Select(cig=>cig.CartItemId).First(),
                    Count = ci.Count(),
                    Price = ci.Select(cig=>cig.Prise).First(),
                    ProductId = ci.Select(cig=>cig.ProductId).First(),
                }).ToList(),
               
            };
            return MyResult<CartDto>.Success(cartDto);
        }
    }
}
