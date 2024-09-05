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
    public interface IAddCartItemInCartService
    {
        MyResultWithoutData AddCart(int? UserId,string? CartCode , int ProductId);
    }

    public class AddCartItemInCartService : IAddCartItemInCartService
    {
        private HyrDbContext _context;
        public AddCartItemInCartService(HyrDbContext context)
        {
            _context = context;
        }

        public MyResultWithoutData AddCart(int? UserId, string? CartCode,int ProductId)
        {
            if(string.IsNullOrWhiteSpace(CartCode) &&( UserId == null || UserId < 0))
                return MyResultWithoutData.Failed();


             Cart? cart = _context.Carts.Include(c => c.CartItems)
                .FirstOrDefault(c => c.UserId == UserId);

            if (cart == null)
            {
                cart = _context.Carts.FirstOrDefault(c => c.CartCode == CartCode);
                if (cart == null)
                    return MyResultWithoutData.NotFound(StatusMessage:"سبد خرید شما یافت نشد" );
            }


            int CartItemsInCartForNow = cart.CartItems.
                Where(ci=>ci.ProductId == ProductId).Count();

            if (_context.Products.Find(ProductId).Inventory <= CartItemsInCartForNow)
                return MyResultWithoutData.Failed(StatusMessage:"تعداد بیشتر از موحودی است");


            int prise = _context.Products.Find(ProductId).PriseByDiscount ?? _context.Products.Find(ProductId).Prise;

            

            //if (_context.CartItems.Any(ci=>ci.IsDelete == true && ci.ProductId == ProductId && ci.CartId == cart.CartId))
            //{
            //    _context.CartItems.OrderByDescending(ci=>ci.CreationDate).
            //        First(ci=>ci.IsDelete == true && ci.ProductId == ProductId && ci.CartId == cart.CartId).IsDelete = false;

            //    _context.SaveChanges();
            //    return MyResultWithoutData.Success();
            //}

            CartItem cartItem = new CartItem()
            {
                CartId = cart.CartId,
                CreationDate = DateTime.Now,
                IsDelete = false,
                Prise = prise,
                ProductId = ProductId,
                Cart = cart,
            };

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            return MyResultWithoutData.Success();

        }
    }
}
