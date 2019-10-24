/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;

namespace DncZeus.Api.Entities.QueryModels.DncPermission
{
    /// <summary>
    /// 
    /// </summary>
    public class DncPermissionWithAssignProperty
    {
        /// <summary>
        /// 權限編碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 權限名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 權限關聯的菜單GUID
        /// </summary>
        public Guid? MenuGuid { get; set; }
        /// <summary>
        /// 權限操作碼
        /// </summary>
        public string ActionCode { get; set; }
        /// <summary>
        /// 角色編碼
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 權限是否已分配到當前角色
        /// </summary>
        public int IsAssigned { get; set; }
    }
}
