using Encryption.Irreversible.Check;
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
            CRC16ModbusChecksum();
        }

        #region CRC-16-Modbus校验和

        /// <summary>
        /// CRC-16-Modbus校验和
        /// </summary>
        private static void CRC16ModbusChecksum()
        {
            //var data = new byte[] { 0x16, 0x75, 0x85 };
            //var result = CRC16ModbusCheck.GetModbusCrc16(data);
            //Console.WriteLine(BitConverter.ToString(result));

            //var success = CRC16ModbusCheck.Check(data, result);
            //Console.WriteLine(success);


            ////var s = "QN=20200626171007000;ST=80;CN=2011;PW=123456;MN=001093102352003110310069;Flag=5;CP=&&DataTime=20200626171000;ea30010101-Rtd=0.00,ea30010101-Flag=F;ea30010102-Rtd=0.00,ea30010102-Flag=F;ea30010103-Rtd=0.00,ea30010103-Flag=F;ea30010104-Rtd=0.00,ea30010104-Flag=F;ea30010105-Rtd=0.000,ea30010105-Flag=F;ea30010106-Rtd=0.000,ea30010106-Flag=F;ea30010107-Rtd=0.00,ea30010107-Flag=F;ea30010108-Rtd=0.00,ea30010108-Flag=F;ea30010109-Rtd=0.00,ea30010109-Flag=F;ea30010110-Rtd=0.0,ea30010110-Flag=F;ea30010111-Rtd=0.0,ea30010111-Flag=F;ea30010112-Rtd=0.0,ea30010112-Flag=F;ea30010113-Rtd=0.0,ea30010113-Flag=F&&";
            //var s = "ST=22;CN=2011;PW=123456;MN=8888888887654321;CP=&&DataTime=20170817180416;PM25-Rtd=30.5;PM10-Rtd=33.8;TEMP-Rtd=27.9;HUMI-Rtd=58.6;SO2-Rtd=27.7;NO2-Rtd=57.2;&&";
            //var data = Encoding.ASCII.GetBytes(s);
            //Console.WriteLine(BitConverter.ToString(data).Replace("-", ""));
            ////var checkSum = new byte[] { 0xFE, 0x41 };
            //var checkSum = new byte[] { 0x1B, 0x9A };
            //var success = CRC16ModbusCheck.Check(data, checkSum);
            //Console.WriteLine(success);

            //var realSum = CRC16ModbusCheck.GetModbusCrc16(data);
            //Console.WriteLine(BitConverter.ToString(realSum));

            //var s = "##0101QN=20160801085857223;ST=32;CN=1062;PW=100000;MN=010000A8900016F000169DC0;Flag=5;CP=&&RtdInterval=30&&1C80";
            //var body = "QN=20160801085857223;ST=32;CN=1062;PW=100000;MN=010000A8900016F000169DC0;Flag=5;CP=&&RtdInterval=30&&";
            var body = "ST=22;CN=2011;PW=123456;MN=8888888887654322;CP=&&DataTime=20210114180416;PM25-Rtd=30.5;PM10-Rtd=33.8;TEMP-Rtd=27.9;HUMI-Rtd=58.6;SO2-Rtd=27.7;NO2-Rtd=57.2;PM100-Rtd=52.5;O3-Rtd=33.3;CO-Rtd=44.4;CO2-Rtd=55.5;VOC-Rtd=66.6;CH2O-Rtd=77.7;O2-Rtd=88.8;MPA-Rtd=99.9;WS-Rtd=11.11;WD-Rtd=22.22;NOISE-Rtd=33.33;CL2-Rtd=44.44;HCL-Rtd=55.55;H2S-Rtd=66.66;NH3-Rtd=77.77&&";
            var data = Encoding.ASCII.GetBytes(body);
            var checkSum = HJ212CRC16Check.CRC16Checkout(data);
            Console.WriteLine(checkSum);
        }

        #endregion

        #region AES算法测试

        /// <summary>
        /// 测试操作的可用性
        /// </summary>
        /// <remarks>
        /// 测试完成后，需删除方法内部所有内容, 并返回false
        /// </remarks>
        /// <returns>是否正在测试，true: 正在测试, false: 不在测试</returns>
        private static bool AesTest()
        {
            Rsa();
            return true;

            var text = "Hello World!";
            var encryptKey = Guid.NewGuid().ToString("N"); //"d9b46c3513654f66bea91f7e81009ce9";
            var key = encryptKey.ToBytes();
            //key = Encoding.UTF8.GetBytes(encryptKey);
            var iv = new byte[16];

            var enc = AesProvider.Encrypt(text, key, iv);
            var dec = AesProvider.Decrypt(enc, key, iv);

            Console.WriteLine($"加密前：{text}");
            Console.WriteLine($"加密后：{enc}");
            Console.WriteLine($"   key：{BitConverter.ToString(key).Replace("-", "")}");
            Console.WriteLine($"    iv：{BitConverter.ToString(iv).Replace("-", "")}");

            return true;
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
