using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYR_Blog.CoreLayer.Utilities.UIUtilities
{
    public static class CookieManager
    {
        public static void AddCookie(HttpContext context , string key , string value)
        {
            context.Response.Cookies.Append(key, value,new CookieOptions()
            {
                Expires = DateTime.Now.AddMonths(1),
            });
        }
    }
}
