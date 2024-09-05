using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.CategoryDto
{
    public class IndexCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsSpecial { get; set; }
        public string? MetaDescription { get; set; }
        public string? KeyWorld { get; set; }
    }
}
