using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.ProductDto
{
    public class OrderProductDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string FirstImageName { get; set; }
        public int Prise { get; set; }
        public int Count { get; set; }
    }
}
