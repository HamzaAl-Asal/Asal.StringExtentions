using System.Text.RegularExpressions;

namespace Asal.StringExtentions
{
    public class StringExtentionsHelper
    {
        #region Clear Special Characters
        /// <summary>
        /// Clear the special character(s) from the string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="replaceSpecialCharWithSpace"></param>
        /// <returns>A new string that not contain any special character(s)</returns>
        public static async Task<string> ClearSpecialCharacters(string str, bool replaceSpecialCharWithSpace)
        {
            if (string.IsNullOrWhiteSpace(str))
                return await Task.FromResult(string.Empty);

            var result = Regex.Replace(str, RegularExpressionConstant.removeSpecialCharacters, replaceSpecialCharWithSpace ? " " : "").Trim();
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Clear the special character(s) from the list of string
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="replaceSpecialCharWithSpace"></param>
        /// <returns>List of string that do not contains special character(s)</returns>
        public static async Task<List<string>> ClearSpecialCharacters(List<string> strings, bool replaceSpecialCharWithSpace)
        {
            if (!strings.Any())
                return await Task.FromResult(new List<string>());

            var result = new List<string>();
            foreach (var str in strings)
            {
                result.Add(Regex.Replace(str, RegularExpressionConstant.removeSpecialCharacters, replaceSpecialCharWithSpace == true ? " " : "").Trim());
            }

            return await Task.FromResult(result);
        }
        #endregion

        #region Separate string
        /// <summary>
        /// Separate the string with space(s)
        /// </summary>
        /// <param name="str"></param>
        /// <returns>A new separated string</returns>
        public static async Task<string> GetSeparatedString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return await Task.FromResult(string.Empty);


            return await Task.FromResult(Regex.Replace(str, RegularExpressionConstant.separateWordsWithSpaces, " $1"));
        }

        /// <summary>
        /// Separate list of string with space(s)
        /// </summary>
        /// <param name="strings"></param>
        /// <returns>A new list of separated strings</returns>
        public static Task<List<string>> GetSeparatedString(List<string> strings)
        {
            if (!strings.Any())
                return Task.FromResult(new List<string>());

            var result = new List<string>();
            foreach (var str in strings)
            {
                result.Add(Regex.Replace(str, RegularExpressionConstant.separateWordsWithSpaces, " $1"));
            }

            return Task.FromResult(result);
        }
        #endregion

        #region Clear Digits from string
        /// <summary>
        /// Clear digit(s) from string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="replaceDigitsWithSpace"></param>
        /// <returns>A new string that not contain any digits</returns>
        public static async Task<string> ClearDigitsFromString(string str, bool replaceDigitsWithSpace)
        {
            if (string.IsNullOrWhiteSpace(str))
                return await Task.FromResult(string.Empty);


            return await Task.FromResult(Regex.Replace(str, RegularExpressionConstant.removeDigitsFromString, replaceDigitsWithSpace == true ? " " : "").Trim());
        }

        /// <summary>
        /// Clear digit(s) from string
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="replaceDigitsWithSpace"></param>
        /// <returns>A new list of strings that not contains digit(s) in each string</returns>
        public static async Task<List<string>> ClearDigitsFromString(List<string> strings, bool replaceDigitsWithSpace)
        {
            if (!strings.Any())
                return await Task.FromResult(new List<string>());

            var result = new List<string>();
            foreach (var str in strings)
            {
                result.Add(Regex.Replace(str, RegularExpressionConstant.removeDigitsFromString, replaceDigitsWithSpace == true ? " " : "").Trim());
            }

            return await Task.FromResult(result);
        }
        #endregion

        #region Check E-mail
        /// <summary>
        /// Check if the email is valid or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns>True: if the e-mail is valid, Otherwise False</returns>
        public static async Task<bool> IsValidEmail(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || !str.Contains('@'))
                return await Task.FromResult(false);

            return await Task.FromResult(Regex.IsMatch(str, RegularExpressionConstant.emailRegex));
        }

        /// <summary>
        /// Check e-mail status
        /// </summary>
        /// <param name="strings"></param>
        /// <returns>List of e-mail statuses <br/> True: if valid email, Otherwise False</returns>
        public static async Task<Dictionary<string, bool>> GetEmailsStatus(List<string> emails)
        {
            if (!emails.Any())
                return await Task.FromResult(new Dictionary<string, bool>());

            var emailsList = new Dictionary<string, bool>();
            foreach (var email in emails)
            {
                emailsList.Add(email, Regex.IsMatch(email, RegularExpressionConstant.emailRegex));
            }
            return await Task.FromResult(emailsList);
        }
        #endregion

        #region Extract valid Emails from string
        /// <summary>
        /// Extract e-mail(s) from the giving string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>List of valid e-mail(s) </returns>
        public static async Task<List<string>> ExtractEmailsFromString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return await Task.FromResult(new List<string>());

            var emails = new Regex(RegularExpressionConstant.basicEmail)
                .Matches(str)
                .Cast<Match>()
                .Select(x => x.Value)
                .ToList();

            return await Task.FromResult(emails.Where(x => Regex.IsMatch(x, RegularExpressionConstant.emailRegex)).ToList());
        }
        #endregion
    }
}