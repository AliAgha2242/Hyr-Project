using HYR_Blog.DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.CartDto
{
    public class CartDetailDto
    {
        public int TotalPrise { get; set; }
        public List<TransportationDto> transportations { get; set; }
        public int TotalWeight { get; set; }
        public int TotalPriseWithTransportation { get; set; }
    }
}
