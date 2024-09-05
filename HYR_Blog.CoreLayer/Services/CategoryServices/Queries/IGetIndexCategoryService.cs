using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.CategoryServices.Queries
{
    public interface IGetIndexCategoryService
    {
        MyResult<List<IndexCategoryDto>> GetCategory();
    }
    public class GetIndexCategoryService : IGetIndexCategoryService
    {
        private readonly HyrDbContext _hyrDbContext;
        public GetIndexCategoryService(HyrDbContext hyrDbContext)
        {
            _hyrDbContext = hyrDbContext;
        }
        public MyResult<List<IndexCategoryDto>> GetCategory()
        {
            List<IndexCategoryDto> result = _hyrDbContext.Categories.
                Select(c=>new IndexCategoryDto()
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    IsSpecial = c.IsSpecial,
                    KeyWorld = c.KeyWorld,
                    MetaDescription = c.MetaDescription
                }).ToList();
            return MyResult<List<IndexCategoryDto>>.Success(result);
        }
    }
}
