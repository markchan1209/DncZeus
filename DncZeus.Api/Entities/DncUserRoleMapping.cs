/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 用戶-角色映射
    /// </summary>
    public class DncUserRoleMapping
    {
        /// <summary>
        /// 用戶GUID
        /// </summary>
        public Guid UserGuid { get; set; }
        /// <summary>
        /// 用戶實體
        /// </summary>
        public DncUser DncUser { get; set; }

        /// <summary>
        /// 角色編碼
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 角色實體
        /// </summary>
        public DncRole DncRole { get; set; }
        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
