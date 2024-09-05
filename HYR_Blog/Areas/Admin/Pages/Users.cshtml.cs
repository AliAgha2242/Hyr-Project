using HYR_Blog.CoreLayer.Dtos.UserDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HYR_Blog.Areas.Admin.Pages
{
    public class UsersModel : BaseRazorModel
    {
        private readonly IScopeFacadPattern _scopeFacadPattern;

        public UsersModel(IScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }

        public SelectList UserRoles { get; set; }
        public List<ShowAdminUserDto> UserDtos { get; set; }
        public void OnGet(string? UserName , bool MostShop,int? UserRole)
        {
            
            UserDtos = _scopeFacadPattern.GetAllUsersService.GetAllUsers(MostShop,UserName,UserRole).data;

            UserRoles = new SelectList(_scopeFacadPattern.GetAllUserRolesService.GetAllUserRole()
                .data,dataTextField:"UserRoleTitle",dataValueField:"UserRoleId");
        }

        public void OnPost(int UserId , UpdateUserDto userDto)
        {
            MyResultWithoutData result = _scopeFacadPattern.UpdateUserService.UpdateUser(UserId,userDto);

            UserDtos = _scopeFacadPattern.GetAllUsersService.GetAllUsers(false , "",null).data;
            UserRoles = new SelectList(_scopeFacadPattern.GetAllUserRolesService.GetAllUserRole().data,dataTextField:"UserRoleTitle",dataValueField:"UserRoleId");
        }

    }
}
