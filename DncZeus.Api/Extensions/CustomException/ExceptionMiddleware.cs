/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DncZeus.Api.Extensions.CustomException
{
    /// <summary>
    /// 異常中間件
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var error = new ErrorDetails {
                StatusCode= 500,
                Message=$"資源服務器忙,請稍候再試,原因:{exception.Message}"
            };
            if (exception is UnauthorizeException)
            {
                error.StatusCode= (int)HttpStatusCode.Unauthorized;
                error.Message = "未授權的訪問(未登錄或者登錄已超時)";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.StatusCode;

            return context.Response.WriteAsync(error.ToString());
        }
    }
}
