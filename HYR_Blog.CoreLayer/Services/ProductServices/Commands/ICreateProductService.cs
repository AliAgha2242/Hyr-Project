
using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Services.FileManageServices;
using HYR_Blog.CoreLayer.Utilities.Mapper.ProductPropertyMapper;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.Other;
using HYR_Blog.CoreLayer.Utilities.Other.Directories;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.AspNetCore.Http;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Commands
{
    public interface ICreateProductService
    {
        MyResultWithoutData CreateProduct(CreateProductDto productDto);
    }
    public class CreateProductService : ICreateProductService
    {
        private readonly HyrDbContext _dbContext;
        private readonly IFileManageService _fileManageService;

        public CreateProductService(HyrDbContext dbContext, IFileManageService fileManageService)
        {
            _dbContext = dbContext;
            _fileManageService = fileManageService;
        }


        //slug Generate

        private string CeateSlugProduct(string productCode, string productName)
        {

            productName = productName.Replace("!", "-");
            productName = productName.Replace("@", "-");
            productName = productName.Replace("#", "-");
            productName = productName.Replace("$", "-");
            productName = productName.Replace("%", "-");
            productName = productName.Replace("^", "-");
            productName = productName.Replace("&", "-");
            productName = productName.Replace("*", "-");
            productName = productName.Replace("(", "-");
            productName = productName.Replace(")", "-");
            productName = productName.Replace("_", "-");
            productName = productName.Replace(" ", "-");
            productName = productName.Replace("\'", "-");
            productName = productName.Replace("\"", "-");
            return productCode + productName;
        }

        public MyResultWithoutData CreateProduct(CreateProductDto productDto)
        {
            Random RandomNumber = new Random();
            int ProductCode = RandomNumber.Next(10000, 100000);


            if (productDto.Files == null)
                return MyResultWithoutData.Failed(StatusMessage: " ارسال تصاویر ناموفق");

            if (_dbContext.Products.Any(p => p.ProductName == productDto.ProductName))
                return MyResultWithoutData.Duplicate();



            var a = _dbContext.Products.Select(p => p.ProductCode).ToList();


            Product newProduct = new Product()
            {
                MetaDescription = productDto.MetaDescription,
                MetaTag = productDto.MetaTag,
                ProductName = productDto.ProductName,
                KeyWorld = productDto.KeyWorld,
                Category = _dbContext.Categories.First(c => c.CategoryId == productDto.CategoryId),
                Description = productDto.Description,
                Inventory = productDto.Inventory,
                IsSpecial = productDto.IsSpecial,
                Prise = productDto.Prise,
                ProductCode =
                    GenerateRandomProductCode.RandomNumberForProductCode(_dbContext.Products.Select(p => p.ProductCode).ToList(),
                        10000, 100000),
                Properties = productDto.ProductPropertyDtos.Select(p => ProductPropertyMapper.DtoToProperty(p)).ToList(),
                RelationKey = productDto.RelationKey,
                Weight = productDto.Weight,
                CategoryId = productDto.CategoryId,
                MetaTitle = productDto.MetaTitle,
                PriseByDiscount = productDto.PriseByDiscount,

            };

            newProduct.Slug = CeateSlugProduct(newProduct.ProductCode,
                newProduct.ProductName);



            List<ProductImage> images = new List<ProductImage>();
            foreach (IFormFile item in productDto.Files)
            {
                var result = _fileManageService.AddImage(PathManager.ProductImagePath, item);
                images.Add(new ProductImage()
                {
                    ImageName = result.Item2,
                    ImageDirectory = result.Item1,
                    ProductId = newProduct.ProductId,
                    Product = newProduct
                });
            }




            _dbContext.Products.Add(newProduct);
            _dbContext.Images.AddRange(images);
            _dbContext.SaveChanges();
            return MyResultWithoutData.Success();
        }
    }
}
