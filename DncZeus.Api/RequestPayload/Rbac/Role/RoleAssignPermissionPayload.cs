/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System.Collections.Generic;

namespace DncZeus.Api.RequestPayload.Rbac.Role
{
    /// <summary>
    /// 角色分配權限的請求載體類
    /// </summary>
    public class RoleAssignPermissionPayload
    {
        /// <summary>
        /// 
        /// </summary>
        public RoleAssignPermissionPayload()
        {
            Permissions = new List<string>();
        }
        /// <summary>
        /// 角色編碼
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 權限列表
        /// </summary>
        public List<string> Permissions { get; set; }
    }
}
