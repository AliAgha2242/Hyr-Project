using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.CategoryServices.Commands
{
    public interface IUpdateSpecialCategoryService
    {
        MyResultWithoutData UpdateCategorySpecial(List<int> categoriesId);
    }

    public class UpdateSpecialCategoryService : IUpdateSpecialCategoryService
    {
        private readonly HyrDbContext _dbContext;
        public UpdateSpecialCategoryService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResultWithoutData UpdateCategorySpecial(List<int> categoriesId)
        {
            //check null varrible
            Category? dbCategory = new Category();

            //keep in varrible
            List<Category> categories = new List<Category>();

            //categoryname  for error Message virable
            List<string> InvalidCategoryName = new List<string>();


            //set Is special on false for all Categories
            foreach(var item in _dbContext.Categories)
                item.IsSpecial = false;

            _dbContext.SaveChanges();


            // find category select in db
            foreach (var category in categoriesId)
            {
                //check null 
                dbCategory = _dbContext.Categories.Include(c=>c.Products).FirstOrDefault(c => c.CategoryId == category);
                if (dbCategory != null)
                {
                    categories.Add(dbCategory);
                }

            }

            //check empty
            if (categoriesId == null)
                return MyResultWithoutData.NotFound(StatusMessage: "خطای سرور . فیلد ها خالی است");


            // set is special on true for selectd varible
            foreach (var category in categories)
            {
                //check count categries Product
                var ProductCount = category.Products.Count;
                if (ProductCount < 4)
                {
                    InvalidCategoryName.Add(category.CategoryName);
                    continue;
                }
                category.IsSpecial = true;
            }

            _dbContext.Categories.UpdateRange(categories);
            _dbContext.SaveChanges();


            //config error Mssage for invalid categoryName
            string errorInvalidCategoryName = "";
            foreach(var str in InvalidCategoryName)
                errorInvalidCategoryName = errorInvalidCategoryName + str + " - " ;

            return MyResultWithoutData.Success(StatusMessage:string.IsNullOrEmpty(errorInvalidCategoryName)?"عملیات با موفقیت انحام شد ":"دسته بندی های زیر قابل قبول نبودن \n"+ errorInvalidCategoryName);

        }
    }
}
