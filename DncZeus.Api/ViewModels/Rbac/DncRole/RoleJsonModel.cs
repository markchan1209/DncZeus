/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * DESCRIPTION:     角色信息實體類
 ******************************************/
using System;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.ViewModels.Rbac.DncRole
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleJsonModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public IsDeleted IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public Guid CreatedByUserGuid { get; set; }
        public string CreatedByUserName { get; set; }
        public string ModifiedOn { get; set; }
        public Guid? ModifiedByUserGuid { get; set; }
        public string ModifiedByUserName { get; set; }
        /// <summary>
        /// 是否是超級管理員(超級管理員擁有系統的所有權限)
        /// </summary>
        public bool IsSuperAdministrator { get; set; }
        /// <summary>
        /// 是否是系統內置角色(系統內置角色不允許刪除,修改操作)
        /// </summary>
        public bool IsBuiltin { get; set; }
    }
}
