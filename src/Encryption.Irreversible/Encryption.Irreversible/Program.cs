using Encryption.Irreversible.Cryptographies;
using Encryption.Irreversible.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://127.0.0.1:80");

            

        }

        #region AES CBC

        private static void GetAes()
        {
            var request = new TokenModel
            {
                userId = "12564",
                nonce = "a9028aad1c7a611a",
            };

            var original = JsonConvert.SerializeObject(request);
            var key = "DWYEiW9kqtRs21da";
            var iv = Guid.NewGuid().ToString("N").Substring(0, 16);

            var base64 = AesEncrypt.EncryptStringToBase64(original, key, iv);
            Console.WriteLine(key);
            Console.WriteLine(iv);
            Console.WriteLine(base64);
        }

        private static void AES()
        {
            string original = "Here is some data to encrypt!";
            var key = "DWYEiW9kqtRs21da";

            var iv = Guid.NewGuid().ToString("N").Substring(0, 16);
            Console.WriteLine(key);
            Console.WriteLine(iv);   
            var str = AesEncrypt.EncryptStringToBase64(original, key, iv);
            Console.WriteLine(str);

            var org = AesEncrypt.DecryptBase64ToOriginal(str, key, iv);
            Console.WriteLine(org);
            Console.WriteLine();
        }

        private static void AESCBC()
        {
            string original = "Here is some data to encrypt!";

            using (Aes myAes = Aes.Create())
            {
                // Encrypt the string to an array of bytes.
                byte[] encrypted = Cryptographies.AesEncrypt.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

                Console.WriteLine($"Key: {BitConverter.ToString(myAes.Key)}");
                Console.WriteLine($"Key: {Encoding.UTF8.GetString(myAes.Key)}");
                Console.WriteLine($" IV: {BitConverter.ToString(myAes.IV)}");
                Console.WriteLine($" IV: {Encoding.UTF8.GetString(myAes.IV)}");
                Console.WriteLine($"Base64: {Convert.ToBase64String(encrypted)}");

                // Decrypt the bytes to a string.
                string roundtrip = Cryptographies.AesEncrypt.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }

        #endregion

        #region ContentMD5编码

        private static void ContentMD5()
        {
            var str = "Hello World!";
            var data = Encoding.UTF8.GetBytes(str);
            var md5 = MD5Encrypt.GetEncryptData(data);
            var base64 = Convert.ToBase64String(md5);
            Console.WriteLine(base64);

            var bas64 = MD5Encrypt.GetContentMD5(str);
            Console.WriteLine(bas64);
        }

        #endregion
    }
}
