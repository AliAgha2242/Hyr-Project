using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HYR_Blog.CoreLayer.Utilities.OperationResult
{
    public class MyResultWithoutData
    {
        public StatusCodeEnum StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public string? Title { get; set; }
        public string? RedirectUrlForAfter { get; set; } = null;
        public bool BeReload { get; set; } = false;


        public static MyResultWithoutData Success(string title = "موفق", string StatusMessage = Message.Success)
        {

            return new MyResultWithoutData()
            {
                StatusMessage = StatusMessage,
                StatusCode = StatusCodeEnum.Success,
                Title = title
            };
        }
        public static MyResultWithoutData Failed(string title = "ناموفق", string StatusMessage = Message.Failed)
        {
            return new MyResultWithoutData()
            {
                StatusMessage = StatusMessage,
                StatusCode = StatusCodeEnum.Failed,
                Title = title
            };
        }
        public static MyResultWithoutData NotFound( string title = "یافت نشد", string StatusMessage = Message.NotFound)
        {
            return new MyResultWithoutData()
            {
                StatusMessage = StatusMessage,
                StatusCode = StatusCodeEnum.NotFound,
                Title = title
            };
        }
        public static MyResultWithoutData Duplicate(string title = "تکراری است", string StatusMessage = Message.Duplicate)
        {
            return new MyResultWithoutData()
            {
                StatusMessage = StatusMessage,
                StatusCode = StatusCodeEnum.Duplicate,
                Title = title 
            };
        }

    }
}
