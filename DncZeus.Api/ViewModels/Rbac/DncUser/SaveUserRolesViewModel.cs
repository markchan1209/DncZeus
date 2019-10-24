/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DncZeus.Api.ViewModels.Rbac.DncUser
{
    /// <summary>
    /// 用戶獲得的角色實體對像
    /// </summary>
    public class SaveUserRolesViewModel
    {
        /// <summary>
        /// 用戶GUID
        /// </summary>
        public Guid UserGuid { get; set; }
        /// <summary>
        /// 已獲得的角色代碼集合
        /// </summary>
        public List<string> AssignedRoles { get; set; }
    }
}
