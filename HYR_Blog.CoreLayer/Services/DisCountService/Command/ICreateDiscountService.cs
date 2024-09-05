using HYR_Blog.CoreLayer.Dtos.DiscountDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.DisCountService.Command
{
    public interface ICreateDiscountService
    {
        MyResultWithoutData CreateDiscount(CreateDiscountDto discountDto);
    }

    public class CreateDiscountService : ICreateDiscountService
    {
        private readonly HyrDbContext _context;
        public CreateDiscountService(HyrDbContext dbContext)
        {
            _context = dbContext;
        }
        public MyResultWithoutData CreateDiscount(CreateDiscountDto discountDto)
        {
            if (discountDto == null)
                return MyResultWithoutData.Failed();

            DiscountCode discountCode = new DiscountCode()
            {
                CreationDate = DateTime.Now,
                DisCountAmount = discountDto.DisCountAmount,
                DisCountCodeText = discountDto.DisCountCodeText,
                EndDate = discountDto.StartDate.AddDays(discountDto.LifeTimeDay),
                LifeTimeDay = discountDto.LifeTimeDay,
                StartDate = discountDto.StartDate,
                UseCount = 0 ,
                UseCountAllowed = discountDto.UseCountAllowed,
            };
            _context.DiscountCodes.Add(discountCode);
            _context.SaveChanges();


            return MyResultWithoutData.Success();
        }
    }
}
