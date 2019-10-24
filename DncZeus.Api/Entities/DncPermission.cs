/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 權限實體類
    /// </summary>
    public class DncPermission
    {
        /// <summary>
        /// 
        /// </summary>
        public DncPermission()
        {
            Roles = new HashSet<DncRolePermissionMapping>();
        }
        /// <summary>
        /// 權限編碼
        /// </summary>
        [Required]
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }
        /// <summary>
        /// 菜單GUID
        /// </summary>
        public Guid MenuGuid { get; set; }
        /// <summary>
        /// 權限名稱
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        /// <summary>
        /// 權限操作碼
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(80)")]
        public string ActionCode { get; set; }
        /// <summary>
        /// 圖標(可選)
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 是否已刪
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 權限類型(0:菜單,1:按鈕/操作/功能等)
        /// </summary>
        public PermissionType Type { get; set; }
        /// <summary>
        /// 創建者ID
        /// </summary>
        public Guid CreatedByUserGuid { get; set; }
        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime CreatedOn { get; set; }
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
        /// 關聯的菜單
        /// </summary>
        public DncMenu Menu { get; set; }
        /// <summary>
        /// 權限所屬的角色集合
        /// </summary>
        public ICollection<DncRolePermissionMapping> Roles { get; set; }

     
    }
}
