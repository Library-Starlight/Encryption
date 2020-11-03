using Encryption.Irreversible.Encryption;
using Encryption.Irreversible.Extensions;
using Encryption.Irreversible.Helper;
using Encryption.Irreversible.Interface;
using Encryption.Irreversible.Model;
using Encryption.Irreversible.Symmetric.AES;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.Extensions;
using System.Text;

namespace Encryption.Irreversible
{
    class Program
    {
        private static List<IEncrypt> EncryptList = new List<IEncrypt>();

        static void Main(string[] args)
        {
            if (Test())
                return;

            Encryption();
        }

        #region Test

        /// <summary>
        /// 测试操作的可用性
        /// </summary>
        /// <remarks>
        /// 测试完成后，需删除方法内部所有内容, 并返回false
        /// </remarks>
        /// <returns>是否正在测试，true: 正在测试, false: 不在测试</returns>
        private static bool Test()
        {

            return false;
        }

        #endregion

        #region AES128CBC

        private static void Aes128Cbc()
        {
            // 消息
            var text = "Hello World!";
            var key = new byte[32];
            var keyStr = Encoding.UTF8.GetString(key);
            var iv = new byte[16];
            // Base64加密和解密
            //var text = "Hello World!";
            //var base64 = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(text));
            //var raw = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(base64));

            //Console.WriteLine(base64);
            //Console.WriteLine(raw);
            //return true;

            //AES();

            Console.WriteLine("AES CBC 1");
            string original = "Hello World!";

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {

                // Encrypt the string to an array of bytes.
                byte[] encrypted = AesOfficial.EncryptStringToBytes_Aes(original, key, iv);
                Console.WriteLine(Convert.ToBase64String(encrypted));

                // Decrypt the bytes to a string.
                string roundtrip = AesOfficial.DecryptStringFromBytes_Aes(encrypted, key, iv);

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }

        #endregion

        #region 加密算法

        private static void Encryption()
        {
            // 添加加密算法
            EncryptList.Add(new RSA2048Encryption());
            EncryptList.Add(new SHA512Encryption());
            EncryptList.Add(new GWMD5Encryption());
            EncryptList.Add(new GWPwdEncryption());

            for (int i = 1; i <= EncryptList.Count; i++)
            {
                var encryptType = EncryptList[i - 1].GetType();
                Console.WriteLine($"{i}: {encryptType.GetDescription()}");
            }

            var index = 1;
            while (true)
            {
                Console.WriteLine($"请选择算法：");
                var s = Console.ReadLine();

                if (int.TryParse(s, out index) && index >= 1 && index <= EncryptList.Count)
                    break;

                Console.WriteLine($"请选择正确的算法序号。");
            }

            var encrypt = EncryptList[index - 1];

            var bIsEncrypt = false;
            while (true)
            {
                Console.WriteLine($"请选择加密(1)或解密(2)");
                var s = Console.ReadLine();

                if (int.TryParse(s, out var isEncrypt) && (isEncrypt == 1 || isEncrypt == 2))
                {
                    bIsEncrypt = isEncrypt == 1;
                    break;
                }

                Console.WriteLine($"请选择正确的加密或解密序号。");
            }

            Console.Clear();

            Console.WriteLine($"算法: {encrypt.GetType().GetDescription()}{Environment.NewLine}加密: {bIsEncrypt.ToString()}");
            ConsoleHelper.LoopProcessInputUntil(input =>
            {
                var enc = bIsEncrypt ? encrypt.Encrypt(input) : encrypt.Decrypt(input);
                Console.WriteLine($"  Input: {input}");
                Console.WriteLine($" Output: {enc}");
                Console.WriteLine($" Base64: {Convert.ToBase64String(Encoding.UTF8.GetBytes(enc))}");
            }, "$End");
        }

        #endregion

        #region RSA2048加密

        private static void Rsa()
        {
            var text = "Hello World!";

            // 加密解密
            var provider = new RsaProvider(RsaType.RSA2, Encoding.UTF8);
            var enc = provider.Encrypt(text);
            var dec = provider.Decrypt(enc);
            Console.WriteLine($"Enc: {enc}");
            Console.WriteLine($"Dec: {dec}");

            // 签名验证
            provider = new RsaProvider(RsaType.RSA2, Encoding.UTF8, Const.RSAPrivateKey, Const.RSAPublicKey);
            var sig = provider.Sign(text);
            var ver = provider.Verify(text, sig);
            Console.WriteLine(sig);
            Console.WriteLine(ver);

            //var prik = Const.RSAPrivateKey;
            //var pubk = Const.RSAPublicKey;
            //var sign = RsaVerify.Sign(text, prik);
            //var verify = RsaVerify.SignCheck(text, sign, pubk);
            //Console.WriteLine(sign);
            //Console.WriteLine(verify);
        }

        /// <summary>
        /// RSA2048加密
        /// </summary>
        private static void RSA2048Encrypt()
        {
            var rsaHelper = new RsaProvider(RsaType.RSA2, Encoding.UTF8);

            ConsoleHelper.LoopProcessInputUntil(input =>
            {
                var enc = rsaHelper.Encrypt(input);
                Console.WriteLine($"  Input: {input}");
                Console.WriteLine($"Encrypt: {enc}");
            }, "$End");
        }

        private static void RSA2048Decrypt()
        {
            var rsaHelper = new RsaProvider(RsaType.RSA2, Encoding.UTF8);

            ConsoleHelper.LoopProcessInputUntil(input =>
            {
                var dec = rsaHelper.Decrypt(input);
                Console.WriteLine($"  Input: {input}");
                Console.WriteLine($"Decrypt: {dec}");
            }, "$End");
        }

        #endregion

        #region 生成安全随机数

        private static void GenerateSecureRandomNumber()
        {
            for (int i = 0; i < 100; i++)
            {
                var rn = GetDouble();

                Console.WriteLine(rn);
            }
        }

        private static double GetDouble()
        {
            var rng = RandomNumberGenerator.Create();
            var data = new byte[4];
            rng.GetBytes(data);

            return BitConverter.ToUInt32(data, 0) / (double)uint.MaxValue;
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
