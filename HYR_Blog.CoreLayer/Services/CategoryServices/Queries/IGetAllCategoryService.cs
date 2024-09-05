using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.Utilities.Mapper.CategoryMapper;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Services.CategoryServices.Queries
{
    public interface IGetAllCategoryService
    {
        MyResult<List<CategoryDto>> GetAllCategory();
    }
    public class GetAllCategoryService : IGetAllCategoryService
    {
        private readonly HyrDbContext _dbContext;

        public GetAllCategoryService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<List<CategoryDto>> GetAllCategory()
        {
            List<Category> categorys = _dbContext.Categories.OrderBy(p => p.CreationDate).ToList();

            List<CategoryDto> categoriesDto = categorys.Select(p => CategoryMapper.CategoryToDto(p)).ToList();

            return MyResult<List<CategoryDto>>.Success(data: categoriesDto);
        }
    }
}
