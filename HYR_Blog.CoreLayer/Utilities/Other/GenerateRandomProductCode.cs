using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Utilities.Other
{
    public class GenerateRandomProductCode
    {
        private static readonly Random random = new Random();

        
        public  static string RandomNumberForProductCode(List<string> ProductCodes, int CategoryId, int ProductId)
        {
            var rand = random.Next(100,10000);
            string returnVarible = "Cid"+CategoryId+"Pid"+ProductId+rand.ToString();
            foreach (var item in ProductCodes)
            {
                if (returnVarible == item)
                {
                    GenerateRandomProductCode.RandomNumberForProductCode(ProductCodes, 100, 10000);
                }
            }
            return returnVarible;
        }
    }
}
