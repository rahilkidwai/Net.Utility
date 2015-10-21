using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rk.Net.Utility
{
    /// <summary>
    /// The cryptography helper class.
    /// </summary>
    public static class CryptographyHelper
    {
        private static string[] HexTable = Enumerable.Range(0, 256).Select(v => v.ToString("X2")).ToArray();
        
        #region Methods
        /// <summary>
        /// Encrypts the given text based on given key and salt.
        /// </summary>
        /// <param name="textToEncrypt">The text to encrypt.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static string EncryptText(string textToEncrypt, string key, string salt)
        {
            if (string.IsNullOrWhiteSpace(textToEncrypt)) return null;
            if (string.IsNullOrWhiteSpace(key)) return null;
            if (string.IsNullOrWhiteSpace(salt)) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    using (AesManaged aes = new AesManaged())
                    {
                        Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(key, Encoding.UTF8.GetBytes(salt));
                        aes.Key = deriveBytes.GetBytes(128 / 8);
                        ms.Write(BitConverter.GetBytes(aes.IV.Length), 0, sizeof(int));
                        ms.Write(aes.IV, 0, aes.IV.Length);
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            byte[] bytesFromText = Encoding.Unicode.GetBytes(textToEncrypt);
                            cs.Write(bytesFromText, 0, bytesFromText.Length);
                            cs.FlushFinalBlock();
                        }
                        return BytesToBase64String(ms.ToArray());// Return the encrypted bytes from the memory stream and convert to Base64                        
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Decrypts the text based on given key and salt.
        /// </summary>
        /// <param name="textToDecrypt">The text to decrypt.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static string DecryptText(string textToDecrypt, string key, string salt)
        {
            if (string.IsNullOrWhiteSpace(textToDecrypt)) return string.Empty;
            if (string.IsNullOrWhiteSpace(key)) return string.Empty;
            byte[] byteData = Base64StringToBytes(textToDecrypt);
            using (MemoryStream ms = new MemoryStream(byteData))
            {
                try
                {
                    using (AesManaged aes = new AesManaged())
                    {
                        Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(key, Encoding.UTF8.GetBytes(salt));
                        aes.Key = deriveBytes.GetBytes(128 / 8);
                        // Get the initialization vector from the encrypted stream.
                        byte[] rawLength = new byte[sizeof(int)];
                        if (ms.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
                        {
                            // Stream did not contain properly formatted byte array.
                            return string.Empty;
                        }
                        byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
                        if (ms.Read(buffer, 0, buffer.Length) != buffer.Length)
                        {
                            // Did not read byte array properly.
                            return string.Empty;
                        }
                        aes.IV = buffer;
                        CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
                        // Get text from bytes.
                        StreamReader sr = new StreamReader(cs, Encoding.Unicode);
                        string plaintext = sr.ReadToEnd();
                        if (sr != null) sr.Close();
                        sr.Dispose();
                        if (cs != null) cs.Close();
                        cs.Dispose();
                        return plaintext;
                    }
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Base64 to text.
        /// </summary>
        /// <param name="text_Base64">The text_ base64.</param>
        /// <returns></returns>
        public static string Base64StringToUTF8String(string text_Base64)
        {
            // Base64 text to byte[].
            byte[] byteData;
            byteData = Convert.FromBase64String(text_Base64);
            // Byte to Text.
            UTF8Encoding textConverter = new UTF8Encoding();
            return textConverter.GetString(byteData, 0, byteData.Length);
        }

        /// <summary>
        /// Texts to bytes.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        /// byte[]
        /// </returns>
        public static byte[] UTF8StringToBytes(string text)
        {
            if (text.Length != 0)
            {
                UTF8Encoding textConverter = new UTF8Encoding();
                return textConverter.GetBytes(text);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Base64 to bytes.
        /// </summary>
        /// <param name="text_Base64">The text_ base64.</param>
        /// <returns>
        /// byte[]
        /// </returns>
        public static byte[] Base64StringToBytes(string text_Base64)
        {
            text_Base64 = text_Base64.Replace(" ", "+");
            return Convert.FromBase64String(text_Base64);
        }

        /// <summary>
        /// Bytes to text.
        /// </summary>
        /// <param name="byteData">The byte data.</param>
        public static string BytesToUTF8String(byte[] byteData)
        {
            if (byteData != null)
            {
                UTF8Encoding textConverter = new UTF8Encoding();
                return textConverter.GetString(byteData, 0, byteData.Length);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Bytes to base64.
        /// </summary>
        /// <param name="byteData">The byte data.</param>
        public static string BytesToBase64String(byte[] byteData)
        {
            return Convert.ToBase64String(byteData);
        }

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetBase64Hash(string value)
        {
            byte[] bytesPass = Encoding.UTF8.GetBytes(value);
            SHA256Managed sha = new SHA256Managed();
            byte[] bytesHash = sha.ComputeHash(bytesPass);
            sha.Clear();
            return Convert.ToBase64String(bytesHash);
        }
                
        /// <summary>
        /// Ciphers the text using ROT13 ciphering technique.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns></returns>
        public static string ROT13CipherText(string plainText)
        {
            return ROT13Transform(plainText);
        }

        /// <summary>
        /// Deciphers the text, ciphered using ROT13 cipher.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public static string ROT13DecipherText(string cipherText)
        {
            return ROT13Transform(cipherText);
        }

        private static string ROT13Transform(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            char[] array = value.ToCharArray();
            int ascii;
            for (int i = 0; i < array.Length; i++)
            {
                ascii = array[i];
                if (ascii >= 'a' && ascii <= 'z')
                {
                    if (ascii > 'm')
                    {
                        ascii -= 13;
                    }
                    else
                    {
                        ascii += 13;
                    }
                }
                else if (ascii >= 'A' && ascii <= 'Z')
                {
                    if (ascii > 'M')
                    {
                        ascii -= 13;
                    }
                    else
                    {
                        ascii += 13;
                    }
                }
                array[i] = (char)ascii;
            }
            return new string(array);
        }

        /// <summary>
        /// Gets the md5 hash.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="purgeSpaces">if set to <c>true</c> [purge spaces].</param>
        /// <param name="isCaseSensitive">if set to <c>true</c> [is case sensitive].</param>
        /// <returns></returns>
        public static string GetMD5Hash(string value, bool purgeSpaces, bool isCaseSensitive)
        {
            MD5 md5 = MD5.Create();
            if (purgeSpaces)
                value = value.Replace(" ", string.Empty);
            if (!isCaseSensitive)
                value = value.ToLowerInvariant();
            byte[] inputBytes = Encoding.ASCII.GetBytes(value); // Converted the string to lowercase
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