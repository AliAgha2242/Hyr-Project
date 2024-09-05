using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.CoreLayer.Dtos.ProductPropertyDto;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Utilities.Mapper.ProductPropertyMapper
{
    public class ProductPropertyMapper
    {
        public static ProductPropertyDto PropertyToDto(ProductProperty productProperty)
        {
            return new ProductPropertyDto()
            {
                Key = productProperty.Key,
                ProductId = productProperty.ProductId,
                Value = productProperty.Value,
                PropertyId = productProperty.PropertyId
            };
        }

        public static ProductProperty DtoToProperty(ProductPropertyDto propertyDto)
        {
            return new ProductProperty()
            {
                Value = propertyDto.Value,
                Key = propertyDto.Key,
                ProductId = propertyDto.ProductId,
            };
        }
    }
}
