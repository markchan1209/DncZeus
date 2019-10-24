/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    碼友網(https://codedefault.com)--專注.NET/.NET Core
 * 版權所有，請勿刪除
 ******************************************/

/*
 * 參考鏈接：http://www.codeisbug.com/Doc/3/1113
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;

namespace DncZeus.Api.Extensions
{
    /// <summary>
    /// 把datatable轉換為對像集合列表List&lt;T&gt;
    /// </summary>
    public static class DataTableConvert
    {
        //把DataRow轉換為對象的委託聲明
        private delegate T Load<T>(DataRow dataRecord);

        //用於構造Emit的DataRow中獲取字段的方法信息
        private static readonly MethodInfo getValueMethod = typeof(DataRow).GetMethod("get_Item", new Type[] { typeof(int) });

        //用於構造Emit的DataRow中判斷是否為空行的方法信息
        private static readonly MethodInfo isDBNullMethod = typeof(DataRow).GetMethod("IsNull", new Type[] { typeof(int) });

        //使用字典存儲實體的類型以及與之對應的Emit生成的轉換方法
        private static Dictionary<Type, Delegate> rowMapMethods = new Dictionary<Type, Delegate>();

        /// <summary>
        /// 將DataTable轉換成泛型對像列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> list = new List<T>();
            if (dt == null)
                return list;

            //聲明 委託Load<T>的一個實例rowMap
            Load<T> rowMap = null;


            //從rowMapMethods查找當前T類對應的轉換方法，沒有則使用Emit構造一個。
            if (!rowMapMethods.ContainsKey(typeof(T)))
            {
                DynamicMethod method = new DynamicMethod("DynamicCreateEntity_" + typeof(T).Name, typeof(T), new Type[] { typeof(DataRow) }, typeof(T), true);
                ILGenerator generator = method.GetILGenerator();
                LocalBuilder result = generator.DeclareLocal(typeof(T));
                generator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(Type.EmptyTypes));
                generator.Emit(OpCodes.Stloc, result);

                for (int index = 0; index < dt.Columns.Count; index++)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(dt.Columns[index].ColumnName);
                    Label endIfLabel = generator.DefineLabel();
                    if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
                    {
                        generator.Emit(OpCodes.Ldarg_0);
                        generator.Emit(OpCodes.Ldc_I4, index);
                        generator.Emit(OpCodes.Callvirt, isDBNullMethod);
                        generator.Emit(OpCodes.Brtrue, endIfLabel);
                        generator.Emit(OpCodes.Ldloc, result);
                        generator.Emit(OpCodes.Ldarg_0);
                        generator.Emit(OpCodes.Ldc_I4, index);
                        generator.Emit(OpCodes.Callvirt, getValueMethod);
                        generator.Emit(OpCodes.Unbox_Any, propertyInfo.PropertyType);
                        generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());
                        generator.MarkLabel(endIfLabel);
                    }
                }
                generator.Emit(OpCodes.Ldloc, result);
                generator.Emit(OpCodes.Ret);

                //構造完成以後傳給rowMap
                rowMap = (Load<T>)method.CreateDelegate(typeof(Load<T>));
            }
            else
            {
                rowMap = (Load<T>)rowMapMethods[typeof(T)];
            }

            //遍歷Datatable的rows集合，調用rowMap把DataRow轉換為對像（T）
            foreach (DataRow info in dt.Rows)
                list.Add(rowMap(info));
            return list;
        }
    }
}
