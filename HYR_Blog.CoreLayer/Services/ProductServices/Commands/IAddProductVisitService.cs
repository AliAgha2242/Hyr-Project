using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Commands
{
    public interface IAddProductVisitService
    {
        void AddProductVisit(int produtcId);
    }
    public class AddProductVisitService : IAddProductVisitService
    {
        private readonly HyrDbContext _dbContext;
        public AddProductVisitService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddProductVisit(int produtcId)
        {
            if (!_dbContext.Products.Any(p=>p.ProductId == produtcId))
                return;
            _dbContext.Products.First(p=>p.ProductId == produtcId).Visit += 1 ;

            _dbContext.SaveChanges();

        }
    }
}
