using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.DataLayer.Entitys
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        [MaxLength(40)]
        public string State { get; set; }
        [Required]
        [MaxLength(40)]
        public string City { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        public int UserId { get; set; }
        [Required]
        [MinLength(40)]
        public string ContinueAddress { get; set; }

        #region Relation
        [ForeignKey("UserId")]

        public virtual User User { get; set; }
        #endregion

    }
}
