using System.Security.Cryptography;
using System.Text;

namespace Asal.StringExtentions
{
    /// <summary>
    /// StringExtentions.cs
    /// </summary>
    public static partial class StringExtentions
    {
        private const string HexadecimalStringFormat = "x2";

        /// <summary>
        /// Calculates the MD5 checksum (hash) of the input string.
        /// </summary>
        /// <param name="str">The input string to calculate the MD5 checksum for.</param>
        /// <returns>The MD5 checksum (hash) of the input string as a hexadecimal string.</returns>
        public static string CalculateMD5Checksum(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            using var md5 = MD5.Create();
            byte[] encodedStr = Encoding.UTF8.GetBytes(str);
            byte[] hashedBytes = md5.ComputeHash(encodedStr);

            return ToHexadecimalString(hashedBytes);
        }

        private static string ToHexadecimalString(byte[] hashedBytes)
        {
            var stringBuilder = new StringBuilder(hashedBytes.Length * 2);

            foreach (byte hashedByte in hashedBytes)
            {
                stringBuilder.Append(hashedByte.ToString(HexadecimalStringFormat));
            }

            return stringBuilder.ToString();
        }
    }
}