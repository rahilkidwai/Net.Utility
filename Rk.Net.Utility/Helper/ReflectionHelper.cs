using System;
using System.Reflection;
using System.Text;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Gets the object string.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetObjectString(object obj)
        {
            if (obj == null) return "NULL";
            StringBuilder buffer = new StringBuilder();
            Type self = obj.GetType();
            foreach (PropertyInfo prop in self.GetProperties())
            {
                try
                {
                    buffer.Append(prop.Name);
                    buffer.Append(" = ");
                    buffer.AppendLine(prop.GetValue(obj, null).ToString());
                }
                catch (Exception e)
                {
                    buffer.AppendLine(e.Message);
                }
            }
            return buffer.ToString();
        }
    }
}