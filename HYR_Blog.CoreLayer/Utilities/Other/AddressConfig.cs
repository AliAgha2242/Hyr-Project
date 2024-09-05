using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Utilities.Other
{
    public static class AddressConfig
    {
        public static string FullAddress(string State , string City , string ContinueAddress)
        {
            return $"{State} - {City} - {ContinueAddress}" ;
        }
    }
}
