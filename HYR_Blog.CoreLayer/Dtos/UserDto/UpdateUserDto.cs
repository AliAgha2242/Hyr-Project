using HYR_Blog.DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Dtos.UserDto
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }
        public int UserRoleId { get; set; }
        public string Password { get; set; }
    }
}
