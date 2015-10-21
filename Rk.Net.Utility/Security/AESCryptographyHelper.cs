using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Rk.Net.Utility.Security
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AESCryptographyHelper
    {
        #region Fields
        private string _salt;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AESCryptographyHelper"/> class.
        /// </summary>
        /// <param name="salt">The salt.</param>
        /// <exception cref="System.ArgumentNullException">salt</exception>
        /// <exception cref="System.ArgumentException">Invalid salt value.</exception>
        public AESCryptographyHelper(string salt = "PulseNetSecurityEncryption")
        {
            if (salt == null) throw new ArgumentNullException("salt");
            if (string.IsNullOrWhiteSpace(salt)) throw new ArgumentException("Invalid salt value.");
            _salt = salt;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Encrypts the input based on provided salt.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public string Encrypt(string strInput)
        {
            string empty = string.Empty;
            if (strInput != string.Empty && strInput != null)
            {
                AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
                string str = "PulseNetSecurityEncryption";
                byte[] bytes = Encoding.Unicode.GetBytes(strInput);
                byte[] numArray = Encoding.ASCII.GetBytes(str.Length.ToString());
                PasswordDeriveBytes passwordDeriveByte = new PasswordDeriveBytes(str, numArray);
                ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(passwordDeriveByte.GetBytes(16), passwordDeriveByte.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
                cryptoStream.Write(bytes, 0, (int)bytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] array = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                empty = Convert.ToBase64String(array);
            }
            return empty;
        }
        
        //public string Encrypt(string input)
        //{
        //    if (string.IsNullOrEmpty(input)) 
        //        return string.Empty;
            
        //    byte[] inputBytes = System.Text.Encoding.Unicode.GetBytes(input);
        //    byte[] saltBytes = System.Text.Encoding.ASCII.GetBytes(_salt.Length.ToString());

        //    PasswordDeriveBytes secretKey = new PasswordDeriveBytes(_salt, saltBytes);

        //    string output = string.Empty;
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        //AesCryptoServiceProvider is FIPS 140 compliant. FIPS 140 compliance is required for EPCS
        //        using (AesCryptoServiceProvider alg = new AesCryptoServiceProvider())
        //        {
        //            ICryptoTransform encryptor = alg.CreateEncryptor(secretKey.GetBytes(16), secretKey.GetBytes(16));

        //            using(CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        //            {
        //                cryptoStream.Write(inputBytes, 0, inputBytes.Length);
        //                cryptoStream.FlushFinalBlock();
        //                byte[] cipherBytes = memoryStream.ToArray();
        //                output = Convert.ToBase64String(cipherBytes);
        //            }
        //        }
        //    }

        //    return output;
        //}

        public string Decrypt(string strInput)
        {
            string empty = string.Empty;
            if (strInput != string.Empty && strInput != null)
            {
                AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
                string str = "PulseNetSecurityEncryption";
                byte[] numArray = Convert.FromBase64String(strInput);
                byte[] bytes = Encoding.ASCII.GetBytes(str.Length.ToString());
                PasswordDeriveBytes passwordDeriveByte = new PasswordDeriveBytes(str, bytes);
                ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(passwordDeriveByte.GetBytes(16), passwordDeriveByte.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(numArray);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
                byte[] numArray1 = new byte[(int)numArray.Length];
                int num = cryptoStream.Read(numArray1, 0, (int)numArray1.Length);
                memoryStream.Close();
                cryptoStream.Close();
                empty = Encoding.Unicode.GetString(numArray1, 0, num);
            }
            return empty;
        }

        ///// <summary>
        ///// Decrypts the input based on provided salt.
        ///// </summary>
        ///// <param name="input">The input.</param>
        ///// <returns></returns>
        //public string Decrypt(string input)
        //{
        //    if (string.IsNullOrEmpty(input)) 
        //        return string.Empty;
            
        //    byte[] inputBytes = Convert.FromBase64String(input);
        //    byte[] saltBytes = System.Text.Encoding.ASCII.GetBytes(_salt.Length.ToString());

        //    PasswordDeriveBytes secretKey = new PasswordDeriveBytes(_salt, saltBytes);

        //    string output = string.Empty;
        //    using (MemoryStream memoryStream = new MemoryStream(inputBytes))
        //    {
        //        //AesCryptoServiceProvider is FIPS 140 compliant. FIPS 140 compliance is required for EPCS
        //        using (AesCryptoServiceProvider alg = new AesCryptoServiceProvider())
        //        {
        //            ICryptoTransform decryptor = alg.CreateDecryptor(secretKey.GetBytes(16), secretKey.GetBytes(16));

        //            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        //            {
        //                byte[] plainText = new byte[inputBytes.Length];
        //                int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
        //                output = Encoding.Unicode.GetString(plainText, 0, decryptedCount);
        //            }
        //        }
        //    }

        //    return output;
        //}
        #endregion
    }
}