/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 權限實體類
    /// </summary>
    public class DncPermissionWithMenu
    {
        /// <summary>
        /// 權限碼
        /// </summary>
        public string PermissionCode { get; set; }
        /// <summary>
        /// 權限操作碼
        /// </summary>
        public string PermissionActionCode { get; set; }
        /// <summary>
        /// 權限名稱
        /// </summary>
        public string PermissionName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PermissionType PermissionType { get; set; }
        /// <summary>
        /// 菜單名稱
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜單GUID
        /// </summary>
        public Guid MenuGuid { get; set; }
        /// <summary>
        /// 菜單別名(與前端路由配置中的name值保持一致)
        /// </summary>
        public string MenuAlias { get; set; }
        /// <summary>
        /// 是否是默認前端路由
        /// </summary>
        public YesOrNo IsDefaultRouter { get; set; }
    }
}