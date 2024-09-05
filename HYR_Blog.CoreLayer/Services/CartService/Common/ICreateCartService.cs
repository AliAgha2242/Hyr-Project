using HYR_Blog.CoreLayer.Dtos.CartDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.CartService.Common
{
    public interface ICreateCartService
    {
        MyResultWithoutData CreateCart(int? UserId, string CartCode, CartItemDto cartItemParameter,int HowCount);
    }
    public class CreateCartService : ICreateCartService
    {
        private readonly HyrDbContext context;
        public CreateCartService(HyrDbContext context)
        {
            this.context = context;
        }
        public MyResultWithoutData CreateCart(int? UserId, string CartCode, CartItemDto cartItemParameter, int HowCount)
        {
            if (string.IsNullOrWhiteSpace(CartCode) && UserId == null)
                return MyResultWithoutData.Failed(StatusMessage: "مشکلی در سمت سرور پیش آمده . فیلد ها خالی است ");

            if (!context.Products.Any(p => p.ProductId == cartItemParameter.ProductId))
                return MyResultWithoutData.NotFound(StatusMessage: "محصول مورد نظر یافت نشد خطای سرور فیلد ها خالی است");


            //How To Get UserId In Services
            //ClaimsPrincipal claims= new ClaimsPrincipal();
            //claims.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier);

            List<CartItem> items = new List<CartItem>();

            for (int i = 1; i <= HowCount; i++)
            {
                CartItem cartItem = new CartItem()
                {
                    ProductId = cartItemParameter.ProductId,
                    CreationDate = DateTime.Now,
                    //prise
                    Prise = context.Products.First(p => p.ProductId == cartItemParameter.ProductId).PriseByDiscount ??
                    context.Products.First(p => p.ProductId == cartItemParameter.ProductId).Prise,

                };
                items.Add(cartItem);
            }



            int? productInventory = context.Products.First(p=>p.ProductId==cartItemParameter.ProductId).Inventory ;


            if (context.Carts.Any(c => c.CartCode == CartCode || c.UserId == UserId))
            {
                Cart cart = context.Carts.Include(p=>p.CartItems).First(c => c.CartCode == CartCode || c.UserId == UserId);
                

                foreach (var item in items)
                {
                      item.CartId = cart.CartId;
                }
                
                int CountWant = cart.CartItems.Where(c=>c.ProductId == cartItemParameter.ProductId).Count()+HowCount ;

                if (CountWant > productInventory)
                {
                    return MyResultWithoutData.Failed(StatusMessage:"تعداد خواسته شده شما بیشتر از حد مجاز است");
                }
                context.CartItems.AddRange(items);
            }



            else
            {
                Cart newcart = new Cart()
                {
                    CartCode = CartCode ?? Guid.NewGuid().ToString(),
                    CreationDate = DateTime.Now,
                    IsFinish = false,
                    UserId = UserId,
                    TransportationId = context.Transportations.First().TransportationId ,
                };

               

                context.Carts.Add(newcart);
                context.SaveChanges();

                foreach (var item in items)
                {
                    item.CartId = newcart.CartId;
                }

                
                context.CartItems.AddRange(items);
            }

            context.SaveChanges();
            return MyResultWithoutData.Success(StatusMessage:"به سبد اضافه شد");
        }
    }
}
