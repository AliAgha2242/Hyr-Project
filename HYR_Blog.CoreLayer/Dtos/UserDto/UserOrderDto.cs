using HYR_Blog.CoreLayer.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.UserDto
{
    public class UserOrderDto
    {
        public string UserName { get; set; }
        public string SerialNumber { get; set; }
        public List<OrderProductDto> Items { get; set; }
        public string SendCode { get; set; }
        public string OrderStatus { get; set; }
        public string Transporrtation { get; set; }
    }
}
