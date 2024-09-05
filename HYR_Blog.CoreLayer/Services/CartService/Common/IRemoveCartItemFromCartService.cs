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

namespace HYR_Blog.CoreLayer.Services.CartService.Common
{
    public interface IRemoveCartItemFromCartService
    {
        MyResultWithoutData RemoveCartItem(int? UserId , string? CartCode ,int ProductId);
    }

    public class RemoveCartItemFromCartService : IRemoveCartItemFromCartService
    {
        private readonly HyrDbContext _context;
        public RemoveCartItemFromCartService(HyrDbContext context)
        {
            _context = context;
        }
        public MyResultWithoutData RemoveCartItem(int? UserId, string? CartCode, int ProductId)
        {
            
            if(string.IsNullOrWhiteSpace(CartCode) &&( UserId == null || UserId < 0))
                return MyResultWithoutData.Failed();

              Cart? cart = null;

            cart = _context.Carts.Include(c => c.CartItems).SingleOrDefault(c => c.UserId == UserId && c.CartCode == CartCode && !c.IsFinish);

            if (cart == null)
                return MyResultWithoutData.NotFound();


            var cartItems = cart.CartItems.Where(ci=>ci.ProductId == ProductId);
            if (cartItems.Count() <= 1 )
                return MyResultWithoutData.Failed(); // 1
            cartItems.OrderByDescending(ci=>ci.CreationDate).First().IsDelete = true;
            _context.SaveChanges();

            return MyResultWithoutData.Success();
        }
    }
}
