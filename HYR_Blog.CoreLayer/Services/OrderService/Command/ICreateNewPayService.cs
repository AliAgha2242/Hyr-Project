using HYR_Blog.CoreLayer.Dtos.PayDto;
using HYR_Blog.CoreLayer.Services.OrderService.Command;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.OrderService.Command
{
    public interface ICreateNewPayService
    {
        MyResult<ResultCreatePayDto> CreateNewPay(int UserId , string? CartCode);
    }
    public class CreateNewPayService : ICreateNewPayService
    {
        private readonly HyrDbContext _dbContext;

        public CreateNewPayService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MyResult<ResultCreatePayDto> CreateNewPay(int UserId , string? CartCode)
        {
            Cart cart = _dbContext.Carts.OrderByDescending(c=>c.CreationDate).First(c=>c.UserId == UserId);

            if (cart == null )
                return MyResult<ResultCreatePayDto>.Failed(null , StatusMessage:"سبد خرید موحود نیست");


            Pay newPay = new Pay()
            {
                CartId = cart.CartId,
                CreationDate = DateTime.Now,
                IsPay = false ,
                TotalPrise = cart.TotalPrise,
                UserId = UserId,
            };
            
            _dbContext.Pays.Add(newPay);
            _dbContext.SaveChanges();

            ResultCreatePayDto result = new ResultCreatePayDto()
            {
                PhoneNumber = _dbContext.Users.Find(UserId).PhoneNumber,
                TotalPrise = cart.TotalPrise

            };
            return MyResult<ResultCreatePayDto>.Success(result);
        }
    }
}
