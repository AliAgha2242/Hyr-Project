using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.CartService.Common
{
    public interface IEditUserIdInCartService
    {
        MyResultWithoutData EditUserInCart(string? CartCode , int UserId);
    }
    public class EditUserIdInCartService : IEditUserIdInCartService
    {
        private readonly HyrDbContext _context;

        public EditUserIdInCartService(HyrDbContext context)
        {
            _context = context;
        }

        public MyResultWithoutData EditUserInCart(string? CartCode, int UserId)
        {
            if(string.IsNullOrWhiteSpace(CartCode)) 
                return MyResultWithoutData.NotFound();
            if(_context.Carts.All(c=>c.CartCode == CartCode && c.UserId != null))
                return MyResultWithoutData.Success();

            Cart cart = _context.Carts.Single(c=>c.CartCode == CartCode);
            cart.UserId = UserId;
            _context.Update(cart);
            _context.SaveChanges();

            return MyResultWithoutData.Success();
        }
    }
}
