/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using DncZeus.Api.Models.Response;

namespace DncZeus.Api.Extensions
{
    /// <summary>
    /// /
    /// </summary>
    public class ResponseModelFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public static ResponseModel CreateInstance => new ResponseModel();
        /// <summary>
        /// 
        /// </summary>
        public static ResponseResultModel CreateResultInstance => new ResponseResultModel();
    }
}
