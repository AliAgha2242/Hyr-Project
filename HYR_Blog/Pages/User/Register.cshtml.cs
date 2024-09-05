using HYR_Blog.CoreLayer.Dtos.UserDto;
using HYR_Blog.CoreLayer.FacadPattern.IFacadPattern;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HYR_Blog.Areas.User.Pages
{
    public class RegisterModel : BaseRazorModel
    {
        private readonly IScopeFacadPattern _scopeFacadPattern;
        public RegisterModel( IScopeFacadPattern scopeFacadPattern)
        {
            _scopeFacadPattern = scopeFacadPattern;
        }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} نباید خالی باشد")]
        [BindProperty]
        [PageRemote(PageHandler = "CheckUserName", HttpMethod = "get", ErrorMessage = "این نام قبلا ثبت شده است"/*,AdditionalFields ="__RequestVerifictionToken"*/)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} نباید خالی باشد")]
        [BindProperty,DataType(dataType:DataType.Password)]
        //[RegularExpression("")]
        [MinLength(8)]
        public string Password { get; set; }
        [Required(ErrorMessage ="{0} نباید خالی باشد")]
        [BindProperty,DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="تگرار با کلمه عیور همخوانی ندارد")]
        public string RepPassword { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
                return Page();
            MyResultWithoutData result = _scopeFacadPattern.RegisterUserService.RegisterUser(new RegisterUserDto()
            {
                UserName = UserName,
                Password = Password
            });
            if(result.StatusCode == StatusCodeEnum.Failed)
                return Failed(result,Page());

            return Success(result,RedirectToPage("Login"));

        }

        public JsonResult OnGetCheckUserName(string userName)
        {
            return new JsonResult(_scopeFacadPattern.CheckUserNameService.CheckUserName(userName));
        }
    }
}
