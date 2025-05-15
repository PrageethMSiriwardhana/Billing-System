using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Billing_System
{
    public static class SecurityFunctions
    {
        // AES-256 Key (Base64 string decoded to 32 bytes)
        private static readonly byte[] Key = Convert.FromBase64String("jN0WJ3kTeJIs2F3sajh6h4u+ZlSDbV9Ho1Y/qBjJDm4=");

        /// <summary>
        /// Encrypts a plain text password using AES-256.
        /// Returns Base64 string containing IV + CipherText.
        /// </summary>
        public static string EncryptPassword(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                throw new ArgumentException("Password cannot be null or empty.");

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.GenerateIV(); // Random IV

                using (var ms = new MemoryStream())
                {
                    // Prepend IV
                    ms.Write(aes.IV, 0, aes.IV.Length);

                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>ෂ්
        /// Decrypts a Base64 string encrypted by EncryptPassword.
        /// Returns the original plain password.
        /// </summary>
        public static string DecryptPassword(string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
                throw new ArgumentException("Encrypted password cannot be null or empty.");

            try
            {
                byte[] fullCipher = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Key;

                    // Get IV (first 16 bytes)
                    byte[] iv = new byte[aes.BlockSize / 8];
                    Array.Copy(fullCipher, 0, iv, 0, iv.Length);

                    // Get Cipher bytes
                    byte[] cipherBytes = new byte[fullCipher.Length - iv.Length];
                    Array.Copy(fullCipher, iv.Length, cipherBytes, 0, cipherBytes.Length);

                    aes.IV = iv;

                    using (var ms = new MemoryStream(cipherBytes))
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid Base64 string format. Password may not be encrypted properly.", ex);
            }
            catch (CryptographicException ex)
            {
                throw new CryptographicException("Decryption failed. Possibly due to invalid key or corrupted data.", ex);
            }
        }
    }
}
