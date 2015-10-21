using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Rk.Net.Utility
{
    /// <summary>
    /// Helper class for object serialization and deserialization.
    /// </summary>
    public static class XmlSerializerHelper
    {
        #region Methods
        /// <summary>
        /// Serializes the specified object to serialize.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public static string Serialize(object objectToSerialize)
        {
            if (objectToSerialize == null) return string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(objectToSerialize.GetType());
                serializer.WriteObject(stream, objectToSerialize);
                stream.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns>Serialized xml.</returns>
        public static string Serialize<T>(T objectToSerialize)
        {
            if (objectToSerialize == null) return string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(stream, objectToSerialize);
                stream.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <param name="writer">The writer.</param>
        public static void Serialize<T>(T objectToSerialize, XmlWriter writer)
        {
            if (objectToSerialize == null || writer == null) return;
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(writer, objectToSerialize);
        }

        /// <summary>
        /// Deserializes the specified XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml) where T : class
        {
            if (string.IsNullOrWhiteSpace(xml)) return null;
            xml = xml.Trim().Replace("\0", string.Empty); //replace null characters with empty string, otherwise serialization will fail
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml)))
            {
                stream.Seek(0, SeekOrigin.Begin);
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }

        /// <summary>
        /// Creates the XML.
        /// </summary>
        /// <param name="objectToCreateXML">The object to create XML.</param>
        /// <returns></returns>
        public static XmlDocument CreateXML(object objectToCreateXML)
        {
            XmlDocument xmlDoc = new XmlDocument();   
            XmlSerializer xmlSerializer = new XmlSerializer(objectToCreateXML.GetType());
            
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, objectToCreateXML);
                xmlStream.Position = 0;            
                xmlDoc.Load(xmlStream);
                return xmlDoc;
            }
        }
        #endregion
    }
}