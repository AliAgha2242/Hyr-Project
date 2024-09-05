using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.DataLayer.Entitys
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(40)]
        public string CategoryName { get; set; }
        public string? MetaTag { get; set; }
        public string? MetaDescription { get; set; }
        public string? KeyWorld { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        public bool IsDelete { get; set; } = false;
        [Required]
        public bool IsSpecial { get; set;} = false;

        #region Relation

        public virtual ICollection<Product> Products { get; set; }

        #endregion

    }
}
