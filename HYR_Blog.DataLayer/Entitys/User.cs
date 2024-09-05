using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HYR_Blog.DataLayer.Entitys;


public class User
{
    [Key]
    public int UserId { get; set; }
    public string? FullName { get; set; }
    [DataType(DataType.PhoneNumber)]
    [MinLength(11)]
    [MaxLength(11)]
    public string? PhoneNumber { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public int ByFromUsCount { get; set; }
    public bool IsDelete { get; set; } = false;
    public int UserRoleId { get; set; } = 3;
    public int? AddressId { get; set; }

    #region Relation
    public virtual ICollection<Order> Orders { get; set; }
    [ForeignKey("UserRoleId")]
    public virtual UserRole UserRole { get; set; }
    public virtual ICollection<Cart> Carts { get; set; }
    [ForeignKey("AddressId")]
    public virtual Address Address { get; set; }
    public virtual ICollection<Pay> RequestPays { get; set; }
    #endregion
}