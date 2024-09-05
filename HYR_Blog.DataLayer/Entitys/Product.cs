using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace HYR_Blog.DataLayer.Entitys
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(10)]
        public string ProductName { get; set; }
        [MinLength(50)]
        public string Description { get; set; }
        [MaxLength(25)]
        [Required]
        public string ProductCode { get; set; }
        [Required]
        [Range(minimum: 1000, maximum: int.MaxValue)]
        public int Prise { get; set; }

        [Range(10, 10000)]
        public int? Weight { get; set; } = 500;
        [Required]
        public int Visit { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public float Score { get; set; } = 5;
        [Required]
        [MinLength(10)]
        public string Slug { get; set; }
        [Required]
        public bool IsDelete { get; set; } = false;
        public bool IsSpecial { get; set; } = false;
        public string? MetaTag { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        public string? KeyWorld { get; set; }
        public string? RelationKey { get; set; }
        public int? Inventory { get; set; } = 10;
        [Range(1000, int.MaxValue)]
        public int? PriseByDiscount { get; set; }
        public int CategoryId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int SellCount { get; set; }
        #region Relation
        public virtual ICollection<ProductProperty> Properties { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual Category Category { get; set; }
        #endregion
    }
}
