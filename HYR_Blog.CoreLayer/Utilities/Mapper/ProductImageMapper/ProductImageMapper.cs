using HYR_Blog.CoreLayer.Dtos.ImageProductDto;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Utilities.Mapper.ProductImageMapper;

public class ProductImageMapper
{
    public static ImageProductDto ImageToImageDto(ProductImage productImage)
    {
        return new ImageProductDto()
        {
            ImageId = productImage.ImageId,
            ImageName = productImage.ImageName,
            ImageUrl = productImage.ImageDirectory,
            ProductId = productImage.ProductId
        };
    }
}