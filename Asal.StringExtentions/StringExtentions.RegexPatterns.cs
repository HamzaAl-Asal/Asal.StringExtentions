using System.Text.RegularExpressions;

namespace Asal.StringExtentions
{
    /// <summary>
    /// Holds compiled Regex instances reused across the library.
    /// Improves performance by avoiding repeated pattern parsing.
    /// </summary>
    internal static class RegexPatterns
    {
        internal static readonly Regex RemoveSpecialCharacters =
            new Regex(RegularExpressionConstant.RemoveSpecialCharacters,
                RegexOptions.Compiled);

        internal static readonly Regex SeparateWordsWithSpaces =
            new Regex(RegularExpressionConstant.SeparateWordsWithSpaces,
                RegexOptions.Compiled);

        internal static readonly Regex RemoveDigitsFromString =
            new Regex(RegularExpressionConstant.RemoveDigitsFromString,
                RegexOptions.Compiled);

        internal static readonly Regex Email =
            new Regex(RegularExpressionConstant.Email,
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        internal static readonly Regex BasicEmail =
            new Regex(RegularExpressionConstant.BasicEmail,
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }
}