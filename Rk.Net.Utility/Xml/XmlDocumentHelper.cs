using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Rk.Net.Utility
{
    /// <summary>
    /// Helper class for object serialization and deserialization.
    /// </summary>
    public static class XmlDocumentHelper
    {
        public static void SetAttribute(XmlElement Element, string Name, object Value)
        {
            Element.SetAttribute(Name, Value.ToString());
        }

        public static void SetAttribute(XmlElement Element, string Name, object Value, string DefaultValue)
        {
            if (Value == null || string.Compare(Value.ToString(), DefaultValue) == 0)
            {
                Element.RemoveAttribute(Name);
            }

            else
            {
                Element.SetAttribute(Name, Value.ToString());
            }
        }
    }
}
