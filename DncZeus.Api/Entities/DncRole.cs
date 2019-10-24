/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-11-06
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * DESCRIPTION:     角色實體類
 ******************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 角色實體類
    /// </summary>
    public class DncRole
    {
        /// <summary>
        /// 
        /// </summary>
        public DncRole()
        {
            UserRoles = new HashSet<DncUserRoleMapping>();
            Permissions = new HashSet<DncRolePermissionMapping>();
        }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Key]
        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 創建者ID
        /// </summary>
        public Guid CreatedByUserGuid { get; set; }
        /// <summary>
        /// 創建者姓名
        /// </summary>
        public string CreatedByUserName { get; set; }
        /// <summary>
        /// 最近修改時間
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// 最近修改者ID
        /// </summary>
        public Guid? ModifiedByUserGuid { get; set; }
        /// <summary>
        /// 最近修改者姓名
        /// </summary>
        public string ModifiedByUserName { get; set; }
        /// <summary>
        /// 是否是超級管理員(超級管理員擁有系統的所有權限)
        /// </summary>
        public bool IsSuperAdministrator { get; set; }
        /// <summary>
        /// 是否是系統內置角色(系統內置角色不允許刪除,修改操作)
        /// </summary>
        public bool IsBuiltin { get; set; }

        /// <summary>
        /// 角色擁有的用戶集合
        /// </summary>
        public ICollection<DncUserRoleMapping> UserRoles { get; set; }
        /// <summary>
        /// 角色擁有的權限集合
        /// </summary>
        public ICollection<DncRolePermissionMapping> Permissions { get; set; }
    }
}
