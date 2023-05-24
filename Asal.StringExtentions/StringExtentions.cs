using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Asal.StringExtentions
{
    /// <summary>
    /// StringExtentions.cs
    /// </summary>
    public static partial class StringExtentions
    {
        #region Clear Special Characters

        /// <summary>
        /// Clear the special character(s) from the string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="replaceSpecialCharWithSpace"></param>
        /// <returns>A new string that not contain any special character(s)</returns>
        public static string ClearSpecialCharacters(this string str, bool replaceSpecialCharWithSpace = false)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return Regex.Replace(str, RegularExpressionConstant.removeSpecialCharacters, replaceSpecialCharWithSpace ? " " : "").Trim();
        }

        #endregion

        #region Humanize

        /// <summary>
        /// Humanized the input string with space
        /// </summary>
        /// <param name="str">The string to be humanized</param>
        /// <returns></returns>
        public static string Humanize(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return Regex.Replace(str, RegularExpressionConstant.separateWordsWithSpaces, " $1");
        }

        #endregion

        #region Clear Digits

        /// <summary>
        /// Clear digit(s) from string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="replaceDigitsWithSpace"></param>
        /// <returns>A new string that not contain any digits</returns>
        public static string ClearDigits(this string str, bool replaceDigitsWithSpace = false)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return Regex.Replace(str, RegularExpressionConstant.removeDigitsFromString, replaceDigitsWithSpace ? " " : "").Trim();
        }

        #endregion

        #region Slugify
        /// <summary>  
        /// Turn a string into a slug by removing all accents,   
        /// special characters, additional spaces, substituting   
        /// spaces with hyphens and making it lower-case.  
        /// </summary>  
        /// <param name="text">The string to turn into a slug.</param>  
        /// <returns>A string that slugified</returns>  
        public static string Slugify(this string text)
        {
            var result = text.RemoveAccents().ToLowerInvariant();

            // Remove all special characters from the string.  
            result = Regex.Replace(result, @"[^A-Za-z0-9\s-]", "");

            // Remove all additional spaces in favour of just one.  
            result = Regex.Replace(result, @"\s+", " ").Trim();

            // Replace all spaces with the hyphen.  
            result = Regex.Replace(result, @"\s", "-");

            return result;
        }

        /// <summary>  
        /// Removes all accents from the input string.  
        /// </summary>  
        /// <param name="text">The input string.</param>  
        /// <returns></returns>  
        private static string RemoveAccents(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            char[] chars = text
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c)
                != UnicodeCategory.NonSpacingMark).ToArray();

            return new string(chars).Normalize(NormalizationForm.FormC);
        }
        #endregion
    }
}