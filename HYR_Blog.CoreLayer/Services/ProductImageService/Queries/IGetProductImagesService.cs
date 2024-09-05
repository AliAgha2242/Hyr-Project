using HYR_Blog.CoreLayer.Dtos.ImageProductDto;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductImageMapper;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;

namespace HYR_Blog.CoreLayer.Services.ProductImageService.Queries;

public interface IGetProductImagesService
{
    MyResult <List<ImageProductDto>> GetProductImagesBy(int ProductId);
}

public class GetProductImagesService : IGetProductImagesService
{
    private readonly HyrDbContext _dbContext;

    public GetProductImagesService(HyrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public MyResult<List<ImageProductDto>> GetProductImagesBy(int ProductId)
    {
        if(ProductId == null)
            return MyResult<List<ImageProductDto>>.Failed(new List<ImageProductDto>());

        List<ImageProductDto> images = _dbContext.Images.Where(i => i.ProductId == ProductId).OrderByDescending(i=>i.CreationDate)
            .Select(i => ProductImageMapper.ImageToImageDto(i)).ToList();

        return MyResult<List<ImageProductDto>> .Success(images);
    }
}
