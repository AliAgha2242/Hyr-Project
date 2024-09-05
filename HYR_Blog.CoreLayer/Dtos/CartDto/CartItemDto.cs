using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.CartDto
{
    public class CartItemDto
    {
        public long CartItemId { get; set; }
        public int Price { get; set; }
        public int ProductId { get; set; }
        public bool IsDelete { get; set; }
        public int Count { get; set; }
    }
}
