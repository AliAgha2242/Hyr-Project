using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Queries
{
    public interface IGetSingleProductService
    {
       MyResult<SingleProductDto> GetSingleProduct(string? slug);
    }
    public class GetSingleProductService : IGetSingleProductService
    {
        private readonly HyrDbContext _context ;
        public GetSingleProductService(HyrDbContext context)
        {
            _context = context;
        }
        public MyResult<SingleProductDto> GetSingleProduct(string? slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                return MyResult<SingleProductDto>.Failed(null,StatusMessage:"خطای سمت سرور . فیلد ها خالی است");

            if(!_context.Products.Any(p=>p.Slug == slug))
                return MyResult<SingleProductDto>.NotFound(null,StatusMessage:"محصول یافت نشد");


            Product product =  _context.Products
                .Include(p => p.Images)
                .Include(p => p.Properties)
                .Include(p => p.Category)
                .Include(p => p.Comments).ThenInclude(co=>co.User)
                .First(p=>p.Slug == slug);
            SingleProductDto singleProductDto = new SingleProductDto()
            {
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,


                //comment Map
                Comments = product.Comments.Select(co=>new Dtos.CommentDtos.CommentDto()
                {
                    CreationDate = co.CreationDate,
                    Description = co.Description,
                    Score = co.Score,
                    Title = co.Title,
                    UserName = co.User.UserName,
                }).ToList(),
                Description = product.Description,
                ImagesName = product.Images.Select(im=>new string(im.ImageName)).ToList(),
                Inventory = product.Inventory,
                KeyWorld = product.KeyWorld,
                MetaDescription = product.MetaDescription,
                MetaTAg = product.MetaTag,
                MetaTitle = product.MetaTitle,
                Prise = product.PriseByDiscount??product.Prise,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Slug = product.Slug,


                //Properties Map
                Properties = product.Properties.Select(pr=>new Dtos.ProductPropertyDto.ProductPropertyDto()
                {
                    Key = pr.Key,
                    Value = pr.Value,
                }).ToList(),

                Score = product.Score,
                Visit = product.Visit,
                ProductCode = product.ProductCode,
            };



            return MyResult<SingleProductDto>.Success(singleProductDto);

        }
    }
}
