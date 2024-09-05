using HYR_Blog.CoreLayer.Dtos.ProductPropertyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.ProductDto
{
    public class MostDiscountProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? DiscountPercent { get; set; }
        public int Prise { get; set; }
        public int PriseByDiscount { get; set; }
        public string FirstImageName { get; set; }
        public List<ProductPropertyDto.ProductPropertyDto> Properties { get; set; }
        public string CategoryName { get; set; }
        public int? Inventory { get; set; }
        public string Slug { get; set; }
    }
}
