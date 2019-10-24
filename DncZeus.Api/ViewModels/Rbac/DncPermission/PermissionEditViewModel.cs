/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using DncZeus.Api.Entities.Enums;

namespace DncZeus.Api.ViewModels.Rbac.DncPermission
{
    /// <summary>
    /// 權限實體類
    /// </summary>
    public class PermissionEditViewModel
    {
        /// <summary>
        /// 權限編碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 菜單GUID
        /// </summary>
        public Guid MenuGuid { get; set; }
        /// <summary>
        /// 菜單名稱
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 權限名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 權限操作碼
        /// </summary>
        public string ActionCode { get; set; }
        /// <summary>
        /// 圖標(可選)
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public CommonEnum.Status Status { get; set; }
        /// <summary>
        /// 是否已刪
        /// </summary>
        public CommonEnum.IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 權限類型(0:菜單,1:按鈕/操作/功能等)
        /// </summary>
        public CommonEnum.PermissionType Type { get; set; }
        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 創建者ID
        /// </summary>
        public int CreatedByUserId { get; set; }
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
        public int ModifiedByUserId { get; set; }
        /// <summary>
        /// 最近修改者
        /// </summary>
        public string ModifiedByUserName { get; set; }
    }
}
