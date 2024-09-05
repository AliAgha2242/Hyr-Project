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
    public interface IRegisterUserService
    {
        MyResultWithoutData RegisterUser(RegisterUserDto userDto);
    }
    public class RegisterUserService : IRegisterUserService
    {
        private readonly HyrDbContext _dbContext;
        public RegisterUserService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResultWithoutData RegisterUser(RegisterUserDto userDto)
        {
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.UserName)||string.IsNullOrEmpty(userDto.Password))
                return MyResultWithoutData.Failed(StatusMessage:"خطا سمت سرور فیلد خالی است");
            _dbContext.Users.Add(new User()
            {
                Password = PasswordHelper.EncodePasswordToBase64(userDto.Password),
                UserName = userDto.UserName,
            });
            _dbContext.SaveChanges();
            return MyResultWithoutData.Success();
        }
    }
}
