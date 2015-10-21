using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// Gets the database string.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static string GetString(object obj, string defaultValue = "")
        {
            return (obj == DBNull.Value) ? defaultValue : Convert.ToString(obj, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int GetInt(object obj, int defaultValue = 0)
        {
            int value;
            if (obj != DBNull.Value)
            {
                if (Int32.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), out value))
                    return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets the nullable int.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static Nullable<int> GetNullableInt(object obj, Nullable<int> defaultValue = null)
        {
            int value;
            if (obj != DBNull.Value)
            {
                if (Int32.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), out value))
                    return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets the int64.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static Int64 GetInt64(object obj, Int64 defaultValue = 0)
        {
            Int64 value;
            if (obj != DBNull.Value)
            {
                if (Int64.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), out value))
                    return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets the double.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static double GetDouble(object obj, double defaultValue = 0.0)
        {
            double value;
            if (obj != DBNull.Value)
            {
                if (Double.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), out value))
                    return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns></returns>
        public static bool GetBoolean(object obj, bool defaultValue = false)
        {
            bool value;
            if (obj != DBNull.Value)
            {
                string oValue = Convert.ToString(obj, CultureInfo.InvariantCulture);
                if (Boolean.TryParse(oValue, out value))
                    return value;
                else //check if passed value is int; 1 or > = true, 0 or less is false
                {
                    int iValue;
                    if (Int32.TryParse(oValue, out iValue))
                        return iValue > 0;
                    else
                    {
                        if (obj.ToString().Equals("Y"))
                            return true;
                    }
                }
            }
            return defaultValue;
        }
        
        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static bool? GetNullableBoolean(object obj)
        {
            bool value;
            if (obj != DBNull.Value)
            {
                string oValue = Convert.ToString(obj, CultureInfo.InvariantCulture);
                
                if (Boolean.TryParse(oValue, out value))
                    return value;
                else //check if passed value is int; 1 or > = true, 0 or less is false
                {
                    int iValue;
                    if (Int32.TryParse(oValue, out iValue))
                    {
                        if (iValue == 0)
                        {
                            return false;
                        }
                        else if (iValue == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return null;
        }
        
        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="format">The format.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static string GetDateTimeString(object obj, string format = "{0:MM/dd/yyyy H:mm:ss}", string defaultValue = "")
        {
            DateTime dateTime;
            if (obj != DBNull.Value)
            {
                if (DateTime.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), out dateTime))
                   return string.Format(format, dateTime);
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static DateTime? GetDateTime(object obj)
        {
            DateTime dateTime;
            if (obj != DBNull.Value)
            {
                if (DateTime.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), out dateTime))
                    return dateTime;

                string dt = obj as string;
                if(dt != null)
                {
                    if (DateTimeHelper.TryParse(dt, out dateTime))
                        return dateTime;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static byte[] GetBytes(object obj, byte[] defaultValue = null)
        {
            return (obj == DBNull.Value) ? defaultValue : (byte[])(obj);
        }

        /// <summary>
        /// Gets the SQL parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <param name="isNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns></returns>
        public static SqlParameter GetSqlParameter(string paramName, string paramValue, bool isNullable)
        {
            paramValue = string.IsNullOrEmpty(paramValue) ? string.Empty : paramValue;
            if (isNullable && paramValue.Length == 0)
                return new SqlParameter(paramName, DBNull.Value);
            else
                return new SqlParameter(paramName, paramValue);
        }

        /// <summary>
        /// Gets the SQL parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">if set to <c>true</c> [parameter value].</param>
        /// <returns></returns>
        public static SqlParameter GetSqlParameter(string paramName, byte[] paramValue)
        {
            if (paramValue == null)
                return new SqlParameter(paramName, DBNull.Value);
            else
                return new SqlParameter(paramName, paramValue);
        }

        /// <summary>
        /// Gets the SQL parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <returns></returns>
        public static SqlParameter GetSqlParameter(string paramName, int? paramValue)
        {
            if (!paramValue.HasValue)
                return new SqlParameter(paramName, DBNull.Value);
            else
                return new SqlParameter(paramName, paramValue);
        }

        /// <summary>
        /// Gets the SQL parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <returns></returns>
        public static SqlParameter GetSqlParameter(string paramName, long? paramValue)
        {
            if (!paramValue.HasValue)
                return new SqlParameter(paramName, DBNull.Value);
            else
                return new SqlParameter(paramName, paramValue);
        }

        /// <summary>
        /// Gets the SQL parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <returns></returns>
        public static SqlParameter GetSqlParameter(string paramName, double? paramValue)
        {
            if (!paramValue.HasValue)
                return new SqlParameter(paramName, DBNull.Value);
            else
                return new SqlParameter(paramName, paramValue);
        }

        /// <summary>
        /// Gets the SQL parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">if set to <c>true</c> [parameter value].</param>
        /// <returns></returns>
        public static SqlParameter GetSqlParameter(string paramName, bool? paramValue)
        {
            if (!paramValue.HasValue)
                return new SqlParameter(paramName, DBNull.Value);
            else
                return new SqlParameter(paramName, paramValue.Value);
        }

        /// <summary>
        /// Gets the SQL parameter.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <returns></returns>
        public static SqlParameter GetSqlParameter(string paramName, DateTime? paramValue)
        {
            if (!paramValue.HasValue)
                return new SqlParameter(paramName, DBNull.Value);
            else
                return new SqlParameter(paramName, paramValue.Value);
        }

        /// <summary>
        /// Returns true if the given column name exists in the reader, else return false;
        /// </summary>
        /// <param name="reader">The data reader.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>
        /// Returns true if column exists, false otherwise.
        /// </returns>
        public static bool ColumnExists(IDataRecord reader, string columnName)
        {
            if (reader == null || string.IsNullOrWhiteSpace(columnName)) return false;
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}