
using Newtonsoft.Json;
using System;
using System.Xml;

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
    }
}