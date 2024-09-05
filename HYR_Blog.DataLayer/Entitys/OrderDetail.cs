using System.ComponentModel.DataAnnotations;

namespace HYR_Blog.DataLayer.Entitys;

public class OrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int ProductId { get; set; }

    #region Relation

    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }  

    #endregion
}