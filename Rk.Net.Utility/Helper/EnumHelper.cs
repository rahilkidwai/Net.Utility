using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Returns the string representation of the given enumerator.
        /// </summary>
        /// <param name="enumerator">The enumerator.</param>
        /// <returns>Enumerator description.</returns>
        public static string GetDescription(Enum enumerator)
        {
            FieldInfo fieldInfo = enumerator.GetType().GetField(enumerator.ToString());
            DescriptionAttribute[] attributes=null;
            if(fieldInfo != null) attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return enumerator.ToString();
            }
        }

        /// <summary>
        /// Returns the list containing key value pairs of a given enumeration type.
        /// </summary>
        /// <param name="type">The type of enum.</param>
        /// <returns>Returns list of key value pairs.</returns>
        public static IList<KeyValuePair<int, string>> GetList(Type type)
        {
            Array values = Enum.GetValues(type);
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>(values.Length);
            foreach (Enum value in values)
            {
                list.Add(new KeyValuePair<int, string>(Convert.ToInt32(value, CultureInfo.InvariantCulture), GetDescription(value)));
            }
            return list;
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator">The enumerator.</param>
        /// <returns></returns>
        public static T GetAttribute<T>(Enum enumerator) where T : Attribute
        {
            FieldInfo fieldInfo = enumerator.GetType().GetField(enumerator.ToString());
            T[] attributes = (T[])fieldInfo.GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? attributes[0] : null;
        }

        /// <summary>
        /// Gets the attribute property value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerator">The enumerator.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static string GetAttributePropertyValue<T>(Enum enumerator, string propertyName) where T : Attribute
        {
            FieldInfo fieldInfo = enumerator.GetType().GetField(enumerator.ToString());
            T[] attributes = (T[])fieldInfo.GetCustomAttributes(typeof(T), false);
            if (attributes.Length > 0)
            {
                var type = attributes[0].GetType();
                if (type.GetProperty(propertyName) != null)
                {
                    return type.GetProperty(propertyName).GetValue(attributes[0], null).ToString();
                }
                else
                {
                    return attributes[0].ToString();
                }
            }
            return enumerator.ToString();
        }
    }
}