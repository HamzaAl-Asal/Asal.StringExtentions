using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asal.StringExtentions
{
    /// <summary>
    /// StringExtentions.cs
    /// </summary>
    public static partial class StringExtentions
    {
        #region Json extentions
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

            return jObjectParse.SelectToken(jsonProperty)
                               .Value<T>();
        }

        /// <summary>
        /// Try to extract value for a specific property key/name in Json body
        /// </summary>
        /// <param name="jsonBody">Represents json body</param>
        /// <param name="jsonProperty">Represents json property that need to retrieve value for it</param>
        /// <param name="result">Represents out result</param>
        /// <returns>True: if the call success and return result in out result param, Otherwise: False </returns>
        public static bool TryExtractJsonPropertyValue<T>(this string jsonBody, string jsonProperty, out T result)
        {
            try
            {
                result = jsonBody.ExtractJsonPropertyValue<T>(jsonProperty);
                return true;
            }
            catch (Exception e)
            {
                result = default(T);
                return false;
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

            return jObjectParse.SelectTokens(jsonProperty)
                               .Children()
                               .Select(x => x.Value<T>());
        }

        /// <summary>
        /// Try extract values from json array
        /// </summary>
        /// <param name="jsonBody">Represents json body</param>
        /// <param name="jsonProperty">Represents json property that need to retrieve value for it</param>
        /// <param name="result">Represents out result</param>
        /// <returns>True: if the call success and return result in out result param, Otherwise: False </returns>
        public static bool TryExtractJsonArrayPropertyValue<T>(this string jsonBody, string jsonProperty, out IEnumerable<T> result)
        {
            try
            {
                result = jsonBody.ExtractJsonArrayPropertyValue<T>(jsonProperty);
                return true;
            }
            catch (Exception e)
            {
                result = default(IEnumerable<T>);
                return false;
            }
        }
        #endregion
    }
}