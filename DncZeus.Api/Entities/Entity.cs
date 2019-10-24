/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

namespace DncZeus.Api.Entities
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }
}
