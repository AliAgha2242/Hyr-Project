namespace HYR_Blog.CoreLayer.Utilities.Other.Directories;

public static class PathManager
{
    public static string ProductImagePath = "wwwroot/images/posts";
}

public class FileManage
{
    public static string GetProductImageByName(string ImageName = "")
    {
        return $"{PathManager.ProductImagePath}/{ImageName}".Replace("wwwroot","");
    }
}