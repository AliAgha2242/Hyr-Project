using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Services.ProductPropertyServices.Commands;

public interface IDeleteProductPropertyService
{
    MyResultWithoutData DeleteProperty(int propertyId);
}
public class DeleteProductPropertyService : IDeleteProductPropertyService
{
    private readonly HyrDbContext _context;

    public DeleteProductPropertyService(HyrDbContext context)
    {
        _context = context;
    }
    public MyResultWithoutData DeleteProperty(int propertyId)
    {
        bool IsExists = _context.ProductProperties.Any(p => p.PropertyId == propertyId);
        if(!IsExists)
            return MyResultWithoutData.NotFound();
        ProductProperty deleteProperty = _context.ProductProperties.First(p => p.PropertyId == propertyId);

        _context.ProductProperties.Remove(deleteProperty);
        _context.SaveChanges();
        return MyResultWithoutData.Success();
    }
}
