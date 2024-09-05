using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Queries
{
    public interface IGetNewesProductByCatIdService
    {
        MyResult<List<IndexProductDto>> GetNewestProductBy(int categoryId);
    }

    public class GetNewesProductByCatIdService : IGetNewesProductByCatIdService
    {
        private readonly HyrDbContext _dbContext;
        public GetNewesProductByCatIdService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<List<IndexProductDto>> GetNewestProductBy(int categoryId)
        {
             IQueryable<Product> product = _dbContext.Products
                .Include(p=>p.Category)
                .Include(p=>p.Images)
                .Where(p=>p.CategoryId == categoryId);

            if (product.Count() <= 0)
            {
                return MyResult<List<IndexProductDto>>.NotFound(new List<IndexProductDto>());
            }
            

               List<IndexProductDto> productDtos = product.OrderByDescending(p=>p.CreationDate).Take(8).
                Select(p=>new IndexProductDto()
                {
                    CategoryName = p.Category.CategoryName,
                    FirstImageName = p.Images.First().ImageName,
                    PriceByDiscount = Convert.ToInt32(p.PriseByDiscount),
                    Prise = p.Prise,
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Score = p.Score,
                    Slug = p.Slug
                }).ToList();

          return MyResult<List<IndexProductDto>>.Success(productDtos);
        }
    }
}
