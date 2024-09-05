using HYR_Blog.CoreLayer.Dtos.DiscountDto;
using HYR_Blog.CoreLayer.Utilities.FilterResult;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.Other;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.DisCountService.Queries
{
    public interface IGetAllDiscountCodeService
    {
        MyResult<List<DiscountDto>> GetAllDiscount(FilterResult? filterparams);
    }

    public class GetAllDiscountCodeService : IGetAllDiscountCodeService
    {
        private readonly HyrDbContext _dbContext;
        public GetAllDiscountCodeService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<List<DiscountDto>> GetAllDiscount(FilterResult? filterparams)
        { 
            List<DiscountCode>? result = _dbContext.DiscountCodes.AsQueryable().ToList();

            if (filterparams.IsActive == true)   
                result = result.Where(d=>
                (DateTime.Compare(d.EndDate , DateTime.Now) > 0) && d.UseCount < d.UseCountAllowed).ToList();
               

            if (!string.IsNullOrWhiteSpace(filterparams.Name))
                result = result.Where(d=>d.DisCountCodeText.Contains(filterparams.Name)).ToList();


            List<DiscountDto> discountDto = result.Select(d=>new DiscountDto()
            {
                DisCountAmount = d.DisCountAmount,
                DiscountCodeId = d.DiscountCodeId,
                DiscountText = d.DisCountCodeText,
                EndDate = DateTimeConverter.ConvertToPersian(d.EndDate),
                UseCount = d.UseCount,
                UseCountAllowed = d.UseCountAllowed,
            }).ToList();
            return MyResult<List<DiscountDto>>.Success(discountDto);
        }
    }
}
