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
    public interface IGetNewestProductService
    {
        MyResult<List<IndexProductDto>> GetNewestProduct(); 
    }
    public class GetNewestProductService : IGetNewestProductService
    {
        private readonly HyrDbContext _dbContext;
        public GetNewestProductService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<List<IndexProductDto>> GetNewestProduct()
        {
                List<IndexProductDto> productDtos = _dbContext.Products
                .Include(p=>p.Category)
                .Include(p=>p.Images)
                .OrderByDescending(p=>p.CreationDate).Take(8).
                Select(p=>new IndexProductDto()
                {
                    CategoryName = p.Category.CategoryName,
                    FirstImageName = p.Images.First().ImageName,
                    PriceByDiscount = Convert.ToInt32(p.PriseByDiscount),
                    Prise = p.Prise,
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Score = p.Score,
                    Slug = p.Slug,
                }).ToList();

          return MyResult<List<IndexProductDto>>.Success(productDtos);


        }
    }
}
