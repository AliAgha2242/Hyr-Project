using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.CategoryServices.Commands
{
    public interface IEditCategoryService
    {
         MyResultWithoutData EditCategory(CategoryDto category);
    }
    public class EditCategoryService:IEditCategoryService
    {
        private readonly HyrDbContext _dbContext;

        public EditCategoryService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResultWithoutData EditCategory(CategoryDto editCategory)
        {
            bool IsExsist = _dbContext.Categories.Any(c => c.IsDelete == false && c.CategoryId == editCategory.CategoryId);

            if (!IsExsist)
                return MyResultWithoutData.NotFound();

            Category category =
                _dbContext.Categories.AsNoTracking().First(c => c.IsDelete == false && c.CategoryId == editCategory.CategoryId);

            category.MetaDescription = editCategory.MetaDescription;
            category.MetaTag = editCategory.MetaTag;
            category.CategoryName = editCategory.CategoryName;
            category.KeyWorld = editCategory.KeyWorld;

            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();

            return MyResultWithoutData.Success();
        }
    }
}
