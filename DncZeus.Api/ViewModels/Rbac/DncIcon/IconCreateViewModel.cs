/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.ViewModels.Rbac.DncIcon
{
    /// <summary>
    /// 圖標的視圖類(創建/編輯)
    /// </summary>
    public class IconCreateViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 圖標名稱
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 圖標的大小，單位是 px
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 圖標顏色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 自定義圖標
        /// </summary>
        public string Custom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
    }
}
