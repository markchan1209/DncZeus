/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DncZeus.Api.Extensions.CustomException
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Result = new ObjectResult(
                    actionContext.ModelState.Values
                        .SelectMany(e => e.Errors)
                        .Select(e => e.ErrorMessage));
            }
        }
        
    }
}
