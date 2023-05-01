
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Dynamic;
using System.IO;
using System.Xml;
using YamlDotNet.Serialization;

namespace Asal.StringExtentions
{
    /// <summary>
    /// StringExtentions.cs
    /// </summary>
    public static partial class StringExtentions
    {
        #region Xml To Json
        /// <summary>
        /// Convert the giving xml to Json string
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <returns>Serialized Json string</returns>
        public static string XmlToJson(this string xmlStr)
        {
            if (string.IsNullOrEmpty(xmlStr))
            {
                return string.Empty;
            }

            try
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlStr);

                var jsonStr = JsonConvert.SerializeXmlNode(xmlDocument);
                return jsonStr;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Json to Xml       
        /// <summary>
        /// Convert the giving Json to Xml
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <param name="deserializeRootElementName"></param>
        /// <param name="writeArrayAttribute"></param>
        /// <param name="encodeSpecialCharacters"></param>
        /// <returns>Deserialized Xml</returns>
        public static string JsonToXml(this string jsonStr, string deserializeRootElementName = "root", bool writeArrayAttribute = false, bool encodeSpecialCharacters = false)
        {
            if (string.IsNullOrEmpty(jsonStr))
            {
                return string.Empty;
            }

            try
            {
                var xmlStr = JsonConvert.DeserializeXmlNode(jsonStr, deserializeRootElementName, writeArrayAttribute, encodeSpecialCharacters).InnerXml;

                return xmlStr;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Json to Yaml
        /// <summary>
        /// Convert the giving Json to Yaml
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns>Yaml string</returns>
        public static string JsonToYaml(this string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
            {
                return string.Empty;
            }

            var expConverter = new ExpandoObjectConverter();
            var serilizer = new Serializer();

            var deserilizedObj = JsonConvert.DeserializeObject<ExpandoObject>(jsonStr, expConverter);

            return serilizer
                .Serialize(deserilizedObj)
                .Trim();
        }
        #endregion

        #region Yaml to Json
        /// <summary>
        /// Convert the giving Yaml to Json string
        /// </summary>
        /// <param name="yamlStr"></param>
        /// <returns>Json string</returns>
        public static string YamlToJson(this string yamlStr)
        {
            if (string.IsNullOrEmpty(yamlStr))
            {
                return string.Empty;
            }

            var stringReader = new StringReader(yamlStr);
            var deserilizedObj = new Deserializer()
                .Deserialize(stringReader);

            var serializerBuilder = new SerializerBuilder()
                .JsonCompatible()
                .Build();

            return serializerBuilder
                .Serialize(deserilizedObj)
                .Trim();
        }
        #endregion
    }
}