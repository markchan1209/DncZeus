/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using DncZeus.Api.Entities;
using System;

namespace DncZeus.Api.Extensions.AuthContext
{
    /// <summary>
    /// 登錄用戶上下文
    /// </summary>
    public class AuthContextUser
    {
        /// <summary>
        /// 用戶GUID
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// 顯示名
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 登錄名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 電子郵箱
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 用戶類型
        /// </summary>
        public UserType UserType { get; set; }
        /// <summary>
        /// 頭像地址
        /// </summary>
        public string Avator { get; set; }
    }
}