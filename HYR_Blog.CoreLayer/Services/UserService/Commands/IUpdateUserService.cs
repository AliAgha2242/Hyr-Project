using HYR_Blog.CoreLayer.Dtos.UserDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.UserUtilities;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.UserService.Commands
{
    public interface IUpdateUserService
    {
        MyResultWithoutData UpdateUser(int UserId , UpdateUserDto userdto);
    }
    public class UpdateUserService : IUpdateUserService
    {
        private readonly HyrDbContext _dbContext;

        public UpdateUserService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MyResultWithoutData UpdateUser(int UserId ,UpdateUserDto userdto )
        {
            User? user = _dbContext.Users.Find(UserId);
            if (user == null) 
                return MyResultWithoutData.NotFound(StatusMessage:"کاربر یافت نشد");

            user.UserRoleId = userdto.UserRoleId;
            user.UserName = userdto.UserName;
            user.Password = PasswordHelper.EncodePasswordToBase64(userdto.Password);
                

            _dbContext.SaveChanges();
            return MyResultWithoutData.Success();
        }
    }
}
