/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using System.Collections.Generic;

namespace DncZeus.Api.ViewModels.Rbac.DncMenu
{
    /// <summary>
    /// 用於iview的菜單樹
    /// </summary>
    public class MenuTree
    {
        /// <summary>
        /// 
        /// </summary>
        public MenuTree()
        {
            Children = new List<MenuTree>();
        }
        /// <summary>
        /// GUID
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? ParentGuid { get; set; }
        /// <summary>
        /// 標題(菜單名稱)
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 是否展開子節點
        /// </summary>
        public bool Expand { get; set; }
        /// <summary>
        /// 禁掉響應
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// 禁掉 checkbox
        /// </summary>
        public bool DisableCheckbox { get; set; }
        /// <summary>
        /// 是否選中子節點	
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// 是否勾選(如果勾選，子節點也會全部勾選)
        /// </summary>
        public bool Checked { get; set; }
        /// <summary>
        /// 子節點屬性數組
        /// </summary>
        public List<MenuTree> Children { get; set; }
    }
}
