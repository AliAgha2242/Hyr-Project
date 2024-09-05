using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.CoreLayer.Dtos.CategoryDto;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Utilities.Mapper.CategoryMapper
{
    public class CategoryMapper
    {
        public static Category CreateDtoToCategory(CreateCategoryDto cateDto)
        {
            return new Category()
            {
                CategoryName = cateDto.CategoryName,
                KeyWorld = cateDto.KeyWorld,
                MetaDescription = cateDto.MetaDescription,
                MetaTag = cateDto.MetaTag,

            };
        }

        public static CategoryDto CategoryToDto(Category category)
        {
            return new CategoryDto()
            {
                CategoryName = category.CategoryName,
                MetaTag = category.MetaTag,
                MetaDescription = category.MetaDescription,
                CategoryId = category.CategoryId,
                KeyWorld = category.KeyWorld,
                IsSpecial = category.IsSpecial,
                
            };
        }
    }
}
