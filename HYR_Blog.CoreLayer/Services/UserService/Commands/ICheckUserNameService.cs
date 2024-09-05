using HYR_Blog.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.UserService.Commands
{
    public interface ICheckUserNameService
    {
       bool CheckUserName(string userName);
    }

    public class CheckUserNameService : ICheckUserNameService
    {
        private readonly HyrDbContext _dbContext;
        public CheckUserNameService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CheckUserName(string userName)
        {
            bool result = _dbContext.Users.Any(u => u.UserName == userName);
            return !result;
        }
    }
}
