using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.ProductDto
{
    public class DiscountProductDto
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string FirstImageName { get; set; }
        public int PriseByDiscount { get; set; }
        public string Slug { get; set; }
    }
}
