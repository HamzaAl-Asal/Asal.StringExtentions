namespace Asal.StringCleaner
{
    public static class RegularExpressionConstant
    {
        public const string removeSpecialCharacters = @"[^0-9a-zA-Z]+";
        public const string separateWordsWithSpaces = @"(?<=[a-z])([A-Z])";
        public const string removeDigitsFromString = @"[\d-]";
        public const string emailRegex = "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
        public const string basicEmail = "\\S+@\\S+\\.\\S+";
    }
}
