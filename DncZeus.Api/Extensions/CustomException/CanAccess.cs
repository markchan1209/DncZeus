/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2019-01-08
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace DncZeus.Api.Extensions.CustomException
{
    /// <summary>
    /// 用戶可以訪問的控制器及操作權限
    /// </summary>
    public class CanAccess
    {
        /// <summary>
        /// 控制器
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// Action集合
        /// </summary>
        public List<string> Actions { get; set; }
    }

    /// <summary>
    /// 用戶擁有的API操作權限
    /// </summary>
    public class OwnedApiPermission
    {
        /// <summary>
        /// 
        /// </summary>
        public OwnedApiPermission()
        {
            CanAccesses = new List<CanAccess>();
        }
        /// <summary>
        /// 可以訪問的API控制器集合
        /// </summary>
        public List<CanAccess> CanAccesses { get; set; }

        /// <summary>
        /// 是否可以訪問
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool Can(string controller, string action)
        {
            if (string.IsNullOrEmpty(controller) || string.IsNullOrEmpty(action))
            {
                return false;
            }
            var ctrl = CanAccesses.Where(x => string.Equals(controller, x.Controller,StringComparison.OrdinalIgnoreCase)).FirstOrDefault(x => x.Controller == controller);
            if (ctrl == null)
            {
                return false;
            }

            return ctrl.Actions.Contains(action, StringComparer.OrdinalIgnoreCase);
        }
    }
}
