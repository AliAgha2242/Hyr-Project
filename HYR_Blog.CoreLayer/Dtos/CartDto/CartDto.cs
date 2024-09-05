using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.CartDto
{
    public class CartDto
    {
        public List<CartItemDto> CartItems { get; set; }
        public int TotalPrise { get; set; }

    }

}
