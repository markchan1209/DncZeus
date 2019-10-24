/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using DncZeus.Api.Extensions.CustomException;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace DncZeus.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("/error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpGet]
        public IActionResult Code(int code)
        {
            // 捕獲狀態碼
            var statusCode = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error is HttpException httpEx ?
                httpEx.StatusCode : (HttpStatusCode)Response.StatusCode;
            var ex = (HttpException)HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var parsedCode = (HttpStatusCode)code;
            var error = new ErrorDetails
            {
                StatusCode = code,
                Message = ex?.ToString()
            };
            // 如果是ASP.NET Core Web Api 應用程序，直接返回狀態碼(不跳轉到錯誤頁面，這裡假設所有API接口的路徑都是以/api/開始的)
            if (HttpContext.Features.Get<IHttpRequestFeature>().RawTarget.StartsWith("/api/", StringComparison.Ordinal))
            {
                 parsedCode = (HttpStatusCode)code;
                // error = new ErrorDetails
                //{
                //    StatusCode = code,
                //    Message = parsedCode.ToString()
                //};

                return new ObjectResult(error);
            }

            // error = new ErrorDetails
            //{
            //    StatusCode = code,
            //    Message = parsedCode.ToString()
            //};

            return new ObjectResult(error);
        }
    }
}