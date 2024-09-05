using HYR_Blog.CoreLayer.Dtos.ProductPropertyDto;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductPropertyMapper;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;

namespace HYR_Blog.CoreLayer.Services.ProductPropertyServices.Queries;

public interface IGetAllProductPropertyService
{
    MyResult<List<ProductPropertyDto>> GetAllProductProperty();
}

public class GetAllProductPropertyService : IGetAllProductPropertyService
{
    private readonly HyrDbContext _dbContext;

    public GetAllProductPropertyService(HyrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public MyResult<List<ProductPropertyDto>> GetAllProductProperty()
    {
        
        List<ProductPropertyDto> Properties = _dbContext.ProductProperties.Select(p => ProductPropertyMapper.PropertyToDto(p)).ToList();
        return MyResult<List<ProductPropertyDto>>.Success(data:Properties);
    }
}