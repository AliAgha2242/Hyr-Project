using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.CategoryServices.Queries
{
    public interface IGetShortAllCategoryService
    {
        MyResult<List<ShortCategoryDto>> GetShortCatgeory();
    }
    public class GetShortAllCategoryService : IGetShortAllCategoryService
    {
        private readonly HyrDbContext _dbContext;
        public GetShortAllCategoryService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<List<ShortCategoryDto>> GetShortCatgeory()
        {
            List<ShortCategoryDto> categories = _dbContext.Categories.Include(c=>c.Products)
                .ThenInclude(p=>p.Images).Select(c=>new ShortCategoryDto()
            {
                CategoryName = c.CategoryName,
                FirstProductImage = c.Products.First().Images.First().ImageName,
                ProductsCount = c.Products.Count()
            }).ToList();
            return MyResult<List<ShortCategoryDto>>.Success(categories);
        }
    }
}
