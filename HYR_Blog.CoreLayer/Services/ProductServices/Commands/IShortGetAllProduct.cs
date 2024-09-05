using System.Reflection.Metadata.Ecma335;
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities;
using HYR_Blog.CoreLayer.Utilities.FilterResult;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductMapper;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductPropertyMapper;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Commands;

public interface IShortGetAllProduct
{
    MyResult<List<ShortProductDto>> GetAllProduct(int? CategoryId = null, int? Prise = null, string? ProductName = null);
}
public class ShortGetAllProduct : IShortGetAllProduct
{
    private readonly HyrDbContext _dbContext;

    public ShortGetAllProduct(HyrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public MyResult<List<ShortProductDto>> GetAllProduct(int? CategoryId = null, int? Prise = null, string? ProductName = null)
    {
        IQueryable<Product> Products = _dbContext.Products.AsNoTracking().AsQueryable()
            .Include(p => p.Category)
            .Include(p => p.Images);


        if (!string.IsNullOrWhiteSpace(ProductName))
            Products = Products.Where(p => p.ProductName.Contains(ProductName));

        if (CategoryId != null)
            Products = Products.Where(_ => _.CategoryId == CategoryId);



        if (Prise == 1)
            Products = Products.OrderBy(p => p.Prise);
        if (Prise == 2)
            Products = Products.OrderByDescending(p => p.Prise);




        List<ShortProductDto> productDto = Products.Select(p => ProductMapper.ProductToShProDto(p)).ToList();


        if (Products == null)
            return MyResult<List<ShortProductDto>>.NotFound(new List<ShortProductDto>(), "هیچ محصولی یافت نشد", "محصولی با مشخصات فوق یافت نشد");
        return MyResult<List<ShortProductDto>>.Success(data: productDto);


    }
}


