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
    public interface IGetProductIsSpecialService
    {
        MyResult<List<IndexProductDto>> GetProductIsSpecial();
    }

    public class GetProductIsSpecialService : IGetProductIsSpecialService
    {
        private readonly HyrDbContext _dbContext;
        public GetProductIsSpecialService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<List<IndexProductDto>> GetProductIsSpecial()
        {
            List<IndexProductDto> indexProducts = _dbContext.Products
                .Include(p=>p.Images)
                .Where(p=>p.IsSpecial).OrderBy(p=>p.Visit).Take(5)
                .Select(p=>new IndexProductDto()
                {
                    FirstImageName = p.Images.First().ImageName,
                    PriceByDiscount = Convert.ToInt32(p.PriseByDiscount),
                    Prise = p.Prise,
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Slug = p.Slug,
                }).ToList();

            return MyResult<List<IndexProductDto>>.Success(indexProducts);
        }
    }
}
