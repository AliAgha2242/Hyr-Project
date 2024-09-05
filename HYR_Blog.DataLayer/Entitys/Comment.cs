using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.DataLayer.Entitys;

public class Comment
{
    [Key]
    public int CommentId { get; set; }
    [Required]
    [MinLength(50)]
    public string Description { get; set; }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    public bool IsDelete { get; set; } = false;
    [Required]
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public DateTime CreationDate { get; set; }
    public float Score { get; set; }

    #region Relation

    public virtual Product Product { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    #endregion
}