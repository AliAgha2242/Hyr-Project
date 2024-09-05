using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.DataLayer.Entitys
{
    public class DiscountCode
    {
        [Key]
        public int DiscountCodeId { get; set; }
        [Range(10,10)]
        public string DisCountCodeText { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public byte LifeTimeDay { get; set; }
        public DateTime EndDate { get; set; }
        public byte UseCountAllowed { get; set; }= 1 ;
        public byte UseCount { get; set; } = 0 ;
        public int DisCountAmount { get; set; }
        #region Relation
        public virtual ICollection<Order> Orders { get; set; }
        #endregion
    }
}
