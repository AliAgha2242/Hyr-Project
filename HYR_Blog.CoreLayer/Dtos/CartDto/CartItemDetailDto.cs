using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.CartDto
{
    public class CartItemDetailDto
    {
        public long CartItemId { get; set; }
        public string FirstImageProduct { get; set; }
        public int Count { get; set; }
        public int Prise { get; set; }
        public int TotalPrise { get; set; }
        public int ProductId { get; set; }
        public int? Weight { get; set; }
        public string ProductName { get; set; }
        public int Inventory { get; set; }
        public string Slug { get; set; }
    }
}
