using HYR_Blog.CoreLayer.Dtos.ProductPropertyDto;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductPropertyMapper;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.ProductPropertyServices.Queries;

public interface IGetProductPropertyService
{
    MyResult<List<ProductPropertyDto>> GetProductPropertyBy(int ProductId);
}

public class GetProductPropertyService : IGetProductPropertyService
{
    private readonly HyrDbContext _context;

    public GetProductPropertyService(HyrDbContext context)
    {
        _context = context;
    }
    public MyResult<List<ProductPropertyDto>> GetProductPropertyBy(int ProductId)
    {
        List<ProductProperty> property = _context.ProductProperties.Where(p => p.ProductId == ProductId).ToList();

        List<ProductPropertyDto> propertyDtos = property.Select(p => ProductPropertyMapper.PropertyToDto(p)).ToList();

        return MyResult<List<ProductPropertyDto>>.Success(propertyDtos);
    }
}
