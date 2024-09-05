using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.ProductDto
{
    public class SearchFilterProductDto
    {
        public int ProductId { get; set; }
        public float Score { get; set; }
        public string ProductName { get; set; }
        public string ProductFirstImageName { get; set; }
        public int Prise { get; set; }
        public int PriseByDiscount { get; set; }
        public string Slug { get; set; }

    }
}
