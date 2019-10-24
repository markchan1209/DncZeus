/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using AutoMapper;
using DncZeus.Api.Entities;
using DncZeus.Api.Entities.Enums;
using DncZeus.Api.Extensions;
using DncZeus.Api.Extensions.AuthContext;
using DncZeus.Api.Extensions.CustomException;
using DncZeus.Api.Models.Response;
using DncZeus.Api.RequestPayload.Rbac.Icon;
using DncZeus.Api.ViewModels.Rbac.DncIcon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace DncZeus.Api.Controllers.Api.V1.Rbac
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/v1/rbac/[controller]/[action]")]
    [ApiController]
    [CustomAuthorize]
    public class IconController : ControllerBase
    {
        private readonly DncZeusDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public IconController(DncZeusDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult List(IconRequestPayload payload)
        {
            using (_dbContext)
            {
                var query = _dbContext.DncIcon.AsQueryable();
                if (!string.IsNullOrEmpty(payload.Kw))
                {
                    query = query.Where(x => x.Code.Contains(payload.Kw.Trim()));
                }
                if (payload.IsDeleted > CommonEnum.IsDeleted.All)
                {
                    query = query.Where(x => x.IsDeleted == payload.IsDeleted);
                }
                if (payload.Status > CommonEnum.Status.All)
                {
                    query = query.Where(x => x.Status == payload.Status);
                }
                var list = query.Paged(payload.CurrentPage, payload.PageSize).ToList();
                var totalCount = query.Count();
                var data = list.Select(_mapper.Map<DncIcon, IconJsonModel>);
                var response = ResponseModelFactory.CreateResultInstance;
                response.SetData(data, totalCount);
                return Ok(response);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/rbac/icon/find_list_by_kw/{kw}")]
        public IActionResult FindByKeyword(string kw)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            if (string.IsNullOrEmpty(kw))
            {
                response.SetFailed("沒有查詢到數據");
                return Ok(response);
            }
            using (_dbContext)
            {

                var query = _dbContext.DncIcon.Where(x => x.Code.Contains(kw));

                var list = query.ToList();
                var data = list.Select(x => new { x.Code, x.Color, x.Size });

                response.SetData(data);
                return Ok(response);
            }
        }

        /// <summary>
        /// 創建圖標
        /// </summary>
        /// <param name="model">圖標視圖實體</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(IconCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (model.Code.Trim().Length <= 0)
            {
                response.SetFailed("請輸入圖標名稱");
                return Ok(response);
            }
            using (_dbContext)
            {
                if (_dbContext.DncIcon.Count(x => x.Code == model.Code) > 0)
                {
                    response.SetFailed("圖標已存在");
                    return Ok(response);
                }
                var entity = _mapper.Map<IconCreateViewModel, DncIcon>(model);
                entity.CreatedOn = DateTime.Now;
                entity.CreatedByUserGuid = AuthContextService.CurrentUser.Guid;
                entity.CreatedByUserName = AuthContextService.CurrentUser.DisplayName;
                _dbContext.DncIcon.Add(entity);
                _dbContext.SaveChanges();

                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 編輯圖標
        /// </summary>
        /// <param name="id">圖標ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(int id)
        {
            using (_dbContext)
            {
                var entity = _dbContext.DncIcon.FirstOrDefault(x => x.Id == id);
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map<DncIcon, IconCreateViewModel>(entity));
                return Ok(response);
            }
        }

        /// <summary>
        /// 保存編輯後的圖標信息
        /// </summary>
        /// <param name="model">圖標視圖實體</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(IconCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (model.Code.Trim().Length <= 0)
            {
                response.SetFailed("請輸入圖標名稱");
                return Ok(response);
            }
            using (_dbContext)
            {
                if (_dbContext.DncIcon.Count(x => x.Code == model.Code && x.Id != model.Id) > 0)
                {
                    response.SetFailed("圖標已存在");
                    return Ok(response);
                }
                var entity = _dbContext.DncIcon.FirstOrDefault(x => x.Id == model.Id);
                entity.Code = model.Code;
                entity.Color = model.Color;
                entity.Custom = model.Custom;
                entity.Size = model.Size;
                entity.IsDeleted = model.IsDeleted;
                entity.ModifiedByUserGuid = AuthContextService.CurrentUser.Guid;
                entity.ModifiedByUserName = AuthContextService.CurrentUser.DisplayName;
                entity.ModifiedOn = DateTime.Now;
                entity.Status = model.Status;
                entity.Description = model.Description;
                _dbContext.SaveChanges();
                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 刪除圖標
        /// </summary>
        /// <param name="ids">圖標ID,多個以逗號分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Delete(string ids)
        {

            var response = ResponseModelFactory.CreateInstance;
            if (ConfigurationManager.AppSettings.IsTrialVersion)
            {
                response.SetIsTrial();
                return Ok(response);
            }
            response = UpdateIsDelete(CommonEnum.IsDeleted.Yes, ids);
            return Ok(response);
        }

        /// <summary>
        /// 恢復圖標
        /// </summary>
        /// <param name="ids">圖標ID,多個以逗號分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Recover(string ids)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (ConfigurationManager.AppSettings.IsTrialVersion)
            {
                response.SetIsTrial();
                return Ok(response);
            }
            response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
            return Ok(response);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ids">圖標ID,多個以逗號分隔</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Batch(string command, string ids)
        {
            var response = ResponseModelFactory.CreateInstance;
            switch (command)
            {
                case "delete":
                    if (ConfigurationManager.AppSettings.IsTrialVersion)
                    {
                        response.SetIsTrial();
                    }
                    else
                    {
                        response = UpdateIsDelete(CommonEnum.IsDeleted.Yes, ids);
                    }
                    break;
                case "recover":
                    response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
                    break;
                case "forbidden":
                    if (ConfigurationManager.AppSettings.IsTrialVersion)
                    {
                        response.SetIsTrial();
                    }
                    else
                    {
                        response = UpdateStatus(UserStatus.Forbidden, ids);
                    }
                    break;
                case "normal":
                    response = UpdateStatus(UserStatus.Normal, ids);
                    break;
                default:
                    break;
            }
            return Ok(response);
        }

        /// <summary>
        /// 創建圖標
        /// </summary>
        /// <param name="model">多行圖標視圖</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Import(IconImportViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (ConfigurationManager.AppSettings.IsTrialVersion)
            {
                response.SetIsTrial();
                return Ok(response);
            }
            if (model.Icons.Trim().Length <= 0)
            {
                response.SetFailed("沒有可用的圖標");
                return Ok(response);
            }
            var models = model.Icons.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => new DncIcon
            {
                Code = x.Trim(),
                CreatedByUserGuid = AuthContextService.CurrentUser.Guid,
                CreatedOn = DateTime.Now,
                CreatedByUserName = "超級管理員"
            });
            using (_dbContext)
            {
                _dbContext.DncIcon.AddRange(models);
                _dbContext.SaveChanges();
                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 刪除圖標
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="ids">圖標ID字符串,多個以逗號隔開</param>
        /// <returns></returns>
        private ResponseModel UpdateIsDelete(CommonEnum.IsDeleted isDeleted, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE DncIcon SET IsDeleted=@IsDeleted WHERE Id IN ({0})", parameterNames);
                parameters.Add(new SqlParameter("@IsDeleted", (int)isDeleted));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }

        /// <summary>
        /// 刪除圖標
        /// </summary>
        /// <param name="status">圖標狀態</param>
        /// <param name="ids">圖標ID字符串,多個以逗號隔開</param>
        /// <returns></returns>
        private ResponseModel UpdateStatus(UserStatus status, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE DncIcon SET Status=@Status WHERE Id IN ({0})", parameterNames);
                parameters.Add(new SqlParameter("@Status", (int)status));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }
    }
}