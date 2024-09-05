using HYR_Blog.CoreLayer.Services.FileManageServices;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Services.ProductImageService.Commands;

public interface IDeleteImageService
{
    MyResultWithoutData DeleteImage(int ImageId);
}
public class DeleteImageService:IDeleteImageService
{
    private readonly HyrDbContext _context;
    private readonly IFileManageService _fileManageService;

    public DeleteImageService(HyrDbContext context,IFileManageService fileManageService)
    {
        _context = context;
        _fileManageService = fileManageService;
    }
    public MyResultWithoutData DeleteImage(int ImageId)
    {

        bool IsExists = _context.Images.Any(i => i.ImageId == ImageId);
        if(!IsExists)
            return MyResultWithoutData.NotFound(StatusMessage:"تصویر یافت نشد خطا در سمت سرور");

        ProductImage removeImage = _context.Images.Find(ImageId);

        MyResultWithoutData result = _fileManageService.RemoveImageFile(removeImage.ImageDirectory);

        if(result.StatusCode == StatusCodeEnum.NotFound)
            return MyResultWithoutData.Failed(StatusMessage:"تصویر یافت نشد و یا قبلا حذف شده");

        _context.Images.Remove(removeImage);
        _context.SaveChanges();
        return MyResultWithoutData.Success();
    }
} 