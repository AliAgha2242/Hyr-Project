using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.UserDto
{
    public class ShowAdminUserDto
    {
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public int UserShopsCount { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public int UserRoleId { get; set; }
    }
}
