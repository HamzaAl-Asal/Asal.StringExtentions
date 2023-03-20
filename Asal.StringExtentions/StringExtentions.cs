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
    }
}