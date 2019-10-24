/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using DncZeus.Api.Entities;
using static DncZeus.Api.Entities.Enums.CommonEnum;

namespace DncZeus.Api.RequestPayload.Rbac.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRequestPayload : RequestPayload
    {
        /// <summary>
        /// 是否已被刪除
        /// </summary>
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 用戶狀態
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
