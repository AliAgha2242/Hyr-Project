using HYR_Blog.CoreLayer.Dtos.UserDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.UserUtilities;
using HYR_Blog.DataLayer.Context;
using HYR_Blog.DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.UserService.Queries
{
    public interface ILoginUserService
    {
        MyResult<UserDto> LoginUser(LoginUserDto userDto);
    }
    public class LoginUserService : ILoginUserService
    {
        private readonly HyrDbContext _dbContext;
        public LoginUserService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyResult<UserDto> LoginUser(LoginUserDto userDto)
        {
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.UserName) || string.IsNullOrWhiteSpace(userDto.Password))
                return MyResult<UserDto>.Failed(new UserDto(), StatusMessage: "خطای سرور فیلد ها خالی میباشد");


            User? user = _dbContext.Users.Include(u => u.UserRole)
                .FirstOrDefault(u => u.UserName == userDto.UserName);

            if (user == null)
                return MyResult<UserDto>.NotFound(new UserDto(), StatusMessage: "نام کاربری یا رمز عبور صحیح نست");

            if (PasswordHelper.DecodeFrom64(user.Password) != userDto.Password)
                return MyResult<UserDto>.NotFound(new UserDto(), StatusMessage: "نام کاربری یا رمز عبور صحیح نست");



            return MyResult<UserDto>.Success(new UserDto()
            {
                FullName = user.FullName ?? "",
                UserId = user.UserId,
                UserName = user.UserName,
                UserRole = user.UserRole.UserRoleTitle,
            });
        }
    }
}
