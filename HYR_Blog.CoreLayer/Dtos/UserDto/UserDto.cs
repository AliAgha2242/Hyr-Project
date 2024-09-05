using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.DataLayer.Entitys;

namespace HYR_Blog.CoreLayer.Dtos.UserDto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public string UserName { get; set; }
        public string? FullName { get; set; }
    }
}
