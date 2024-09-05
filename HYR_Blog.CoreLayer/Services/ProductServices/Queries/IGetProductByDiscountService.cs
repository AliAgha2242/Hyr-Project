using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Queries
{
    public interface IGetProductByDiscountService
    {
        MyResult<List<DiscountProductDto>> GetProductByDiscount();
    }

    public class GetProductByDiscountService : IGetProductByDiscountService
    {
        private readonly HyrDbContext _context;
        public GetProductByDiscountService(HyrDbContext context)
        {
            _context = context;
        }
        public MyResult<List<DiscountProductDto>> GetProductByDiscount()
        {
            List<DiscountProductDto>? productDtos = _context.Products
                    .Include(p=>p.Images)
                    .Include(p=>p.Properties)
                    .Where(p=>p.PriseByDiscount != null)
                .OrderByDescending(p=>((p.Prise-p.PriseByDiscount)*100)/p.Prise)
                .OrderByDescending(p=>p.LastUpdate).Take(4).Select(p=>new DiscountProductDto()
                {
                    FirstImageName = p.Images.First().ImageName,
                    ProductName = p.ProductName,
                    PriseByDiscount = Convert.ToInt32(p.PriseByDiscount),
                    ProductId = p.ProductId,
                    Slug = p.Slug
                    
                }).ToList();
            return MyResult<List<DiscountProductDto>>.Success(productDtos);
        }
    }
}
