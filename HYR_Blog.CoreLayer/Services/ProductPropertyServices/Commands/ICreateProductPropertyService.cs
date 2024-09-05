using HYR_Blog.CoreLayer.Dtos.ImageProductDto;
using HYR_Blog.CoreLayer.Dtos.ProductPropertyDto;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductPropertyMapper;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Services.ProductPropertyServices.Commands;

public interface ICreateProductPropertyService
{
    MyResultWithoutData CreateProperty(ProductPropertyDto propertyDto);
}
public class CreateProductPropertyService : ICreateProductPropertyService
{
    private readonly HyrDbContext _context;

    public CreateProductPropertyService(HyrDbContext context)
    {
        _context = context;
    }


    public MyResultWithoutData CreateProperty(ProductPropertyDto propertyDto)
    {

        if (_context.ProductProperties.Where(p => p.ProductId == propertyDto.ProductId).Count() >= 10)
            return MyResultWithoutData.Failed(StatusMessage: "تعداد ویژگی ها بیشتر از حد محاز است");


        if (propertyDto == null)
            return MyResultWithoutData.Failed();

        if (string.IsNullOrWhiteSpace(propertyDto.Key)||string.IsNullOrWhiteSpace(propertyDto.Value))
            return MyResultWithoutData.Failed();
        
        bool IsExistsKey = _context.ProductProperties.Any(p => p.Key == propertyDto.Key);
        bool IsExistsValue = _context.ProductProperties.Any(p => p.Value == propertyDto.Value);
        if (IsExistsKey && IsExistsValue)
            return MyResultWithoutData.Duplicate();
        ProductProperty property = ProductPropertyMapper.DtoToProperty(propertyDto);

        _context.ProductProperties.Add(property);
        _context.SaveChanges();
        return MyResultWithoutData.Success();
    }
}