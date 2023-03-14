using System.Text.RegularExpressions;

namespace Asal.StringExtentions
{
    public static class StringExtentionsHelper
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

        #region Separate string by space
        /// <summary>
        /// Separate the string with space(s)
        /// </summary>
        /// <param name="str"></param>
        /// <returns>A new separated string</returns>
        public static string SeparateStringBySpace(this string str)
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

        /// <summary>
        /// Check e-mail status
        /// </summary>
        /// <param name="strings"></param>
        /// <returns>List of e-mail statuses <br/> True: if valid email, Otherwise False</returns>
        public static IDictionary<string, bool> GetEmailsStatus(this IEnumerable<string> emails)
        {
            if (!emails.Any())
                return new Dictionary<string, bool>();

            var emailsList = new Dictionary<string, bool>();
            foreach (var email in emails)
            {
                emailsList.Add(email, email.IsValidEmail());
            }
            return emailsList;
        }
        #endregion

        #region Extract valid Emails from string
        /// <summary>
        /// Extract valid e-mail(s) from the giving string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>List of valid e-mail(s) </returns>
        public static IEnumerable<string> ExtractEmailsFromString(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return Enumerable.Empty<string>();

            var emails = new Regex(RegularExpressionConstant.basicEmail)
                .Matches(str)
                .Cast<Match>()
                .Select(x => x.Value)
                .ToList();

            return emails.Where(x => Regex.IsMatch(x, RegularExpressionConstant.emailRegex)).ToList();
        }
        #endregion
    }
}