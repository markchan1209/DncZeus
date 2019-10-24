/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.RequestPayload.Rbac.Menu
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuRequestPayload : RequestPayload
    {
        /// <summary>
        /// 是否已被刪除
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 上級菜單GUID
        /// </summary>
        public Guid? ParentGuid { get; set; }
    }
}
