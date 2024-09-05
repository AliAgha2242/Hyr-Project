using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.DataLayer.Entitys
{
    public class Pay
    {
        [Key]
        public Guid RequestPayId { get; set; }
        public bool IsPay { get; set; } = false;
        public long? RefId { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int TotalPrise { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? Authority { get; set; }


        #region Relation
        public virtual User User { get; set; }
        public virtual Cart Cart { get; set; }
        #endregion

    }
}
