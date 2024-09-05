using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Utilities.Other
{
    public class DiscountCodeGenerate
    {
        public static Random random  = new Random();
        public static string GenerateCode()
        {
            string Chars = "qwertyuioplkjhgfdsaxzcvbnm1234567890";
            StringBuilder Code = new StringBuilder();
            Code.Length = 15 ;
            for (int i = 0; i < 15; i++)
            {
                Code[i] = Chars[random.Next(0,25)];
            }
            int HYRValid = random.Next(0 , 15);
            Code[HYRValid] = 'H';
            Code[HYRValid+1] = 'Y';
            Code[HYRValid+2] = 'R';

            return Code.ToString();
        }
    }
}
