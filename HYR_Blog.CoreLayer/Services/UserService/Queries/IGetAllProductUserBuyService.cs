using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.UserService.Queries;

public interface IGetAllProductUserBuyService
{
    MyResult<List<int>> GetAllProductUserBuy(int userId);
}
public class GetAllProductUserBuyService : IGetAllProductUserBuyService
{
    private readonly HyrDbContext _dbContext;

    public GetAllProductUserBuyService(HyrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public MyResult<List<int>> GetAllProductUserBuy(int userId)
    {

        try
        {
            if (userId == 0)
            {
                return MyResult<List<int>>.NotFound(new List<int>());
            }
            User? user = _dbContext.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.OrderDetails)
                .FirstOrDefault(u => u.UserId == userId);
            List<int> productsUserBuy = new List<int>();




            foreach (var VARIABLE in user.Orders)
            {
                foreach (var od in VARIABLE.OrderDetails)
                {
                    productsUserBuy.Add(od.ProductId);
                }
            }
            return MyResult<List<int>>.Success(productsUserBuy);
        }
        catch
        {
            return MyResult<List<int>>.Failed(new List<int>(), StatusMessage: "مشکلی در سمت سرور پیش آمده است");
        }
    }
}
