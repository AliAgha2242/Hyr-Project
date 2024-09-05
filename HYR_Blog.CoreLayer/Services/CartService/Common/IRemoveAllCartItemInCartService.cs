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
    public interface IRemoveAllCartItemInCartService
    {
        MyResultWithoutData RemoveAllCartItem(string? cartCode,int? UserId , int CartItemId);
    }
    public class RemoveAllCartItemInCartService : IRemoveAllCartItemInCartService
    {
        private readonly HyrDbContext _context;

        public RemoveAllCartItemInCartService(HyrDbContext context)
        {
            _context = context;
        }

        public MyResultWithoutData RemoveAllCartItem(string? cartCode, int? UserId, int CartItemId)
        {
            if(string.IsNullOrWhiteSpace(cartCode) && UserId == null )
                return MyResultWithoutData.NotFound();


            // I Now . This Code For read is very hard . but I want to prove my Knowledg 
            Cart? cart = _context.Carts
                .Include(c=>c.CartItems.
                Where(ci=>ci.ProductId == _context.CartItems.First(ci=>ci.CartItemId == CartItemId).ProductId))
                .OrderByDescending(c=>c.CreationDate).FirstOrDefault(c=>c.UserId == UserId || c.CartCode == cartCode); 

            if(cart == null || cart.CartItems.Count == 0)
                return MyResultWithoutData.NotFound();



            foreach(var cartItem in cart.CartItems)
                cartItem.IsDelete = true ;

            _context.SaveChanges();


            return MyResultWithoutData.Success();
            
        }
    }
}
