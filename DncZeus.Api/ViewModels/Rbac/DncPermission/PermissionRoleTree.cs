/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using System.Collections.Generic;

namespace DncZeus.Api.ViewModels.Rbac.DncPermission
{
    /// <summary>
    /// 用於角色權限的菜單樹
    /// </summary>
    public class PermissionMenuTree
    {
        /// <summary>
        /// 
        /// </summary>
        public PermissionMenuTree()
        {
            Permissions = new List<PermissionElement>();
            Children = new List<PermissionMenuTree>();
        }
        /// <summary>
        /// GUID
        /// </summary>
        public Guid Guid { get; set; }
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
        /// 當前菜單的所有權限都已分配到指定角色
        /// </summary>
        public bool AllAssigned { get; set; }
        /// <summary>
        /// 當前菜單擁有的權限功能
        /// </summary>
        public List<PermissionElement> Permissions { get; set; }
        /// <summary>
        /// 子節點屬性數組
        /// </summary>
        public List<PermissionMenuTree> Children { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PermissionElement
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
        /// 是否已分配到指定角色
        /// </summary>
        public bool IsAssignedToRole { get; set; }
    }
}
