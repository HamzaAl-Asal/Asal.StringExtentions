using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asal.StringExtentions
{
    /// <summary>
    /// StringExtentions.cs
    /// </summary>
    public static partial class StringExtentions
    {
        #region Json
        /// <summary>
        /// Extract value for a specific property key/name in Json body
        /// </summary>
        /// <param name="jsonBody">Represents json body</param>
        /// <param name="jsonProperty">Represents json property that need to retrieve value for it</param>
        /// <returns>Extracted property value</returns>
        public static T ExtractJsonPropertyValue<T>(this string jsonBody, string jsonProperty)
        {
            if (string.IsNullOrEmpty(jsonBody))
                throw new ArgumentNullException(nameof(jsonBody));

            if (string.IsNullOrEmpty(jsonProperty))
                throw new ArgumentNullException(nameof(jsonProperty));

            var jObjectParse = JObject.Parse(jsonBody);

            try
            {
                return jObjectParse.SelectToken(jsonProperty).Value<T>();
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Extract values from json array
        /// </summary>
        /// <param name="jsonBody">Represents json body</param>
        /// <param name="jsonProperty">Represents json property that need to retrieve value for it</param>
        /// <returns>Json array values</returns>
        public static IEnumerable<T> ExtractJsonArrayPropertyValue<T>(this string jsonBody, string jsonProperty)
        {
            if (string.IsNullOrEmpty(jsonBody))
                throw new ArgumentNullException(nameof(jsonBody));

            if (string.IsNullOrEmpty(jsonProperty))
                throw new ArgumentNullException(nameof(jsonProperty));

            var jObjectParse = JObject.Parse(jsonBody);

            try
            {
                return jObjectParse.SelectTokens(jsonProperty)
                .Children()
                .Select(x => x.Value<T>());
            }
            catch
            {
                return default(IEnumerable<T>);
            }
        }
        #endregion
    }
}