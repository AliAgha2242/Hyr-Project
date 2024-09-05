using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities.Other.Directories;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Utilities.Mapper.ProductMapper;

public class ProductMapper
{
    public static ShortProductDto ProductToShProDto(Product product)
    {
        return new ShortProductDto()
        {
            CategoryName = product.Category.CategoryName,
            IsSpecial = product.IsSpecial,
            Inventory = product.Inventory,
            Prise = product.Prise,
            ProductName = product.ProductName,
            ProductId = product.ProductId,
            Weight = product.Weight,
            PriseByDiscount = product.PriseByDiscount,
            ImageUrl = FileManage.GetProductImageByName(product.Images.OrderByDescending(I => I.CreationDate).FirstOrDefault()?.ImageName)
        };
    }

    public static ProductDto ProductToProDto(Product product)
    {
        return new ProductDto()
        {
            ProductPropertyDtos = product.Properties
                .Select(p => ProductPropertyMapper.ProductPropertyMapper.PropertyToDto(p)).ToList(),
            ProductName = product.ProductName,
            CategoryName = product.Category.CategoryName,
            IsSpecial = product.IsSpecial,
            Inventory = product.Inventory,
            Prise = product.Prise,
            MetaDescription = product.MetaDescription,
            PriseByDiscount = Convert.ToInt32(product.PriseByDiscount),
            Weight = product.Weight,
            KeyWorld = product.KeyWorld,
            Description = product.Description,
            Images = product.Images.Select(i=>ProductImageMapper.ProductImageMapper.ImageToImageDto(i)).ToList(),
            MetaTag = product.MetaTag,
            MetaTitle = product.MetaTitle,
            RelationKey = product.RelationKey,
            ProductId = product.ProductId,
            CategoryId = product.CategoryId,
            

        };
    }
}