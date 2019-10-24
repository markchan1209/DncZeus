/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

namespace DncZeus.Api.Models.Response
{
    /// <summary>
    /// 請求響應實體
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// 請求響應實體類
        /// </summary>
        public ResponseModel()
        {
            Code = 200;
            Message = "操作成功";
        }
        /// <summary>
        /// 響應代碼
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 響應消息內容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回的響應數據
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 設置響應狀態為成功
        /// </summary>
        /// <param name="message"></param>
        public void SetSuccess(string message = "成功")
        {
            Code = 200;
            Message = message;
        }
        /// <summary>
        /// 設置響應狀態為失敗
        /// </summary>
        /// <param name="message"></param>
        public void SetFailed(string message = "失敗")
        {
            Message = message;
            Code = 999;
        }

        /// <summary>
        /// 設置響應狀態為體驗版(返回失敗結果)
        /// </summary>
        /// <param name="message"></param>
        public void SetIsTrial(string message = "體驗版,功能已被關閉")
        {
            Message = message;
            Code = 999;
        }

        /// <summary>
        /// 設置響應狀態為錯誤
        /// </summary>
        /// <param name="message"></param>
        public void SetError(string message = "錯誤")
        {
            Code = 500;
            Message = message;
        }

        /// <summary>
        /// 設置響應狀態為未知資源
        /// </summary>
        /// <param name="message"></param>
        public void SetNotFound(string message = "未知資源")
        {
            Message = message;
            Code = 404;
        }

        /// <summary>
        /// 設置響應狀態為無權限
        /// </summary>
        /// <param name="message"></param>
        public void SetNoPermission(string message = "無權限")
        {
            Message = message;
            Code = 401;
        }

        /// <summary>
        /// 設置響應數據
        /// </summary>
        /// <param name="data"></param>
        public void SetData(object data)
        {
            Data = data;
        }
    }
}
