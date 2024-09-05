using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HYR_Blog.DataLayer.Entitys
{
    public class CartItem
    {
        [Key]
        public long CartItemId { get; set; }
        [Required]
        public int Prise { get; set; }
        [Required]
        public int ProductId { get; set; }
        public bool IsDelete { get; set; } = false ;
        [Required]
        public DateTime CreationDate { get; set; }
        public int CartId { get; set; }
        #region Relation

        public virtual Product Product { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
        #endregion

    }
}
