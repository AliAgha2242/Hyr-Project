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
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.CategoryServices.Commands
{
    public interface ICreateCategoryService
    {
        MyResultWithoutData CreateCategory(CreateCategoryDto categoryDto);
    }

    public class CreateCategoryService : ICreateCategoryService
    {
        private readonly HyrDbContext _dbContext;

        public CreateCategoryService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResultWithoutData CreateCategory(CreateCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return MyResultWithoutData.Failed();
            }

            Category NewCategory = CategoryMapper.CreateDtoToCategory(categoryDto);

            _dbContext.Categories.Add(NewCategory);

            _dbContext.SaveChanges();

            return MyResultWithoutData.Success();
        }
    }

}
