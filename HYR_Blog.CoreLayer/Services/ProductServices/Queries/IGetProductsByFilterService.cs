using HYR_Blog.CoreLayer.Dtos.ProductDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.ProductServices.Queries
{
    public interface IGetProductsByFilterService
    {
        MyResult<SearchProductResultDto> GetProductByFilter(FilterParams filterParams);
    }
    public class GetProductsByFilterService : IGetProductsByFilterService
    {
        private readonly HyrDbContext _dbContext;

        public GetProductsByFilterService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MyResult<SearchProductResultDto> GetProductByFilter(FilterParams filterParams)
        {

            var products = _dbContext.Products.AsNoTracking();
            var RelationProducts = _dbContext.Products.AsNoTracking();





            #region Ordering And Find Products


            if (!string.IsNullOrWhiteSpace(filterParams.Productname))
                products = products.Where(p => p.ProductName.Contains(filterParams.Productname));

            if (filterParams.CategoryId != null)
                products = products.Where(p => p.CategoryId == filterParams.CategoryId);

            if (filterParams.Ordering != 0)
                products = Ordering(products, filterParams.Ordering);


            #endregion

            #region Pagnation code
            int Take = 8;

            int Skip = (filterParams.PageId - 1) * Take;

            int Count = Convert.ToInt32(Math.Round((Decimal)(products.Count() / Take)));

            int MaxPagination = filterParams.PageId + 5;
            #endregion

            #region Generate ResultClass

            SearchProductResultDto result = new SearchProductResultDto();

            //products For Show
            result.Products = products.Select(p => new SearchFilterProductDto()
            {
                Prise = p.Prise,
                PriseByDiscount = Convert.ToInt32(p.PriseByDiscount),
                ProductFirstImageName = p.Images.First().ImageName,
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Score = p.Score,
                Slug = p.Slug,
            }).Skip(Skip).Take(Take).ToList();

            result.Pagination = new PaginationResult()
            {
                Count = Count,
                MaxPaginationValue = MaxPagination,
                MinPaginationValue = filterParams.PageId,
            };

            #endregion

            if (products != null && products.Count() > 0)
            {
                foreach (var product in products)
                {
                    if(product.RelationKey == null)
                        continue ;
                    string[] RelationString = configRealtionKey(product.RelationKey);
                    foreach (var str in RelationString)
                    {
                        RelationProducts.Append(product);
                    }
                }

            }

            RelationProducts = RelationProducts.Except(products);

            result.RelatedProduct = RelationProducts.Take(8).Select(p => new ReLatedProductDto()
            {
                Prise = p.Prise,
                PriseByDiscount = Convert.ToInt32(p.PriseByDiscount),
                ProductFirstImageName = p.Images.First().ImageName,
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Score = p.Score,
                Slug = p.Slug

            }).ToList();




            return MyResult<SearchProductResultDto>.Success(result);
        }


        private IQueryable<Product> Ordering(IQueryable<Product> products, int? OrderBy)
        {
            if (OrderBy == null)
                return products;


            switch (OrderBy)
            {
                case 1:
                    products = products.OrderByDescending(p => p.Visit);
                    break;
                case 2:
                    products = products.OrderByDescending(p => p.SellCount);
                    break;
                case 3:
                    products = products.OrderByDescending(p => p.Score);
                    break;
                case 4:
                    products = products.OrderByDescending(p => p.CreationDate);
                    break;
                case 5:
                    products = products.OrderBy(p => p.Prise);
                    break;
                case 6:
                    products = products.OrderByDescending(p => p.Prise);
                    break;
                default:
                    break;
            }
            return products;
        }
        private string[] configRealtionKey(string key)
        {
            string[] relationKeyArray = new string[5];
            string PerWorld = "";

            foreach (var character in key)
            {

                if (character == '-' || character == ' ')
                {
                    if (relationKeyArray.Count() == 5)
                        break;

                    relationKeyArray.Append(PerWorld);
                    PerWorld = "";
                    continue;
                }
                PerWorld = PerWorld + character;


            }

            return relationKeyArray;
        }

    }
}
