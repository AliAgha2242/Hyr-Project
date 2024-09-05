using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Commands;

public interface IDeleteProductService
{
    MyResultWithoutData DeleteProduct(int productId);
}

public class DeleteProductService : IDeleteProductService
{
    private readonly HyrDbContext _dbContext;

    public DeleteProductService(HyrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public MyResultWithoutData DeleteProduct(int productId)
    {
        Product product = _dbContext.Products.FirstOrDefault(p=> p.ProductId == productId);
        if (product == null)
            return MyResultWithoutData.NotFound(); 
        product.IsDelete = true;

        _dbContext.SaveChanges();
        return MyResultWithoutData.Success();
    }
}