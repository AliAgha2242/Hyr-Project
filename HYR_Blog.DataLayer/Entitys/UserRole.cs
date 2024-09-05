using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.DataLayer.Entitys
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        [Required]
        public string UserRoleTitle { get; set; }
    }
}
