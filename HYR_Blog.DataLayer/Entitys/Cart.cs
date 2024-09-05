using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.DataLayer.Entitys
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public bool IsFinish { get; set; } = false;

        public int? UserId { get; set; }
        [Required]
        public string CartCode { get; set; }
        [Required]
        public int TransportationId { get; set; }
        public int TotalPrise { get; set; }
        
        public Guid? RequestPayId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        #region Relation
        public virtual ICollection<CartItem> CartItems { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual Transportation Transportation { get; set; }
        public virtual Pay Pay { get; set; }

        #endregion
    }
}
