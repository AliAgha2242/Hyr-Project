using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductMapper;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Queries;

public interface IGetProductService
{
    MyResult<ProductDto> GetProductBy(int ProductId);
    MyResult<CartProductDto> GetCartProductBy(int ProductId);
}
public class GetProductService : IGetProductService
{
    private readonly HyrDbContext _dbContext;

    public GetProductService(HyrDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public MyResult<CartProductDto> GetCartProductBy(int ProductId)
    {
        Product? product = _dbContext.Products.Include(p=>p.Images).FirstOrDefault(p=>p.ProductId == ProductId);
        if (product == null)
        {
            return MyResult<CartProductDto>.NotFound(new CartProductDto());
        }


        CartProductDto cartProductDto = new CartProductDto()
        {
            FirstImageName = product.Images.First().ImageName,
            ProductId = product.ProductId,
            ProductName = product.ProductName,
        };

        return MyResult<CartProductDto>.Success(cartProductDto);
    }

    public MyResult<ProductDto> GetProductBy(int ProductId)
    {
        Product? result = _dbContext.Products.Include(p => p.Category)
            .Include(p => p.Images)
            .Include(p => p.Properties)
            .FirstOrDefault(p => p.ProductId == ProductId);

        if (result == null)
            return MyResult<ProductDto>.NotFound(data: new ProductDto());

        ProductDto productDto = ProductMapper.ProductToProDto(result);

        return MyResult<ProductDto>.Success(data:productDto);
    }
}
