using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Utilities.TransportationHelp
{
    public static class TranspotationHelps
    {
        public static int? ConfigTransportationPrise(int? TotalWeight = 1000 , int? InitialPriseTransportation = 30000 , int? PrisePerKg = 10000)
        {
            TotalWeight = TotalWeight / 1000 ;
            if (TotalWeight <= 1)
                return InitialPriseTransportation;
            TotalWeight = Convert.ToInt32(Math.Ceiling((decimal)TotalWeight)) - 1;
            return InitialPriseTransportation + (TotalWeight *  PrisePerKg);
        }
    }
}
