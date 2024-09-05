using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;

namespace HYR_Blog.CoreLayer.Services.ProductPropertyServices.Queries;

public interface IGetProductPropertyCountService
{
    MyResult<int> ProductPropertyCount(int productId);
}

public class GetProductPropertyCountService : IGetProductPropertyCountService
{
    private readonly HyrDbContext _dbContext;

    public GetProductPropertyCountService(HyrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public MyResult<int> ProductPropertyCount(int productId)
    {
        try
        {
            return MyResult<int>.Success(_dbContext.ProductProperties.Count(p => p.ProductId == productId));
        }
        catch
        {
            return MyResult<int>.Failed(0);
        }
    }
}
