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
    public interface IGetCartItemDetailService
    {
        MyResult<List<CartItemDetailDto>> GetCartItemDetail(int? UserId, string? CartCode);
    }
    public class GetCartItemDetailService : IGetCartItemDetailService
    {
        private readonly HyrDbContext _context;
        public GetCartItemDetailService(HyrDbContext context)
        {
            _context = context;
        }
        public MyResult<List<CartItemDetailDto>> GetCartItemDetail(int? UserId, string? CartCode)
        {
            if (string.IsNullOrWhiteSpace(CartCode) && (UserId == null || UserId < 0))
                return MyResult<List<CartItemDetailDto>>.Failed(null);

            Cart? cart = null ;
            if(UserId != null)
                cart = _context.Carts.Include(c=>c.CartItems)
                    .ThenInclude(ci=>ci.Product).ThenInclude(p=>p.Images)
                    .FirstOrDefault(x => x.UserId == UserId && x.IsFinish == false);
            else
            {
                cart = _context.Carts.Include(c=>c.CartItems)
                    .ThenInclude(ci=>ci.Product).ThenInclude(p=>p.Images)
                    .FirstOrDefault(x => x.CartCode == CartCode && x.IsFinish == false);
            }

            if (cart == null)
                return MyResult<List<CartItemDetailDto>>.NotFound(null);


            List<CartItemDetailDto> cartItems = cart.CartItems
                .GroupBy(ci => ci.ProductId).
                Select(group =>
                new CartItemDetailDto()
                {
                    CartItemId = group.First().CartItemId,
                    Count = group.Count(),
                    FirstImageProduct = group.First().Product.Images.First().ImageName,
                    Inventory = Convert.ToInt32(group.First().Product.Inventory),
                    Prise = group.First().Product.PriseByDiscount ?? group.First().Product.Prise,
                    ProductId = group.First().Product.ProductId,
                    TotalPrise = group.Select(item => item.Prise).Sum(),
                    Weight = group.Select(item => item.Product.Weight).Sum(),
                    ProductName = group.Select(cg => cg.Product.ProductName).First(),
                    Slug = group.First().Product.Slug,
                }
                ).ToList();

            return MyResult<List<CartItemDetailDto>>.Success(cartItems);


        }
    }
}
