/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-11-14
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * DESCRIPTION:     圖標信息實體類
 ******************************************/

using System;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.ViewModels.Rbac.DncIcon
{
    /// <summary>
    /// 
    /// </summary>
    public class IconJsonModel
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
        /// <summary>
        /// 
        /// </summary>
        public string CreatedOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid CreatedByUserGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CreatedByUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModifiedOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? ModifiedByUserGuid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModifiedByUserName { get; set; }
    }
}
