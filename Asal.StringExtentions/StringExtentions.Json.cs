using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asal.StringExtentions
{
    /// <summary>
    /// JSON related string extension helpers.
    /// </summary>
    public static partial class StringExtentions
    {
        #region Json extensions

        /// <summary>
        /// Extract value for a specific property key/name in JSON body.
        /// </summary>
        public static T ExtractJsonPropertyValue<T>(this string jsonBody, string jsonProperty)
        {
            if (string.IsNullOrWhiteSpace(jsonBody))
                throw new ArgumentNullException(nameof(jsonBody));

            if (string.IsNullOrWhiteSpace(jsonProperty))
                throw new ArgumentNullException(nameof(jsonProperty));

            var token = JObject.Parse(jsonBody).SelectToken(jsonProperty);

            if (token is null)
                throw new InvalidOperationException($"Property '{jsonProperty}' not found.");

            return token.Value<T>()!;
        }

        /// <summary>
        /// Try to extract value for a specific property key/name in JSON body.
        /// </summary>
        public static bool TryExtractJsonPropertyValue<T>(this string jsonBody, string jsonProperty, out T? result)
        {
            try
            {
                result = jsonBody.ExtractJsonPropertyValue<T>(jsonProperty);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Extract values from JSON array property.
        /// Supports arrays of primitives and objects.
        /// </summary>
        public static IEnumerable<T> ExtractJsonArrayPropertyValue<T>(this string jsonBody, string jsonProperty)
        {
            if (string.IsNullOrWhiteSpace(jsonBody))
                throw new ArgumentNullException(nameof(jsonBody));

            if (string.IsNullOrWhiteSpace(jsonProperty))
                throw new ArgumentNullException(nameof(jsonProperty));

            var tokens = JObject.Parse(jsonBody).SelectTokens(jsonProperty);

            return tokens
                .SelectMany(t =>
                    t.Type == JTokenType.Array
                        ? t.Children().Select(c => c.ToObject<T>())
                        : new[] { t.ToObject<T>() })
                .Where(x => x != null)!
                .Select(x => x!);
        }

        /// <summary>
        /// Try extract values from JSON array property.
        /// </summary>
        public static bool TryExtractJsonArrayPropertyValue<T>(this string jsonBody, string jsonProperty, out IEnumerable<T>? result)
        {
            try
            {
                result = jsonBody.ExtractJsonArrayPropertyValue<T>(jsonProperty);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        #endregion
    }
}