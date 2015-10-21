using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class SecurityHelper
    {        
        /// <summary>
        /// The hexadecimal table
        /// </summary>
        public static string[] HexTable = Enumerable.Range(0, 256).Select(v => v.ToString("X2")).ToArray();

        #region Methods
        /// <summary>
        /// Calculates the m d5.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string CalculateMD5(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            MD5 md5 = MD5.Create();
            string md5String = Regex.Replace(value, @"\s", string.Empty).ToLowerInvariant();
            byte[] inputBytes = Encoding.ASCII.GetBytes(md5String); // Converted the string to lowercase
            byte[] hash = md5.ComputeHash(inputBytes);
            return ToHex(hash);
        }

        /// <summary>
        /// Converts byte array to the hexadecimal.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string ToHex(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes) sb.Append(HexTable[b]);
            return sb.ToString();
        } 
        #endregion
    }
}