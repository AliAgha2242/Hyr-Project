using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HYR_Blog.DataLayer.Entitys;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    [Range(10000 , int.MaxValue)]
    [Required]
    public string SerialNumber { get; set; }

    [Required]
    public int UserId { get; set; }

    [MinLength(24)]
    [MaxLength(24)]
    //[RegularExpression("[1-10]")]
    public string? SendCode { get; set; }
    [Required]
    public DateTime CreationDate { get; set;}
    [Required]
    public int SumPrise { get; set; }
    [Required]
    public int OrderStatusId { get; set; }
    [Required]
    public bool IsDelete { get; set; } = false;
    public int? DiscountCodeId { get; set; }
    public int TransportationId { get; set; }

    #region Relation
    public virtual User User { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public virtual OrderStatus OrderStatus { get; set; }
    public virtual DiscountCode DiscountCode { get; set; }
    [ForeignKey("TransportationId")]
    public virtual Transportation Transportation { get; set; }

    #endregion



}