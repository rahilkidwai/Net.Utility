using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Rk.Net.Utility
{
    /// <summary>
    /// An object of XmlParser is used to read xml nodes (elements / attributes).
    /// </summary>
    public sealed class XmlParser : IEnumerable
    {
        #region Fields
        private XElement _xElement;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlParser" /> class.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="removeNamespaces">if set to <c>true</c> [remove namespaces].</param>
        public XmlParser(string xml, bool removeNamespaces = false)
        {
            if (!string.IsNullOrWhiteSpace(xml))
            {
                try
                {
                    _xElement = XElement.Parse(xml.Trim());
                    if (removeNamespaces)
                        _xElement = RemoveAllNamespaces(_xElement);
                    IsXmlValid = true;
                    XmlError = string.Empty;
                }
                catch (Exception e)
                {
                    IsXmlValid = false;
                    XmlError = e.Message;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlParser" /> class.
        /// </summary>
        /// <param name="xmlFragment">The XML fragment.</param>
        /// <param name="removeNamespaces">if set to <c>true</c> [remove namespaces].</param>
        public XmlParser(XElement xmlFragment, bool removeNamespaces = false)
        {
            if (xmlFragment != null)
            {
                _xElement = xmlFragment;
                if (removeNamespaces)
                    _xElement = RemoveAllNamespaces(_xElement);
                IsXmlValid = true;
                XmlError = string.Empty;
            }
            else
            {
                IsXmlValid = false;
                XmlError = "Null reference passed for xml fragment";
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether [is XML valid].
        /// </summary>
        public bool IsXmlValid { get; private set; }
        
        /// <summary>
        /// Gets the XML error.
        /// </summary>
        public string XmlError { get; private set; }

        /// <summary>
        /// Gets the root node local name.
        /// </summary>
        public string Root 
        {
            get
            {
                if (IsXmlValid)
                    return _xElement.Name.LocalName;
                else
                    return string.Empty;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the node value (element/ attribute) for the given xpath. 
        /// Returns string.Empty if the xml is not valid (IsXmlValid == false).
        /// Returns string.Empty if supplied xpath is null / empty / string with white spaces only.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public string GetNodeValue(string xpath)
        {
            if (!IsXmlValid) return string.Empty;
            return GetNodeValue(_xElement, xpath);
        }

        /// <summary>
        /// Gets the node value as int.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public Int32 GetNodeValueAsInt32(string xpath, int defaultValue = 0)
        {
            int value = defaultValue;
            if (IsXmlValid)
                Int32.TryParse(GetNodeValue(_xElement, xpath), out value);
            return value;
        }

        /// <summary>
        /// Gets the node value as int64.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public Int64 GetNodeValueAsInt64(string xpath, long defaultValue = 0)
        {
            long value = defaultValue;
            if (IsXmlValid)
                Int64.TryParse(GetNodeValue(_xElement, xpath), out value);
            return value;
        }

        /// <summary>
        /// Gets the node value as double.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public double GetNodeValueAsDouble(string xpath, double defaultValue = 0)
        {
            double value = defaultValue;
            if (IsXmlValid)
                Double.TryParse(GetNodeValue(_xElement, xpath), out value);
            return value;
        }

        /// <summary>
        /// Gets the node value as boolean.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns></returns>
        public bool GetNodeValueAsBoolean(string xpath, bool defaultValue = false)
        {
            bool value = defaultValue;
            if (IsXmlValid)
                Boolean.TryParse(GetNodeValue(_xElement, xpath), out value);
            return value;
        }

        /// <summary>
        /// Gets the node value as date time.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public DateTime? GetNodeValueAsDateTime(string xpath)
        {
            DateTime dateTime;
            string dt = GetNodeValue(_xElement, xpath);
            if (!string.IsNullOrEmpty(dt))
            {
                if (DateTime.TryParse(dt, out dateTime))
                    return dateTime;

                if (DateTimeHelper.TryParse(dt, out dateTime))
                    return dateTime;
            }
            return null;
        }

        /// <summary>
        /// Gets the element for the given xpath. 
        /// Returns null if the xml is not valid (IsXmlValid == false).
        /// Returns null if supplied xpath is null / empty / string with white spaces only.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public XElement GetElement(string xpath)
        {
            if (!IsXmlValid || string.IsNullOrWhiteSpace(xpath)) return null;

            IEnumerable result = (IEnumerable)_xElement.XPathEvaluate(xpath.Trim());

            if (result != null)
            {
                try
                {
                    return result.Cast<XElement>().FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }
        
        /// <summary>
        /// Gets the element string for the given xpath. 
        /// Returns string.Empty if the xml is not valid (IsXmlValid == false).
        /// Returns string.Empty if supplied xpath is null / empty / string with white spaces only.
        /// </summary>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public string GetElementString(string xpath)
        {
            if (!IsXmlValid || string.IsNullOrWhiteSpace(xpath)) return string.Empty;
            
            IEnumerable result = (IEnumerable)_xElement.XPathEvaluate(xpath.Trim());

            if (result != null)
            {
                try
                {
                    XElement element = result.Cast<XElement>().FirstOrDefault();
                    if (element == null) 
                        return string.Empty;
                    else 
                        return element.ToString(SaveOptions.None);
                }
                catch
                {
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns a collection of XElements of the xml in document order.
        /// </summary>
        /// <value>
        /// Returns a collection of XElements of the xml in document order.
        /// </value>
        public IEnumerable<XElement> Elements
        {
            get
            {
                if (IsXmlValid)
                    return _xElement.Elements();
                else
                    return new List<XElement>();
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection of XElements of the xml in document order.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection of XElements of the xml in document order.</returns>
        public IEnumerator GetEnumerator()
        {
            if (IsXmlValid)
            {
                return _xElement.Elements().GetEnumerator();
            }
            else
            {
                return new List<XElement>().GetEnumerator(); // return an empty list
            }
        }

        /// <summary>
        /// Removes all namespaces.
        /// </summary>
        /// <param name="xmlElement">The XML element.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">xmlElement</exception>
        public XElement RemoveAllNamespaces(XElement xmlElement)
        {
            if(xmlElement == null) 
                throw new ArgumentNullException("xmlElement");

            if (!xmlElement.HasElements)
            {
                XElement xElement = new XElement(xmlElement.Name.LocalName);
                xElement.Value = xmlElement.Value;

                foreach (XAttribute attribute in xmlElement.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }

            XElement element = new XElement(xmlElement.Name.LocalName, xmlElement.Elements().Select(el => RemoveAllNamespaces(el)));
            foreach (XAttribute attribute in xmlElement.Attributes())
                element.Add(attribute);

            return element;
        }

        /// <summary>
        /// Gets the node value.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static string GetNodeValue(XElement element, string xpath)
        {
            if (element == null || string.IsNullOrWhiteSpace(xpath)) return string.Empty;
            string value = string.Empty;
            IEnumerable result = (IEnumerable)element.XPathEvaluate(xpath.Trim());
            if (result != null && xpath.Contains("@"))
            {
                XAttribute attribute = result.Cast<XAttribute>().FirstOrDefault();
                if (attribute != null) value = attribute.Value;
            }
            else
            {
                XElement e = result.Cast<XElement>().FirstOrDefault();
                if (e != null) value = e.Value;
            }
            return value;
        }
        #endregion
    }
}