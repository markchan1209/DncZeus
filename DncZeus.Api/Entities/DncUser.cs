/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 ******************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class DncUser
    {
        /// <summary>
        /// 用戶GUID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DefaultValue("newid()")]
        public Guid Guid { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)",Order =10)]
        public string LoginName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DisplayName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(255)",Order = 100)]
        public string Avatar { get; set; }
        public UserType UserType { get; set; }
        public IsLocked IsLocked { get; set; }
        //[EnumDataType(typeof(UserStatus))]
        public UserStatus Status { get; set; }
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
        /// 用戶描述信息
        /// </summary>
        [Column(TypeName = "nvarchar(800)")]
        public string Description { get; set; }
        /// <summary>
        /// 用戶的角色集合
        /// </summary>
        public ICollection<DncUserRoleMapping> UserRoles { get; set; }
    }

    /// <summary>
    /// 用戶類型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 超級管理員
        /// </summary>
        SuperAdministrator = 0,
        /// <summary>
        /// 管理員
        /// </summary>
        Admin = 1,
        /// <summary>
        /// 一般用戶
        /// </summary>
        GeneralUser = 2
    }

    /// <summary>
    /// 用戶狀態
    /// </summary>
    public enum UserStatus {
        /// <summary>
        /// 未指定
        /// </summary>
        All =-1,
        /// <summary>
        /// 已禁用
        /// </summary>
        Forbidden=0,
        /// <summary>
        /// 正常
        /// </summary>
        Normal =1
    }
}
