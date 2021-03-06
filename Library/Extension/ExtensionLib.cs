﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Data;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SOAFramework.Library
{
    public static class ExtensionLib
    {
        /// <summary>
        /// 将datarow中的值复制到对象中去
        /// </summary>
        /// <param name="row"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T CopyToObject<T>(this DataRow row, T data)
        {
            Type type = data.GetType();
            foreach (DataColumn column in row.Table.Columns)
            {
                PropertyInfo property = type.GetProperty(column.ColumnName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
                if (property != null)
                {
                    Type t = Nullable.GetUnderlyingType(property.PropertyType)
                    ?? property.PropertyType;
                    object safeValue = null;
                    if (t == typeof(byte[]))
                    {
                        string v = row[column.ColumnName] == null ? "" : row[column.ColumnName].ToString();
                        safeValue = Encoding.Default.GetBytes(v);
                    }
                    else if (t == typeof(char[]))
                    {
                        string v = row[column.ColumnName] == null ? "" : row[column.ColumnName].ToString();
                        safeValue = v.ToCharArray();
                    }
                    else if (t.BaseType == typeof(Enum))
                    {
                        safeValue = row[column.ColumnName];
                    }
                    else
                    {
                        safeValue = (row[column.ColumnName] == null || row[column.ColumnName] == DBNull.Value) ? null
                                                          : Convert.ChangeType(row[column.ColumnName], t);
                    }
                    //object value = Convert.ChangeType(row[column], property.PropertyType);
                    if (property.CanWrite)
                    {
                        property.SetValue(data, safeValue, null);
                    }

                }
                //else
                //{
                //    throw new Exception("对象：" + type.Name + "中没有属性：" + column.ColumnName);
                //}
            }
            return data;
        }

        /// <summary>
        /// DataTable转换成对象数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IList<T> ToList<T>(this DataTable table)
        {
            IList<T> listResult = new List<T>();
            Type typeT = typeof(T);
            foreach (DataRow row in table.Rows)
            {
                T t = Activator.CreateInstance<T>();
                row.CopyToObject<T>(t);
                //foreach (DataColumn column in table.Columns)
                //{
                //    try
                //    {
                //        PropertyInfo property = typeT.GetProperty(column.ColumnName);
                //        if (property != null && row[column] != DBNull.Value && row[column] != null)
                //        {
                //            object value = row[column].ChangeTypeTo(property.PropertyType);
                //            property.SetValue(t, value, null);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                //}
                listResult.Add(t);
            }
            return listResult;
        }

        /// <summary>
        /// 把datetime转换成unix time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToUnitTime(this DateTime time)
        {
            long lngtime = 0;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            if (time < startTime)
            {
                time = startTime;
            }
            lngtime = (long)(time - startTime).TotalMilliseconds;
            return lngtime;
        }

        /// <summary>
        /// 反射时获取属性名称，可能用不到，先放这里
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private static string GetPropertyName(PropertyInfo property)
        {
            if (property == null) return "";
            string outputPropertyName = property.Name;
            XmlElementAttribute[] xeas = property.GetCustomAttributes(typeof(XmlElementAttribute), true) as XmlElementAttribute[];
            if (xeas != null && xeas.Length > 0)
            {
                outputPropertyName = xeas[0].ElementName;
            }
            else
            {
                XmlArrayAttribute[] xaias = property.GetCustomAttributes(typeof(XmlArrayAttribute), true) as XmlArrayAttribute[];
                if (xaias != null && xaias.Length > 0)
                {
                    outputPropertyName = xaias[0].ElementName;
                }
            }
            return outputPropertyName;
        }

        /// <summary>
        /// 对象转化到dictionary
        /// CZQ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDictionary(this object value)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            PropertyInfo[] props = value.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
            {
                try
                {
                    result.Add(pi.Name, pi.GetValue(value, null));
                }
                catch { }
            }
            return result;
        }

        public static T ChangeTypeTo<T>(this object value)
        {
            Type conversionType = typeof(T);
            object obj = ChangeTypeTo(value, conversionType);
            T t = (T)obj;
            return t;
        }

        internal static bool IsNullableEnum(Type type)
        {
            var enumType = Nullable.GetUnderlyingType(type);

            return enumType != null && enumType.IsEnum;
        }

        public static T CopyTo<T>(this object From, T to) where T : class
        {
            Type t = From.GetType();

            var settings = From.ToDictionary();

            to = settings.FromDictionary(to);

            return to;
        }

        public static T FromDictionary<T>(this Dictionary<string, object> settings, T item) where T : class
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            //FieldInfo[] fields = item.GetType().GetFields();
            foreach (PropertyInfo property in props)
            {
                if (settings.ContainsKey(property.Name))
                {
                    Type t = Nullable.GetUnderlyingType(property.PropertyType)
                                   ?? property.PropertyType;
                    object value = settings[property.Name];
                    object safeValue = (value == null) ? null
                                                       : Convert.ChangeType(value, t);
                    if (property.CanWrite)
                        property.SetValue(item, safeValue, null);
                }
            }
            return item;
        }

        public static bool CanGenerateSchemaFor(Type type)
        {
            return type == typeof(string) ||
                   type == typeof(Guid) ||
                   type == typeof(Guid?) ||
                   type == typeof(decimal) ||
                   type == typeof(decimal?) ||
                   type == typeof(double) ||
                   type == typeof(double?) ||
                   type == typeof(DateTime) ||
                   type == typeof(DateTime?) ||
                   type == typeof(bool) ||
                   type == typeof(bool?) ||
                   type == typeof(Int16) ||
                   type == typeof(Int16?) ||
                   type == typeof(Int32) ||
                   type == typeof(Int32?) ||
                   type == typeof(Int64) ||
                   type == typeof(Int64?) ||
                   type == typeof(float?) ||
                   type == typeof(float) ||
               type == typeof(byte[]) ||
                   type.IsEnum || IsNullableEnum(type);
        }

        public static object ChangeTypeTo(this object value, Type conversionType)
        {
            // Note: This if block was taken from Convert.ChangeType as is, and is needed here since we're
            // checking properties on conversionType below.
            if (conversionType == null)
                throw new ArgumentNullException("conversionType");

            // If it's not a nullable type, just pass through the parameters to Convert.ChangeType

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                // It's a nullable type, so instead of calling Convert.ChangeType directly which would throw a
                // InvalidCastException (per http://weblogs.asp.net/pjohnson/archive/2006/02/07/437631.aspx),
                // determine what the underlying type is
                // If it's null, it won't convert to the underlying type, but that's fine since nulls don't really
                // have a type--so just return null
                // Note: We only do this check if we're converting to a nullable type, since doing it outside
                // would diverge from Convert.ChangeType's behavior, which throws an InvalidCastException if
                // value is null and conversionType is a value type.
                if (value == null)
                    return null;

                // It's a nullable type, and not null, so that means it can be converted to its underlying type,
                // so overwrite the passed-in conversion type with this underlying type
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            else if (conversionType == typeof(Guid))
            {
                return new Guid(value.ToString());

            }
            else if (conversionType == typeof(Int64) && value.GetType() == typeof(int))
            {
                //there is an issue with SQLite where the PK is ALWAYS int64. If this conversion type is Int64
                //we need to throw here - suggesting that they need to use LONG instead


                throw new InvalidOperationException("Can't convert an Int64 (long) to Int32(int). If you're using SQLite - this is probably due to your PK being an INTEGER, which is 64bit. You'll need to set your key to long.");
            }

            // Now that we've guaranteed conversionType is something Convert.ChangeType can handle (i.e. not a
            // nullable type), pass the call on to Convert.ChangeType
            return Convert.ChangeType(value, conversionType);
        }
    }
}
