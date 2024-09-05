using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HYR_Blog.CoreLayer.Utilities.OperationResult
{
    public class MyResult<Data>:MyResultWithoutData
    {
        public Data data { get; set; }

        public static MyResult<Data> Success( Data data, string title = "موفق", string StatusMessage = Message.Success)
        {

            return new MyResult<Data>()
            {
                StatusMessage = StatusMessage,
                StatusCode = StatusCodeEnum.Success,
                Title = title,
                data = data
            };
    }
        public static MyResult<Data> Failed(Data data, string title = "ناموفق", string StatusMessage = Message.Failed)
        {
            return new MyResult<Data>()
            {
                StatusMessage = StatusMessage,
                StatusCode = StatusCodeEnum.Failed,
                Title = title,
                data = data
            };
        }
        public static MyResult<Data> NotFound(Data data, string title = "یافت نشد", string StatusMessage = Message.NotFound)
        {
            return new MyResult<Data>()
            {
                StatusMessage = StatusMessage,
                StatusCode = StatusCodeEnum.NotFound,
                Title = title ,
                data = data
            };
        }
        public static MyResult<Data> Duplicate(Data data, string title = "تکراری است", string StatusMessage = Message.Duplicate)
        {
            return new MyResult<Data>()
            {
                StatusMessage = StatusMessage,
                StatusCode = StatusCodeEnum.Duplicate,
                Title = title,
                data = data
            };
        }


       
    }
}

