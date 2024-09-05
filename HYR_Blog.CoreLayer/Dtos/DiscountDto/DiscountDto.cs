using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.DiscountDto
{
    public class DiscountDto
    {
        public int DiscountCodeId { get; set; }
        public string DiscountText { get; set; }
        public string EndDate { get; set; }
         public byte UseCountAllowed { get; set; }
        public byte UseCount { get; set; }
        public int DisCountAmount { get; set; }
    }
}
