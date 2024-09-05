using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductPropertyMapper;
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
    public interface IGetMostDiscountProductService
    {
        MyResult<List<MostDiscountProductDto>> GetMostDiscountProduct();
    }

    public class GetMostDiscountProductService : IGetMostDiscountProductService
    {
        private readonly HyrDbContext _dbContext;
        public GetMostDiscountProductService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<List<MostDiscountProductDto>> GetMostDiscountProduct()
        {
            try
            {
                List<MostDiscountProductDto> productDtos = _dbContext.Products
                    .Include(p=>p.Images)
                    .Include(p=>p.Properties)
                    .Where(p=>p.PriseByDiscount != null)
                .OrderByDescending(p=>((p.Prise-p.PriseByDiscount)*100)/p.Prise)
                .Take(5).Select(p=>new MostDiscountProductDto()
                {
                    DiscountPercent = ((p.Prise-p.PriseByDiscount)*100)/p.Prise,
                    CategoryName = p.Category.CategoryName,
                    FirstImageName = p.Images.First().ImageName,
                    Inventory = p.Inventory,
                    Prise = p.Prise,
                    PriseByDiscount = Convert.ToInt32(p.PriseByDiscount),
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Properties = p.Properties.Take(4).Select(pr=>ProductPropertyMapper.PropertyToDto(pr)).ToList(),
                    Slug = p.Slug
                    

                }).ToList();
                return MyResult<List<MostDiscountProductDto>>.Success(productDtos);
            }
            catch 
            {
                return MyResult<List<MostDiscountProductDto>>.Failed(new List<MostDiscountProductDto>(),StatusMessage:"سرور با خطا مواجه شده");
            }

        }
    }
}
