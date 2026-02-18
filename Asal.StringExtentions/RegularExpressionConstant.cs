namespace Asal.StringExtentions
{
    /// <summary>
    /// Contains reusable regular expression patterns used across the library.
    /// </summary>
    internal static class RegularExpressionConstant
    {
        /// <summary>
        /// Matches any character that is not a letter or digit.
        /// Used to remove special characters from a string.
        /// </summary>
        public const string RemoveSpecialCharacters = @"[^0-9a-zA-Z]+";

        /// <summary>
        /// Matches capital letters that follow lowercase letters.
        /// Used to separate words in PascalCase or camelCase strings.
        /// Example: "HelloWorld" -> "Hello World"
        /// </summary>
        public const string SeparateWordsWithSpaces = @"(?<=[a-z])([A-Z])";

        /// <summary>
        /// Matches digits and hyphens.
        /// Used to remove digits (and '-' if present) from a string.
        /// </summary>
        public const string RemoveDigitsFromString = @"[\d-]";

        /// <summary>
        /// Strict email validation pattern (RFC-like).
        /// Ensures proper local and domain parts.
        /// </summary>
        public const string Email =
            @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+" +
            @"(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@" +
            @"(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+" +
            @"[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";

        /// <summary>
        /// Basic email extraction pattern.
        /// Used to find potential email candidates in text.
        /// </summary>
        public const string BasicEmail = @"\S+@\S+\.\S+";
    }
}