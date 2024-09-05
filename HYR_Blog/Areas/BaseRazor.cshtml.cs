using System.Diagnostics;
using System.Runtime.InteropServices;
using HYR_Blog.CoreLayer.Utilities.OperationResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HYR_Blog.Areas
{
    
    public class BaseRazorModel : PageModel
    {
        public IActionResult MyAlert(MyResultWithoutData myResultWithoutData , IActionResult actionResult)
        {
            switch (myResultWithoutData.StatusCode)
            {
                case StatusCodeEnum.Duplicate:
                    Duplicate(result: myResultWithoutData, actionResult: actionResult);
                    break;
                case StatusCodeEnum.Success:
                    Success(result: myResultWithoutData, actionResult: actionResult);
                    break;
                case StatusCodeEnum.Failed:
                    Failed(result: myResultWithoutData, actionResult: actionResult);
                    break;
                case StatusCodeEnum.NotFound:
                    NotFound(result: myResultWithoutData, actionResult: actionResult);
                    break;
            }

            return actionResult;
        }


        public IActionResult Success(MyResultWithoutData result, IActionResult actionResult)
        {
            if (result.GetType().Name == typeof(MyResult<>).Name)
                return actionResult;

            HttpContext.Response.Cookies.Delete("SweetAlert");
            string Cookie = JsonConvert.SerializeObject(result);
            HttpContext.Response.Cookies.Append("SweetAlert", Cookie);
            return actionResult;
        }
        public IActionResult Failed(MyResultWithoutData result, IActionResult actionResult)
        {
            HttpContext.Response.Cookies.Delete("SweetAlert");
            string Cookie = JsonConvert.SerializeObject(result);
            HttpContext.Response.Cookies.Append("SweetAlert", Cookie);
            return actionResult;
        }
        public IActionResult NotFound(MyResultWithoutData result, IActionResult actionResult)
        {
            HttpContext.Response.Cookies.Delete("SweetAlert");
            string Cookie = JsonConvert.SerializeObject(result);
            HttpContext.Response.Cookies.Append("SweetAlert", Cookie);

            return actionResult;
        }
        public IActionResult Duplicate(MyResultWithoutData result, IActionResult actionResult)
        {
            HttpContext.Response.Cookies.Delete("SweetAlert");
            string Cookie = JsonConvert.SerializeObject(result);
            HttpContext.Response.Cookies.Append("SweetAlert", Cookie);
            return actionResult;
        }


        public void Success(MyResultWithoutData result , string? RedirectUrlForAfter , bool BeReload = false)
        {
            if (result.GetType().Name == typeof(MyResult<>).Name)
                return;


            HttpContext.Response.Cookies.Delete("SweetAlert");


            result.RedirectUrlForAfter = RedirectUrlForAfter;
            result.BeReload = BeReload;



            string Cookie = JsonConvert.SerializeObject(result);
            HttpContext.Response.Cookies.Append("SweetAlert", Cookie);
        }
        public void Failed(MyResultWithoutData result, string? RedirectUrlForAfter, bool BeReload = false)
        {
            HttpContext.Response.Cookies.Delete("SweetAlert");


            result.RedirectUrlForAfter = RedirectUrlForAfter;
            result.BeReload = BeReload;


            string Cookie = JsonConvert.SerializeObject(result);
            HttpContext.Response.Cookies.Append("SweetAlert", Cookie);
        }
        public void NotFound(MyResultWithoutData result, string? RedirectUrlForAfter , bool BeReload = false)
        {
            HttpContext.Response.Cookies.Delete("SweetAlert");


            result.RedirectUrlForAfter = RedirectUrlForAfter;
            result.BeReload = BeReload;


            string Cookie = JsonConvert.SerializeObject(result);
            HttpContext.Response.Cookies.Append("SweetAlert", Cookie);

        }
        public void Duplicate(MyResultWithoutData result, string? RedirectUrlForAfter, bool BeReload = false)
        {
            HttpContext.Response.Cookies.Delete("SweetAlert");


            result.RedirectUrlForAfter = RedirectUrlForAfter;
            result.BeReload = BeReload;



            string Cookie = JsonConvert.SerializeObject(result);
            HttpContext.Response.Cookies.Append("SweetAlert", Cookie);
        }
    }
}
