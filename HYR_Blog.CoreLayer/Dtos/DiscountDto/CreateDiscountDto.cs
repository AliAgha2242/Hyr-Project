using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.DiscountDto
{
    public class CreateDiscountDto
    {
        public string DisCountCodeText { get; set; }
        public DateTime StartDate { get; set; }
        public byte LifeTimeDay { get; set; }
        public byte UseCountAllowed { get; set; }
        public int DisCountAmount { get; set; }
    }
}
