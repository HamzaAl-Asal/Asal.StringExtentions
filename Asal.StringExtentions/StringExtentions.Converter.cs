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
        /// Converts the given XML string to a JSON string.
        /// </summary>
        public static string XmlToJson(this string xmlStr)
        {
            if (string.IsNullOrWhiteSpace(xmlStr))
                return string.Empty;

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlStr);

            return JsonConvert.SerializeXmlNode(xmlDocument);
        }

        #endregion

        #region Json To Xml

        /// <summary>
        /// Converts the given JSON string to XML.
        /// </summary>
        public static string JsonToXml(
            this string jsonStr,
            string? deserializeRootElementName = null,
            bool writeArrayAttribute = false,
            bool encodeSpecialCharacters = false)
        {
            if (string.IsNullOrWhiteSpace(jsonStr))
                return string.Empty;

            var xmlDocument = JsonConvert.DeserializeXmlNode(
                jsonStr,
                deserializeRootElementName,
                writeArrayAttribute,
                encodeSpecialCharacters);

            return xmlDocument?.InnerXml ?? string.Empty;
        }

        #endregion

        #region Json To Yaml

        /// <summary>
        /// Converts the given JSON string to a YAML string.
        /// </summary>
        public static string JsonToYaml(this string jsonStr)
        {
            if (string.IsNullOrWhiteSpace(jsonStr))
                return string.Empty;

            var expConverter = new ExpandoObjectConverter();
            var serializer = new Serializer();

            var deserializedObj =
                JsonConvert.DeserializeObject<ExpandoObject>(jsonStr, expConverter);

            return serializer
                .Serialize(deserializedObj)
                .Trim();
        }

        #endregion

        #region Yaml To Json

        /// <summary>
        /// Converts the given YAML string to a JSON string.
        /// </summary>
        public static string YamlToJson(this string yamlStr)
        {
            if (string.IsNullOrWhiteSpace(yamlStr))
                return string.Empty;

            using var stringReader = new StringReader(yamlStr);

            var deserializedObj = new Deserializer()
                .Deserialize(stringReader);

            var serializer = new SerializerBuilder()
                .JsonCompatible()
                .Build();

            return serializer
                .Serialize(deserializedObj)
                .Trim();
        }

        #endregion
    }
}