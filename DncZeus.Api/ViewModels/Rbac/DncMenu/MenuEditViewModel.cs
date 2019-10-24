/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:   碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.ViewModels.Rbac.DncMenu
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuEditViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// 菜單名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 鏈接地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 頁面別名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 菜單圖標(可選)
        /// </summary>
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
        /// 前端組件(.vue)
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// 在菜單中隱藏
        /// </summary>
        public YesOrNo HideInMenu { get; set; }
        /// <summary>
        /// 不緩存頁面
        /// </summary>
        public YesOrNo NotCache { get; set; }
        /// <summary>
        /// 頁面關閉前的回調函數
        /// </summary>
        public string BeforeCloseFun { get; set; }
    }
}
