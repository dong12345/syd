using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JSBYG_Common
{
    public static class DataHelper
    {
        #region 数据转换
        /// <summary>
        /// 获取string类型数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return string.Empty;
            }
            return obj.ToString();
        }

        /// <summary>
        /// 获取int型数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetInt32(object obj)
        {
            int result = 0;

            if (obj != DBNull.Value && obj != null)
            {
                if (!int.TryParse(obj.ToString(), out result))
                    throw new Exception("整形转换失败");
            }
            return result;
        }

        /// <summary>        
        /// 获取双精度类型数据
        /// </summary>   
        /// <param name="obj"></param>
        /// <returns></returns>         
        public static double GetDouble(object obj)
        {
            double result = 0.00;
            if (obj != DBNull.Value && obj != null)
            {
                if (!double.TryParse(obj.ToString(), out result))
                    throw new Exception("双精度类型转换失败");
            }
            return result;
        }

        /// <summary>         
        /// 获取decimal类型数据        
        /// </summary>         
        /// <param name="obj"></param> 
        /// <returns></returns>         
        public static decimal GetDecimal(object obj)
        {
            decimal result = 0.00m;
            if (obj != DBNull.Value && obj != null)
            {
                if (!decimal.TryParse(obj.ToString(), out result))
                    throw new Exception("Decimal类型转换失败");
            }
            return result;
        }


        /// <summary>         
        /// 获取bool类型数据如果传值是1或者是返回true;       
        /// </summary>       
        /// <param name="obj"></param>
        /// <returns></returns>         
        public static bool GetBool(object obj)
        {
            if (obj != DBNull.Value && obj != null)
            {
                return obj.ToString() == "1" || obj.ToString() == "是" || obj.ToString().ToLower() == "true";
            }
            return false;
        }

        /// <summary>         
        /// 获取DateTime类型数据        
        /// </summary>         
        ///<param name="obj"></param>
        /// <returns></returns>       
        public static DateTime GetDateTime(object obj)
        {
            DateTime result = DateTime.Now;
            if (obj != DBNull.Value && obj != null)
            {
                if (!DateTime.TryParse(obj.ToString(), out result))
                    throw new Exception("日期格式数据转换失败");
            }
            return result;
        }
        #endregion

        #region 通过反射将DataTable转为List泛型集合
        public static List<T> GetList<T>(DataTable table)
        {
            List<T> list = new List<T>();
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                t = Activator.CreateInstance<T>();
                propertypes = t.GetType().GetProperties();
                foreach (PropertyInfo pro in propertypes)
                {
                    tempName = pro.Name;
                    if (table.Columns.Contains(tempName))
                    {
                        object value = string.Empty;
                        #region 判断table中数据类型
                        switch (pro.PropertyType.Name)
                        {
                            case "Int32":
                                value = DataHelper.GetInt32(row[tempName]);
                                break;
                            case "String":
                                value = DataHelper.GetString(row[tempName]);
                                break;
                            case "Decimal":
                                value = DataHelper.GetDecimal(row[tempName]);
                                break;
                            case "Double":
                                value = DataHelper.GetDouble(row[tempName]);
                                break;
                            case "DateTime":
                                value = DataHelper.GetDateTime(row[tempName]);
                                break;
                            default:
                                value = row[tempName];
                                break;
                        }
                        #endregion
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            pro.SetValue(t, value);
                        }
                    }
                }
                list.Add(t);
            }
            return list.Count == 0 ? null : list;
        }
        #endregion

        #region 通过反射将DataTable转为泛型对象
        public static T GetModel<T>(DataTable table)
        {
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                t = Activator.CreateInstance<T>();
                propertypes = t.GetType().GetProperties();
                foreach (PropertyInfo pro in propertypes)
                {
                    tempName = pro.Name;
                    if (table.Columns.Contains(tempName))
                    {
                        object value = string.Empty;
                        #region 判断table中数据类型
                        switch (pro.PropertyType.Name)
                        {
                            case "Int32":
                                value = DataHelper.GetInt32(row[tempName]);
                                break;
                            case "String":
                                value = DataHelper.GetString(row[tempName]);
                                break;
                            case "Decimal":
                                value = DataHelper.GetDecimal(row[tempName]);
                                break;
                            case "Double":
                                value = DataHelper.GetDouble(row[tempName]);
                                break;
                            case "DateTime":
                                value = DataHelper.GetDateTime(row[tempName]);
                                break;
                            default:
                                value = row[tempName];
                                break;
                        }
                        #endregion
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            pro.SetValue(t, value);
                        }
                    }
                }
            }
            return t;
        }
        #endregion

    }
}
