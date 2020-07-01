using Encryption.Irreversible.Interface;
using Encryption.Irreversible.RSAs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible.Encryption
{
    [Description("RSA2048算法(公钥和私钥固定)")]
    public class RSA2048Encryption : IEncrypt
    {
        private readonly RsaHelper _rsaHelper = new RsaHelper(RsaType.RSA2, Encoding.UTF8);

        public string Decrypt(string input)
        {
            return _rsaHelper.Decrypt(input);
        }

        public string Encrypt(string input)
        {
            return _rsaHelper.Encrypt(input);
        }
    }
}
