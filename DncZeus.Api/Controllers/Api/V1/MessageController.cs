/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using DncZeus.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DncZeus.Api.Controllers.Api.V1
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Count()
        {
            return Ok(1);
        }

        /// <summary>
        /// 初始化消息標題列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Init()
        {
            var response = ResponseModelFactory.CreateInstance;
            var unread = new object[] {
                new {title="消息1",create_time=DateTime.Now,msg_id=1}
            };
            response.SetData(new { unread });
            return Ok(response);
        }

        /// <summary>
        /// 獲取指定ID的消息內容
        /// </summary>
        /// <returns></returns>
        [HttpGet("{msgid:int}")]
        public IActionResult Content(int msgid)
        {
            var response = ResponseModelFactory.CreateInstance;
           
            response.SetData($"消息[{msgid}]內容");
            return Ok(response);
        }

        /// <summary>
        /// 將消息標為已讀
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/message/has_read/{msgid}")]
        public IActionResult HasRead(int msgid)
        {
            var response = ResponseModelFactory.CreateInstance;
            return Ok(response);
        }

        /// <summary>
        /// 刪除已讀消息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/message/remove_readed/{msgid}")]
        public IActionResult RemoveRead(int msgid)
        {
            var response = ResponseModelFactory.CreateInstance;
            return Ok(response);
        }

        /// <summary>
        /// 恢復已刪消息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/message/restore/{msgid}")]
        public IActionResult Restore(int msgid)
        {
            var response = ResponseModelFactory.CreateInstance;
            return Ok(response);
        }
    }
}