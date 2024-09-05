using Microsoft.AspNetCore.Http;

namespace HYR_Blog.CoreLayer.Dtos.ImageProductDto;

public class CreateProductImageDto
{
    public IFormFile File { get; set; }
    public int ProductId { get; set; }
}