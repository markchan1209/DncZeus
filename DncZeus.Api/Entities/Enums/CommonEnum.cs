/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

namespace DncZeus.Api.Entities.Enums
{
    /// <summary>
    /// 通用枚舉類
    /// </summary>
    public class CommonEnum
    {
        /// <summary>
        /// 是否已刪
        /// </summary>
        public enum IsDeleted
        {
            /// <summary>
            /// 所有
            /// </summary>
            All=-1,
            /// <summary>
            /// 否
            /// </summary>
            No = 0,
            /// <summary>
            /// 是
            /// </summary>
            Yes = 1
        }

        /// <summary>
        /// 是否已被鎖定
        /// </summary>
        public enum IsLocked
        {
            /// <summary>
            /// 未鎖定
            /// </summary>
            UnLocked = 0,
            /// <summary>
            /// 已鎖定
            /// </summary>
            Locked = 1
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        public enum IsEnabled
        {
            /// <summary>
            /// 否
            /// </summary>
            No = 0,
            /// <summary>
            /// 是
            /// </summary>
            Yes = 1
        }


        /// <summary>
        /// 用戶狀態
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// 未指定
            /// </summary>
            All = -1,
            /// <summary>
            /// 已禁用
            /// </summary>
            Forbidden = 0,
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 1
        }

        /// <summary>
        /// 權限類型
        /// </summary>
        public enum PermissionType
        {
            /// <summary>
            /// 菜單
            /// </summary>
            Menu = 0,
            /// <summary>
            /// 按鈕/操作/功能
            /// </summary>
            Action = 1
        }

        /// <summary>
        /// 是否枚舉
        /// </summary>
        public enum YesOrNo
        {
            /// <summary>
            /// 所有
            /// </summary>
            All = -1,
            /// <summary>
            /// 否
            /// </summary>
            No = 0,
            /// <summary>
            /// 是
            /// </summary>
            Yes = 1
        }
    }
}
