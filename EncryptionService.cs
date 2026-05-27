using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Services
{
    public static class EncryptionService
    {
        private static readonly string Key = "1234567890123456";
        private static readonly string IV = "6543210987654321";

        public static string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            ICryptoTransform encryptor = aes.CreateEncryptor();

            using MemoryStream ms = new MemoryStream();
            using CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using StreamWriter sw = new StreamWriter(cs);

            sw.Write(plainText);
            sw.Flush();
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipherText)
        {
            using Aes aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            ICryptoTransform decryptor = aes.CreateDecryptor();

            byte[] buffer = Convert.FromBase64String(cipherText);

            using MemoryStream ms = new MemoryStream(buffer);
            using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using StreamReader sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
    }
}