using HYR_Blog.CoreLayer.Dtos.UserDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern.UIFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Claims;

namespace HYR_Blog.Areas.User.Pages
{
    public class LoginModel : BaseRazorModel
    {
        private readonly IScopeFacadPattern _scopeFacadPattern;
        private readonly IUiScopeFacadPattern uiScopeFacadPattern;

        public LoginModel(IScopeFacadPattern scopeFacadPattern, IUiScopeFacadPattern uiScopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
            this.uiScopeFacadPattern = uiScopeFacadPattern;
        }

        [BindProperty]
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage = "{0} الزامی است")]
        public string UserName { get; set; }

        [BindProperty]
        [Display(Name ="کلمه عبور")]
        [Required(ErrorMessage ="{0} الزامی است")]
        public string Password { get; set; }
        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            MyResult<UserDto> result = _scopeFacadPattern.loginUserService.LoginUser(new LoginUserDto()
            {
                Password = Password,
                UserName = UserName
            });
            if(result.StatusCode == StatusCodeEnum.Failed)
                return Failed(result,Page());

            if(result.StatusCode == StatusCodeEnum.NotFound)
                return NotFound(result,Page());


            IEnumerable<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, result.data.UserId.ToString()),
                new Claim(ClaimTypes.Name , result.data.UserName),
                new Claim("FullName" , result.data.FullName.ToString()),
                new Claim(ClaimTypes.Role,result.data.UserRole),
            };
            
            ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(principal,new AuthenticationProperties()
            {
                IsPersistent = true,
            });




            var SetCartOnUserId = uiScopeFacadPattern.EditUserIdInCartService.
                EditUserInCart(Request.Cookies["HyrCart"],result.data.UserId);




            return Success(result,Redirect("/"));
        }
    }
}
