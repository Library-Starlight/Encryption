using Encryption.Irreversible.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Encryption
{
    [Description("SHA512算法")]
    public class SHA512Encryption : IEncrypt
    {
        private readonly SHA512 _sha512 = new SHA512Managed();

        public string Decrypt(string input)
        {
            throw new NotImplementedException("The alogrithm is irreversible");
        }

        public string Encrypt(string input)
        {
            // 实现SHA512算法
            var data = Encoding.UTF8.GetBytes(input);
            var result = _sha512.ComputeHash(data);
            
            return BitConverter.ToString(result).Replace("-", "");
        }
    }
}
