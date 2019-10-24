/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 角色權限關係表
    /// </summary>
    public class DncRolePermissionMapping
    {
        /// <summary>
        /// 角色編碼
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string RoleCode { get; set; }
        /// <summary>
        /// 權限編碼
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string PermissionCode { get; set; }

        /// <summary>
        /// 角色實體
        /// </summary>
        public DncRole DncRole { get; set; }

        /// <summary>
        /// 權限實體
        /// </summary>
        public DncPermission DncPermission { get; set; }
        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}
