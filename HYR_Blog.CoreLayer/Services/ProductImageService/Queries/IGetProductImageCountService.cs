using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;

namespace HYR_Blog.CoreLayer.Services.ProductImageService.Queries;

public interface IGetProductImageCountService
{
    MyResult<int> ProductImageCount(int productId);
}

public class GetProductImageCountService : IGetProductImageCountService
{
    private readonly HyrDbContext _dbContext;

    public GetProductImageCountService(HyrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public MyResult<int> ProductImageCount(int productId)
    {
        try
        {
            return MyResult<int>.Success(_dbContext.Images.Count(p=>p.ProductId == productId));
        }
        catch 
        {
            return MyResult<int>.Failed(0);
        }
    }
}
