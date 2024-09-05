using HYR_Blog.CoreLayer.Dtos.UserRolesDto;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using HYR_Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Services.UserRolesService
{
    public interface IGetAllUserRolesService
    {
        MyResult<List<UserRoleDto>> GetAllUserRole(); 
    }
    public class GetAllUserRolesService : IGetAllUserRolesService
    {
        private readonly HyrDbContext _dbContext;

        public GetAllUserRolesService(HyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MyResult<List<UserRoleDto>> GetAllUserRole()
        {
            List<UserRoleDto> userRoles = _dbContext.UserRoles.AsNoTracking().Select(u=>new UserRoleDto()
            {
                UserRoleId = u.UserRoleId,
                UserRoleTitle = u.UserRoleTitle,

            }).ToList();

            return MyResult<List<UserRoleDto>>.Success(userRoles);
        }
    }
}
