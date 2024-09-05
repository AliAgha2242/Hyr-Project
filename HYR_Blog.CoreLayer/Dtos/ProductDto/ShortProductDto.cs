using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.ProductDto
{
    public class ShortProductDto
    {
        public string ProductName { get; set; }
        public int Prise { get; set; }
        public int? Inventory { get; set; }
        public string CategoryName { get; set; }
        public bool IsSpecial { get; set; }
        public int ProductId { get; set; }
        public int? PriseByDiscount { get; set; }
        public int? Weight { get; set; }
        public string ImageUrl { get; set; }
    }
}
