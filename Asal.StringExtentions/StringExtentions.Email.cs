using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Asal.StringExtentions
{
    /// <summary>
    /// StringExtentions.cs
    /// </summary>
    public static partial class StringExtentions
    {
        #region Check E-mail

        /// <summary>
        /// Check if the email is valid or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns>True: if the e-mail is valid, Otherwise False</returns>
        public static bool IsValidEmail(this string str)
        {
            if (string.IsNullOrWhiteSpace(str) || !str.Contains('@'))
                return false;

            return Regex.IsMatch(str, RegularExpressionConstant.emailRegex);
        }

        #endregion

        #region Extract valid Emails 

        /// <summary>
        /// Extract valid e-mail(s) from the giving string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>List of valid e-mail(s) </returns>
        public static IEnumerable<string> ExtractEmails(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return Enumerable.Empty<string>();

            var extractedEmails = new Regex(RegularExpressionConstant.basicEmail)
                .Matches(str)
                .Cast<Match>()
                .Select(x => x.Value)
                .ToList();

            return extractedEmails.Where(x => Regex.IsMatch(x, RegularExpressionConstant.emailRegex)).ToList();
        }

        #endregion
    }
}