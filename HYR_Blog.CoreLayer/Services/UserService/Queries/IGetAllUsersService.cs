using HYR_Blog.CoreLayer.Dtos.UserDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.CoreLayer.Utilities.UserUtilities;
using HYR_Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.UserService.Queries
{
    public interface IGetAllUsersService
    {
        MyResult<List<ShowAdminUserDto>> GetAllUsers(bool MostShop , string? UserName,int? UserRole);
    }
    public class GetAllUsersService : IGetAllUsersService
    {
        private readonly HyrDbContext _dbContext;

        public GetAllUsersService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MyResult<List<ShowAdminUserDto>> GetAllUsers(bool MostShop, string? UserName , int? UserRole)
        {
            var users = _dbContext.Users.Include(user=>user.UserRole).Include(U=>U.Orders).AsNoTracking();
            if(!string.IsNullOrWhiteSpace(UserName))
                users = users.Where(u=>u.UserName.Contains(UserName));


            if(UserRole != null)
                users = users.Where(u=>u.UserRoleId == UserRole);




            if(MostShop)
                users.OrderByDescending(u=>u.Orders.Count());

            List<ShowAdminUserDto> userdtos = users.Select(u => new ShowAdminUserDto()
            {
                UserId = u.UserId,
                UserPassword = PasswordHelper.DecodeFrom64(u.Password),
                UserRole = u.UserRole.UserRoleTitle,
                UserShopsCount = u.Orders.Count(),
                UserName = u.UserName,
                UserRoleId = u.UserRoleId,

            }).ToList();

            return MyResult<List<ShowAdminUserDto>>.Success(userdtos);
        }
    }
}
