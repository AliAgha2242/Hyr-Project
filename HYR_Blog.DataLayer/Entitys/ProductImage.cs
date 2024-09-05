using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.DataLayer.Entitys
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public string ImageDirectory { get; set; }
        public int ProductId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        #region relation
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        #endregion
    }
}
