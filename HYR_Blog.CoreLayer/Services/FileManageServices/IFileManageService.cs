using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace HYR_Blog.CoreLayer.Services.FileManageServices;

public interface IFileManageService
{
    Tuple<string , string> AddImage(string Path , IFormFile file);
    MyResultWithoutData RemoveImageFile(string RouteFile);
}

public class FileManageService : IFileManageService
{
    private readonly IHostEnvironment env;

    public FileManageService(IHostEnvironment env)
    {
        this.env = env;
    }

    public Tuple<string , string> AddImage(string path, IFormFile file)
    {
        string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), path.Replace("/", "\\"));
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

        string FullName = Guid.NewGuid() + file.FileName;
        string FullPath = Path.Combine(FolderPath, FullName);
        using Stream stream = new FileStream(FullPath, FileMode.Create);
        file.CopyTo(stream);
        return new Tuple<string, string>(FullPath , FullName);
    }

    public MyResultWithoutData RemoveImageFile(string RouteFile)
    {
        if (File.Exists(RouteFile))
        {
            File.Delete(RouteFile);
            return MyResultWithoutData.Success();
        }

        return MyResultWithoutData.NotFound();
    }
}