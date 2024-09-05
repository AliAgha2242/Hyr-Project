using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.ProductDto
{
    public class FilterParams
    {
        public string? Productname  { get; set; }
        public int? CategoryId { get; set; }
        public int PageId { get; set; }
        public int? Ordering { get; set; }
    }
}
