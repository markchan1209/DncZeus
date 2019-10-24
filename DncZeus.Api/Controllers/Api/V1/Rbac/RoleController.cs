/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using System;
using System.Data.SqlClient;
using System.Linq;
using AutoMapper;
using DncZeus.Api.Entities;
using DncZeus.Api.Entities.Enums;
using DncZeus.Api.Extensions;
using DncZeus.Api.Extensions.AuthContext;
using DncZeus.Api.Extensions.CustomException;
using DncZeus.Api.Models.Response;
using DncZeus.Api.RequestPayload.Rbac.Role;
using DncZeus.Api.Utils;
using DncZeus.Api.ViewModels.Rbac.DncRole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DncZeus.Api.Controllers.Api.V1.Rbac
{
    /// <summary>
    /// 
    /// </summary>
    //[CustomAuthorize]
    [Route("api/v1/rbac/[controller]/[action]")]
    [ApiController]
    [CustomAuthorize]
    public class RoleController : ControllerBase
    {
        private readonly DncZeusDbContext _dbContext;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public RoleController(DncZeusDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult List(RoleRequestPayload payload)
        {
            var response = ResponseModelFactory.CreateResultInstance;
            using (_dbContext)
            {
                var query = _dbContext.DncRole.AsQueryable();
                if (!string.IsNullOrEmpty(payload.Kw))
                {
                    query = query.Where(x => x.Name.Contains(payload.Kw.Trim()) || x.Code.Contains(payload.Kw.Trim()));
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
                var data = list.Select(_mapper.Map<DncRole, RoleJsonModel>);

                response.SetData(data, totalCount);
                return Ok(response);
            }
        }

        /// <summary>
        /// 創建角色
        /// </summary>
        /// <param name="model">角色視圖實體</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(RoleCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (model.Name.Trim().Length <= 0)
            {
                response.SetFailed("請輸入角色名稱");
                return Ok(response);
            }
            using (_dbContext)
            {
                if (_dbContext.DncRole.Count(x => x.Name == model.Name) > 0)
                {
                    response.SetFailed("角色已存在");
                    return Ok(response);
                }
                var entity = _mapper.Map<RoleCreateViewModel, DncRole>(model);
                entity.CreatedOn = DateTime.Now;
                entity.Code = RandomHelper.GetRandomizer(8, true, false, true, true);
                entity.IsSuperAdministrator = false;
                entity.IsBuiltin = false;
                entity.CreatedByUserGuid = AuthContextService.CurrentUser.Guid;
                entity.CreatedByUserName = AuthContextService.CurrentUser.DisplayName;
                _dbContext.DncRole.Add(entity);
                _dbContext.SaveChanges();

                response.SetSuccess();
                return Ok(response);
            }
        }

        /// <summary>
        /// 編輯角色
        /// </summary>
        /// <param name="code">角色惟一編碼</param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [ProducesResponseType(200)]
        public IActionResult Edit(string code)
        {
            using (_dbContext)
            {
                var entity = _dbContext.DncRole.FirstOrDefault(x => x.Code == code);
                var response = ResponseModelFactory.CreateInstance;
                response.SetData(_mapper.Map<DncRole, RoleCreateViewModel>(entity));
                return Ok(response);
            }
        }

        /// <summary>
        /// 保存編輯後的角色信息
        /// </summary>
        /// <param name="model">角色視圖實體</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Edit(RoleCreateViewModel model)
        {
            var response = ResponseModelFactory.CreateInstance;
            if (ConfigurationManager.AppSettings.IsTrialVersion)
            {
                response.SetIsTrial();
                return Ok(response);
            }
            using (_dbContext)
            {
                if (_dbContext.DncRole.Count(x => x.Name == model.Name && x.Code != model.Code) > 0)
                {
                    response.SetFailed("角色已存在");
                    return Ok(response);
                }

                var entity = _dbContext.DncRole.FirstOrDefault(x => x.Code == model.Code);

                if (entity.IsSuperAdministrator && !AuthContextService.IsSupperAdministator)
                {
                    response.SetFailed("沒有足夠的權限");
                    return Ok(response);
                }

                entity.Name = model.Name;
                entity.IsDeleted = model.IsDeleted;
                entity.ModifiedByUserGuid = AuthContextService.CurrentUser.Guid;
                entity.ModifiedByUserName = AuthContextService.CurrentUser.DisplayName;
                entity.ModifiedOn = DateTime.Now;
                entity.Status = model.Status;
                entity.Description = model.Description;
                _dbContext.SaveChanges();
                return Ok(response);
            }
        }

        /// <summary>
        /// 刪除角色
        /// </summary>
        /// <param name="ids">角色ID,多個以逗號分隔</param>
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
        /// 恢復角色
        /// </summary>
        /// <param name="ids">角色ID,多個以逗號分隔</param>
        /// <returns></returns>
        [HttpGet("{ids}")]
        [ProducesResponseType(200)]
        public IActionResult Recover(string ids)
        {
            var response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
            return Ok(response);
        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="command"></param>
        /// <param name="ids">角色ID,多個以逗號分隔</param>
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
                        return Ok(response);
                    }
                    response = UpdateIsDelete(CommonEnum.IsDeleted.Yes, ids);
                    break;
                case "recover":
                    response = UpdateIsDelete(CommonEnum.IsDeleted.No, ids);
                    break;
                case "forbidden":
                    if (ConfigurationManager.AppSettings.IsTrialVersion)
                    {
                        response.SetIsTrial();
                        return Ok(response);
                    }
                    response = UpdateStatus(UserStatus.Forbidden, ids);
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
        /// 為指定角色分配權限
        /// </summary>
        /// <param name="payload">角色分配權限的請求載體類</param>
        /// <returns></returns>
        [HttpPost("/api/v1/rbac/role/assign_permission")]
        public IActionResult AssignPermission(RoleAssignPermissionPayload payload)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var role = _dbContext.DncRole.FirstOrDefault(x => x.Code == payload.RoleCode);
                if (role == null)
                {
                    response.SetFailed("角色不存在");
                    return Ok(response);
                }
                // 如果是超級管理員，則不寫入到角色-權限映射表(在讀取時跳過角色權限映射，直接讀取系統所有的權限)
                if (role.IsSuperAdministrator)
                {
                    response.SetSuccess();
                    return Ok(response);
                }
                //先刪除當前角色原來已分配的權限
                _dbContext.Database.ExecuteSqlCommand("DELETE FROM DncRolePermissionMapping WHERE RoleCode={0}", payload.RoleCode);
                if (payload.Permissions != null || payload.Permissions.Count > 0)
                {
                    var permissions = payload.Permissions.Select(x => new DncRolePermissionMapping
                    {
                        CreatedOn = DateTime.Now,
                        PermissionCode = x.Trim(),
                        RoleCode = payload.RoleCode.Trim()
                    });
                    _dbContext.DncRolePermissionMapping.AddRange(permissions);
                    _dbContext.SaveChanges();
                }

            }
            return Ok(response);
        }

        /// <summary>
        /// 獲取指定用戶的角色列表
        /// </summary>
        /// <param name="guid">用戶GUID</param>
        /// <returns></returns>
        [HttpGet("/api/v1/rbac/role/find_list_by_user_guid/{guid}")]
        public IActionResult FindListByUserGuid(Guid guid)
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                //有N+1次查詢的性能問題
                //var query = _dbContext.DncUser
                //    .Include(r => r.UserRoles)
                //    .ThenInclude(x => x.DncRole)
                //    .Where(x => x.Guid == guid);
                //var roles = query.FirstOrDefault().UserRoles.Select(x => new
                //{
                //    x.DncRole.Code,
                //    x.DncRole.Name
                //});
                var sql = @"SELECT R.* FROM DncUserRoleMapping AS URM
INNER JOIN DncRole AS R ON R.Code=URM.RoleCode
WHERE URM.UserGuid={0}";
                var query = _dbContext.DncRole.FromSql(sql, guid).ToList();
                var assignedRoles = query.ToList().Select(x => x.Code).ToList();
                var roles = _dbContext.DncRole.Where(x => x.IsDeleted == CommonEnum.IsDeleted.No && x.Status == CommonEnum.Status.Normal).ToList().Select(x => new { label = x.Name, key = x.Code });
                response.SetData(new { roles, assignedRoles });
                return Ok(response);
            }
        }

        /// <summary>
        /// 查詢所有角色列表(只包含主要的字段信息:name,code)
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/v1/rbac/role/find_simple_list")]
        public IActionResult FindSimpleList()
        {
            var response = ResponseModelFactory.CreateInstance;
            using (_dbContext)
            {
                var roles = _dbContext.DncRole.Where(x => x.IsDeleted == CommonEnum.IsDeleted.No && x.Status == CommonEnum.Status.Normal).Select(x => new { x.Name, x.Code }).ToList();
                response.SetData(roles);
            }
            return Ok(response);
        }

        #region 私有方法

        /// <summary>
        /// 刪除角色
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <param name="ids">角色ID字符串,多個以逗號隔開</param>
        /// <returns></returns>
        private ResponseModel UpdateIsDelete(CommonEnum.IsDeleted isDeleted, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE DncRole SET IsDeleted=@IsDeleted WHERE Code IN ({0})", parameterNames);
                parameters.Add(new SqlParameter("@IsDeleted", (int)isDeleted));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }

        /// <summary>
        /// 刪除角色
        /// </summary>
        /// <param name="status">角色狀態</param>
        /// <param name="ids">角色ID字符串,多個以逗號隔開</param>
        /// <returns></returns>
        private ResponseModel UpdateStatus(UserStatus status, string ids)
        {
            using (_dbContext)
            {
                var parameters = ids.Split(",").Select((id, index) => new SqlParameter(string.Format("@p{0}", index), id)).ToList();
                var parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
                var sql = string.Format("UPDATE DncRole SET Status=@Status WHERE Code IN ({0})", parameterNames);
                parameters.Add(new SqlParameter("@Status", (int)status));
                _dbContext.Database.ExecuteSqlCommand(sql, parameters);
                var response = ResponseModelFactory.CreateInstance;
                return response;
            }
        }
        #endregion
    }
}