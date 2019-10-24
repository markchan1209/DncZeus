/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Data;

namespace DncZeus.Api.Extensions.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public static class EntityFrameworkExtension
    {
        /// <summary>
        /// 調用ADO.NET執行SQL語句查詢泛型集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="database">數據庫連接上下文</param>
        /// <param name="sql">SQL語句</param>
        /// <param name="parameters">SQL語句需要的參數</param>
        /// <returns></returns>
        public static List<T> FromSql<T>(this DatabaseFacade database, string sql, object parameters = null)
        {
            var result = new List<T>();
            using (var command = database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                if (parameters != null)
                {
                    var _parameters = parameters.ToSqlParamsArray();
                    command.Parameters.AddRange(_parameters);
                }
                
                database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    result = dt.ToList<T>();
                    return result;
                }
            }
        }
    }
}
