using Krypton.Toolkit;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Security
{
    public class Encryption
    {
        private static readonly byte[] _salt = Encoding.ASCII.GetBytes("put_your_salt_here");

        public  string Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;

            using (var aes = new AesManaged())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;

                var key = new Rfc2898DeriveBytes(password, _salt);
                aes.Key = key.GetBytes(aes.KeySize / 8);

                aes.IV = key.GetBytes(aes.BlockSize / 8);

                using (var encryptor = aes.CreateEncryptor())
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new StreamWriter(cs))
                            {
                                sw.Write(plainText);
                            }

                            encryptedBytes = ms.ToArray();
                        }
                    }
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public  string Decrypt(string encryptedText, string password)
        {
            string decryptedText;

            using (var aes = new AesManaged())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;

                var key = new Rfc2898DeriveBytes(password, _salt);
                aes.Key = key.GetBytes(aes.KeySize / 8);

                aes.IV = key.GetBytes(aes.BlockSize / 8);

                using (var decryptor = aes.CreateDecryptor())
                {
                    using (var ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var sr = new StreamReader(cs))
                            {
                                decryptedText = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }

            return decryptedText;
        }

        public  string EncryptTextBoxValue(KryptonTextBox textBox, string password)
        {
            var plainText = textBox.Text;
            var encryptedText = Encrypt(plainText, password);
            return encryptedText;
        }

        public  string DecryptTextBoxValue(TextBox textBox, string password)
        {
            var encryptedText = textBox.Text;
            var decryptedText = Decrypt(encryptedText, password);
            
            return decryptedText;
        }
    }



}

