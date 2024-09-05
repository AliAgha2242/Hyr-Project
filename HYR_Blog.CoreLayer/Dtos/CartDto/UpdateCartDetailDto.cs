using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.CartDto
{
    public class UpdateCartDetailDto
    {
        public string DiscountCode { get; set; }
        public int TotalPriseWithTransportationPriseAndDiscount { get; set; }
        public string? CartCode { get; set; }
        public int? UserId { get; set; }
        public int TransportationId { get; set; }
    }
}
