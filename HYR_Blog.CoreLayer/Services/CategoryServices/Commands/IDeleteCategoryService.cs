using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.CategoryServices.Commands
{
    public interface IDeleteCategoryService
    {
        MyResultWithoutData DeleteCategory(int CategoryId);
    }
    public class DeleteCategoryService : IDeleteCategoryService
    {
        private readonly DataLayer.Context.HyrDbContext _dbContext;

        public DeleteCategoryService(DataLayer.Context.HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResultWithoutData DeleteCategory(int CategoryId)
        {
            Category? category = EntityFrameworkQueryableExtensions.AsNoTracking(_dbContext.Categories)
                .FirstOrDefault(c => c.CategoryId == CategoryId);
            
            if (category == null) return MyResultWithoutData.NotFound();
            
            category.IsDelete = true;
            
            _dbContext.Categories.Update(category);
            
            _dbContext.SaveChanges();
            
            return MyResultWithoutData.Success();

        }
    }
}
