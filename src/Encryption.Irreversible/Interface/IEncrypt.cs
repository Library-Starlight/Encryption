using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Interface
{
    public interface IEncrypt
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input">待加密字符串</param>
        /// <returns></returns>
        string Encrypt(string input);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="input">待解密字符串</param>
        /// <returns></returns>
        string Decrypt(string input);
    }
}
