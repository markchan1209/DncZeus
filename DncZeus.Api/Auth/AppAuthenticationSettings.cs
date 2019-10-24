/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

namespace DncZeus.Api.Auth
{
    /// <summary>
    /// JWT授權的配置項
    /// </summary>
    public class AppAuthenticationSettings
    {
        /// <summary>
        /// 應用ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 應用密鑰(真實項目中可能區分應用,不同的應用對應惟一的密鑰)
        /// </summary>
        public string Secret { get; set; }
    }
}