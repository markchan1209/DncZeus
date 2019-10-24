/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.RequestPayload.Rbac.Icon
{
    /// <summary>
    /// 圖標請求參數實體
    /// </summary>
    public class IconRequestPayload : RequestPayload
    {
        /// <summary>
        /// 是否已被刪除
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public Status Status { get; set; }
    }
}
