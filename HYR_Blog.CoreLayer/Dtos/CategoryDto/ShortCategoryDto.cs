using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.CategoryDto
{
    public class ShortCategoryDto
    {
        public string CategoryName { get; set; }
        public int ProductsCount { get; set; }
        public string FirstProductImage { get; set; }
    }
}
