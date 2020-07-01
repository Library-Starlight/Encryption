using Encryption.Irreversible.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Encryption
{
    /// <summary>
    /// 敢为密码算法
    /// </summary>
    [Description("敢为密码算法")]
    public class GWPwdEncryption : IEncrypt
    {
        /// <summary>
        /// SHA512算法
        /// </summary>
        private readonly IEncrypt _sha512Encrypt = new SHA512Encryption();

        /// <summary>
        /// 敢为MD5算法
        /// </summary>
        private readonly IEncrypt _gwMD5Encrypt = new GWMD5Encryption();

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Decrypt(string input)
        {
            throw new NotImplementedException("The alogrithm is irreversible");
        }

        /// <summary>
        /// 将明文的密码进行加密获取安全存储密码。
        ///     ①进行SHA512加密，加密结果以小写字符串输出
        ///     ②进行敢为MD5加密
        /// </summary>
        /// <param name="input">密码明文</param>
        /// <returns></returns>
        public string Encrypt(string input)
        {
            var sha512Value = _sha512Encrypt.Encrypt(input).ToLower();
            return _gwMD5Encrypt.Encrypt(sha512Value);
        }
    }
}
