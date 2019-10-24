/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System.Collections.Generic;
using System.Linq;

namespace DncZeus.Api.RequestPayload
{
    /// <summary>
    /// 請求實體
    /// </summary>
    public class RequestPayload
    {
        /// <summary>
        /// 
        /// </summary>
        public RequestPayload()
        {
            Sort = new List<Sort>();
            Kw = "";
        }
        /// <summary>
        /// 分頁大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 當前頁碼
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 排序對像集合(支持多個字段排序)
        /// </summary>
        public List<Sort> Sort { get; set; }
        /// <summary>
        /// 組合後的排序字符串
        /// </summary>
        public string OrderBy
        {
            get
            {
                var orderBy = "";
                var sort = Sort.Where(x => string.IsNullOrEmpty(x.Field) && string.IsNullOrEmpty(x.Direct)).ToList();
                if (sort.Count > 0)
                {
                    orderBy = "ORDER BY " + string.Join(",", sort.Select(x => $"{x.Field} {x.Direct}"));
                }
                return orderBy;
            }
        }

        /// <summary>
        /// 第一個排序字段(單個字段排序)
        /// </summary>
        public Sort FirstSort
        {
            get
            {
                var fs = Sort[0];
                if (fs == null)
                {
                    return null;
                }
                var sort = new Sort
                {
                    Direct = fs.Direct.ToUpper(),
                    Field = fs.Field
                };
                return sort;
            }
        }

        /// <summary>
        /// 搜索關鍵字
        /// </summary>
        public string Kw { get; set; }
    }

    /// <summary>
    /// 排序實體對像
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// 排序實體對像構造函數
        /// </summary>
        public Sort()
        {
            Direct = "DESC";
        }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public string Direct { get; set; }
    }
}
