using HYR_Blog.CoreLayer.Dtos.ImageProductDto;
using HYR_Blog.CoreLayer.Services.FileManageServices;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.Other.Directories;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Services.ProductImageService.Commands;

public interface IAddProductImageService
{
    MyResultWithoutData AddProductImage(CreateProductImageDto imageProductDto);
}
public class AddProductImageService : IAddProductImageService
{
    private readonly HyrDbContext _context;
    private readonly IFileManageService _fileManageService;

    public AddProductImageService(HyrDbContext context, IFileManageService fileManageService)
    {
        _context = context;
        _fileManageService = fileManageService;
    }

    public MyResultWithoutData AddProductImage(CreateProductImageDto imageProductDto)
    {
        if (_context.Images.Count(p=>p.ProductId == imageProductDto.ProductId) >= 5)
            return MyResultWithoutData.Failed(StatusMessage:"تعداد تصاویر بیشتر از حد محاز است");


        if(imageProductDto.ProductId == null || imageProductDto.File == null)
            return MyResultWithoutData.Failed();

        Tuple<string , string> resultSaveFile = _fileManageService.AddImage(PathManager.ProductImagePath, imageProductDto.File);

        ProductImage image = new ProductImage()
        {
            ProductId = imageProductDto.ProductId,
            ImageName = resultSaveFile.Item2,
            ImageDirectory = resultSaveFile.Item1
        };
        _context.Images.Add(image);
        _context.SaveChanges();

        return MyResultWithoutData.Success();
    }
}
