/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-11-13
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * DESCRIPTION:     菜單實體類
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
    /// 菜單實體類
    /// </summary>
    public class DncMenu
    {
        /// <summary>
        /// GUID
        /// </summary>
        [Key,Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DefaultValue("newid()")]
        public Guid Guid { get; set; }
        /// <summary>
        /// 菜單名稱
        /// </summary>
        [Required,Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        /// <summary>
        /// 鏈接地址
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string Url { get; set; }
        /// <summary>
        /// 頁面別名
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string Alias { get; set; }
        /// <summary>
        /// 菜單圖標(可選)
        /// </summary>
        [Column(TypeName = "nvarchar(128)")]
        public string Icon { get; set; }
        /// <summary>
        /// 父級GUID
        /// </summary>
        public Guid? ParentGuid { get; set; }
        /// <summary>
        /// 上級菜單名稱
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 菜單層級深度
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        [Column(TypeName = "nvarchar(800)")]
        public string Description { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否可用(0:禁用,1:可用)
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 是否已刪
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 是否為默認路由
        /// </summary>
        public YesOrNo IsDefaultRouter { get; set; }
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
        /// 前端組件(.vue)
        /// </summary>
        [StringLength(255)]
        public string Component { get; set; }

        /// <summary>
        /// 在菜單中隱藏
        /// </summary>
        public YesOrNo? HideInMenu { get; set; }
        /// <summary>
        /// 不緩存頁面
        /// </summary>
        public YesOrNo? NotCache { get; set; }
        /// <summary>
        /// 頁面關閉前的回調函數
        /// </summary>
        [StringLength(255)]
        public string BeforeCloseFun { get; set; }
        
        /// <summary>
        /// 菜單擁有的權限列表
        /// </summary>
        public ICollection<DncPermission> Permissions { get; set; }
    }
}
