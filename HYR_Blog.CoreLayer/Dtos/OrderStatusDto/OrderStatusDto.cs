using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.OrderStatusDto
{
    public class OrderStatusDto
    {
        public int OrderStatusId { get; set; }
        public string OrderStatusTitle { get; set; }
        public int OrderStatusPriority { get; set; }
    }
}
