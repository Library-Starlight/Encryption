using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Irreversible
{
    public class Sha256
    {
        /// <summary>
        /// Sha256编码(结果为64位)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Encrypt(string str)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] by = Sha256.ComputeHash(data);
            return BitConverter.ToString(by).Replace("-", "").ToLower();
        }
    }
}
