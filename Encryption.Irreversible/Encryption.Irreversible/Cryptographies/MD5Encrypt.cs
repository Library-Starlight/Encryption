using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible
{
    public class MD5Encrypt
    {
        /// <summary>
        /// 获取16字节（32位）大写MD5编码字符串
        /// </summary>
        /// <param name="buff">编码</param>
        /// <returns></returns>
        public static string Encrypt(byte[] buff)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(buff);
            return BitConverter.ToString(output).Replace("-", "");
        }

        public static string Encrypt(string input)
        {
            var buff = Encoding.ASCII.GetBytes(input);
            return Encrypt(buff);
        }

        /// <summary>
        /// 获取16字节（32位）大写MD5编码字符串
        /// </summary>
        /// <param name="buff">编码</param>
        /// <returns></returns>
        public static string Encrypt1(byte[] buff)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] bytesMD5 = md5Hasher.ComputeHash(buff);
            return BitConverter.ToString(bytesMD5).Replace("-", "");
        }

        public static string Encrypt1(string input)
        {
            var buff = Encoding.ASCII.GetBytes(input);
            return Encrypt1(buff);
        }
    }
}
