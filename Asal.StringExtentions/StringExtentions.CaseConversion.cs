using System;

namespace Asal.StringExtentions
{
    /// <summary>
    /// StringExtentions.cs
    /// </summary>
    public static partial class StringExtentions
    {
        /// <summary>
        /// Converts the input string to camelCase format.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns>The input string converted to camelCase format.</returns>
        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string[] stringChars = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            stringChars[0] = stringChars[0].ToLowerInvariant();

            for (int i = 1; i < stringChars.Length; i++)
            {
                stringChars[i] = char.ToUpperInvariant(stringChars[i][0]) + stringChars[i].Substring(1).ToLowerInvariant();
            }

            return string.Concat(stringChars);
        }

        /// <summary>
        /// Converts the input string to PascalCase format.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns>The input string converted to PascalCase format.</returns>
        public static string ToPascalCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string[] stringChars = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = char.ToUpper(stringChars[i][0]) + stringChars[i].Substring(1);
            }

            return string.Join("", stringChars);
        }

        /// <summary>
        /// Converts the input string to snake_case format.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns>The input string converted to snake_case format.</returns>
        public static string ToSnakeCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Replace(" ", "_").ToLower();
        }

        /// <summary>
        /// Converts the input string to kebab-case format.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns>The input string converted to kebab-case format.</returns>
        public static string ToKebabCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Replace(" ", "-").ToLower();
        }
    }
}