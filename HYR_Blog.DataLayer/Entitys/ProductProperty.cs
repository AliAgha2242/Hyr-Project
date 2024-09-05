using System.ComponentModel.DataAnnotations;

namespace HYR_Blog.DataLayer.Entitys;

public class ProductProperty
{
    [Key]
    public int PropertyId { get; set; }
    [Required]
    public string Key { get; set; }
    [Required]
    public bool IsDelete { get; set; } = false;
    [Required]
    public string Value { get; set; }
    public int ProductId { get; set; }

    #region Relation
    public Product Product { get; set; }

    #endregion
}