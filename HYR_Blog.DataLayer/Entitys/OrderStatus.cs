using System.ComponentModel.DataAnnotations;

namespace HYR_Blog.DataLayer.Entitys;

public class OrderStatus
{
    [Key]
    public int StatusId { get; set; }
    [Required]
    public string StatusTitle { get; set; }
    [Required]
    public int Priority { get; set; }

    #region Relation

    public virtual ICollection<Order> Orders { get; set; }

    #endregion
}




public static class OrderStatusTitle
{
    public static string Finalized { get; set; } = "نهایی";
    public static string Accepted { get; set; } = "پذیرفته شده";
    public static string Canceled { get; set; } = "لغو شده";
    public static string NewOrder { get; set; } = "سفارش جدید";
    public static string Posted { get; set; } = "ارسال شده";

}