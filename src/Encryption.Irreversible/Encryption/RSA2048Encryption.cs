using Encryption.Irreversible.Asymmetric.RSA;
using Encryption.Irreversible.Interface;
using System.ComponentModel;
using System.Text;

namespace Encryption.Irreversible.Encryption
{
    [Description("RSA2048算法(公钥和私钥固定)")]
    public class RSA2048Encryption : IEncrypt
    {
        private readonly RsaProvider _rsaHelper = new RsaProvider(RsaType.RSA2, Encoding.UTF8);

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
