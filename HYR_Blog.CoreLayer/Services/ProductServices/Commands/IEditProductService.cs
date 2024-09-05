using System.Runtime.Serialization.Formatters;
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Services.FileManageServices;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductPropertyMapper;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.Other.Directories;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Commands;

public interface IEditProductService
{
    MyResultWithoutData EditProduct(EditProductDto productDto);
}
public class EditProductService : IEditProductService
{
    private readonly HyrDbContext _dbContext;
    private readonly IFileManageService _fileManageService;
    public EditProductService(HyrDbContext dbContext, IFileManageService fileManageService)
    {
        _dbContext = dbContext;
        _fileManageService = fileManageService;
    }
    public MyResultWithoutData EditProduct(EditProductDto productDto)
    {
        if (productDto == null)
            return MyResultWithoutData.Failed(StatusMessage: "خطا در سمت سرور");
        Product product = _dbContext.Products.FirstOrDefault(p => p.ProductId == productDto.ProductId);

        if (product == null)
            return MyResultWithoutData.NotFound();

        product.CategoryId = productDto.CategoryId;
        product.IsSpecial = productDto.IsSpecial;
        product.Description = productDto.Description;
        product.Inventory = productDto.Inventory;
        product.KeyWorld = productDto.KeyWorld;
        product.MetaDescription = productDto.MetaDescription;
        product.MetaTag = productDto.MetaTag;
        product.MetaTitle = productDto.MetaTitle;
        product.Prise = productDto.Prise;
        product.PriseByDiscount = productDto.PriseByDiscount;
        product.ProductName = productDto.ProductName;
        product.Weight = productDto.Weight;
        product.RelationKey = productDto.RelationKey;
        product.LastUpdate = DateTime.Now;

        _dbContext.SaveChanges();

        return MyResultWithoutData.Success();

    }
}
